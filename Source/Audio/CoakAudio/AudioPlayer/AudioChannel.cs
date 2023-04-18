﻿using HaighFramework.Audio.OpenAL.Wav;
using HaighFramework.Audio.OpenAL.OggVorbis;


namespace HaighFramework.Audio.OpenAL;

/// <summary>
/// An object for buffering and playing data on a single channel. 
/// </summary>
internal class AudioChannel : IDisposable
{
    public byte[] SegmentBuffer { get; private set; }
    public uint[] Buffers { get; private set; }
    public int BufferCount { get; private set; }
    public int BufferSize { get; private set; }
    public uint Source { get; private set; }
    internal AudioFile CurrentClip { get; private set; }

    public ALFormat CurrentFormat { get; private set; }
    public int CurrentRate { get; private set; }

    private bool eof;

    public bool IsFree => CurrentClip == null;

    private const int _BIGENDIANREADMODE = 0;		// Big Endian config for read operation: 0=LSB;1=MSB
    private const int _WORDREADMODE = 2;			// Word config for read operation: 1=Byte;2=16-bit Short
    private const int _SGNEDREADMODE = 1;			// Signed/Unsigned indicator for read operation: 0=Unsigned;1=Signed

    /// <summary>
    /// Constructs an empty channel, ready to play sound.
    /// </summary>
    /// <param name="bufferCount">The number of audio buffers to size.</param>
    /// <param name="bufferSize">The size, in bytes, of each audio buffer.</param>
    public AudioChannel(int bufferCount, int bufferSize)
    {
        Buffers = new uint[bufferCount];
        BufferCount = bufferCount;
        BufferSize = bufferSize;
        CurrentClip = null;

        SegmentBuffer = new byte[bufferSize];

        // Make the source
        Source = AL.GenSource();

        // Make the buffers
        for(int i = 0; i < BufferCount; i++)
            Buffers[i] = AL.GenBuffer();
    }

    /// <summary>
    /// Deconstructs the channel, freeing its hardware resources.
    /// </summary>
    ~AudioChannel()
    {
        Dispose(); 
    }

    /// <summary>
    /// Disposes the channel, freeing its hardware resources.
    /// </summary>
    public void Dispose()
    {
        AL.SourceStop(Source);
        if(Buffers != null)
            AL.DeleteBuffers(Buffers);

        Buffers = null;
        CurrentClip = null;
    }

    /// <summary>
    /// Determines the format of the given audio clip.
    /// </summary>
    /// <param name="clip">The clip to determine the format of.</param>
    /// <returns>The audio format.</returns>
    internal static ALFormat DetermineFormat(VorbisFileInstance clip)
    {
        //This is a hack for now as wav files will just give null as their info
        if (clip.GetInfo() == null)
            return ALFormat.Mono16;

        // TODO: Should probably do more than just check the format of the first stream.
        Info[] clipInfo = clip.GetInfo();

        if (clipInfo.Length < 1 || clipInfo[0] == null)
            throw new ArgumentException("Audio clip does not have track information");

        Info info = clipInfo[0];

        // The number of channels is determined by the clip.  The bit depth
        // however is the choice of the player.  If desired, 8-bit audio
        // could be supported here.
        if (info.channels == 1)
        {
            return ALFormat.Mono16;
        }
        else if (info.channels == 2)
        {
            return ALFormat.Stereo16;
        }
        else
        {
            throw new NotImplementedException("Only mono and stereo are implemented.  Audio has too many channels.");
        }
    }

    /// <summary>
    /// Determines the rate of the given audio clip.
    /// </summary>
    /// <param name="clip">The clip to determine the rate of.</param>
    /// <returns>The audio rate.</returns>
    internal int DetermineRate(VorbisFileInstance clip)
    {
        //This is a hack for now as wav files will just give null as their info
        if (clip.GetInfo() == null)
            return 16;

        // TODO: Should probably do more than just check the format of the first stream.
        Info[] clipInfo = clip.GetInfo();

        if (clipInfo.Length < 1 || clipInfo[0] == null)
            throw new ArgumentException("Audio clip does not have track information");

        Info info = clipInfo[0];

        return info.rate;
    }

    

    /// <summary>
    /// Begins playing the given clip.
    /// </summary>
    /// <param name="clip">The clip to play.</param>
    internal void Play(WavFile clip)
    {
        clip.Reset();
        DequeuUsedBuffers();

        CurrentFormat = WavFile.GetSoundFormat(clip.Channels, clip.Bits_per_sample);
        CurrentRate = clip.Sample_rate;

        CurrentClip = clip;
        eof = false;

        // Buffer initial audio
        int usedBuffers = 0;
        for (int i = 0; i < BufferCount; i++)
        {
            int bytesRead = clip.read(SegmentBuffer, SegmentBuffer.Length);

            if (bytesRead > 0)
            {
                // Buffer the segment
                AL.BufferData(Buffers[i], CurrentFormat, SegmentBuffer, bytesRead,
                    CurrentRate);

                usedBuffers++;
            }
            else if (bytesRead == 0)
            {
                // Clip is too small to fill the initial buffer, so stop
                // buffering.
                break;
            }
            else
            {
                //There was an error reading the file
                throw new System.IO.IOException("Error reading or processing WAV file");
            }
        }

        // Start playing the clip
        AL.SourceQueueBuffers(Source, usedBuffers, Buffers);
        AL.SourcePlay(Source);
    }

    /// <summary>
    /// Begins playing the given clip.
    /// </summary>
    /// <param name="clip">The clip to play.</param>
    internal void Play(VorbisFileInstance clip)
    {
        DequeuUsedBuffers();

        CurrentFormat = DetermineFormat(clip);
        CurrentRate = DetermineRate(clip);

        CurrentClip = clip;
        eof = false;

        // Buffer initial audio
        int usedBuffers = 0;
        for (int i = 0; i < BufferCount; i++)
        {
            int bytesRead = clip.read(SegmentBuffer, SegmentBuffer.Length,
                _BIGENDIANREADMODE, _WORDREADMODE, _SGNEDREADMODE, null);

            if (bytesRead > 0)
            {
                // Buffer the segment
                AL.BufferData(Buffers[i], CurrentFormat, SegmentBuffer, bytesRead,
                    CurrentRate);

                usedBuffers++;
            }
            else if (bytesRead == 0)
            {
                // Clip is too small to fill the initial buffer, so stop
                // buffering.
                break;
            }
            else
            {
                //There was an error reading the file
                throw new System.IO.IOException("Error reading or processing OGG file");
            }
        }

        // Start playing the clip
        AL.SourceQueueBuffers(Source, usedBuffers, Buffers);
        AL.SourcePlay(Source);
    }

    /// <summary>
    /// Removes all empty buffers from the audio queue.
    /// </summary>
    protected void DequeuUsedBuffers()
    {
        AL.GetSource(Source, ALGetSourcei.BuffersProcessed, out int processedBuffers);

        uint[] removedBuffers = new uint[processedBuffers];
       // OpenTK.Audio.OpenAL.AL.SourceUnqueueBuffers(Source, processedBuffers, removedBuffers);
        AL.SourceUnqueueBuffers(Source, processedBuffers, removedBuffers);
    }


    /// <summary>
    /// Set volume/gain of audio channel - from 0f to 1.0f
    /// </summary>
    internal void SetVolume(float vol)
    {
        AL.Source(Source, ALSourcef.Gain, vol);
    }

    /// <summary>
    /// Stops the channel
    /// </summary>
    internal void Stop()
    {
        if (CurrentClip is WavFile)
            (CurrentClip as WavFile).Reset();

        AL.SourceStop(Source);
        CurrentClip = null;
    }

    /// <summary>
    /// Updates the channel, buffer addition audio if needed.  This method
    /// needs to be called frequently to maintain real-time performance.
    /// </summary>
    internal void Update()
    {
        if (CurrentClip != null)
        {
            AL.GetSource(Source, ALGetSourcei.BuffersQueued, out int buffersQueued);

            AL.GetSource(Source, ALGetSourcei.BuffersProcessed, out int processedBuffers);

            if (eof)
            {
                // Clip is done being buffered
                if (buffersQueued <= processedBuffers)
                {
                    // Clip has finished
                    AL.SourceStop(Source);
                    CurrentClip = null;

                    DequeuUsedBuffers();

                    return;
                }
            }
            else
            {
                // Still some buffering to do
                if (buffersQueued - processedBuffers > 0 && AL.GetError() == ALError.NoError)
                {
                    // Make sure we're playing (not sure why we would've stopped)
                    if (AL.GetSourceState(Source) != ALSourceState.Playing)
                    {
                        AL.SourcePlay(Source);
                    }
                }

                // Detect buffer under-runs
                bool underRun = processedBuffers >= BufferCount;

                // Remove processed buffers
                while (processedBuffers > 0)
                {
                    uint removedBuffer = 0;

                    // TODO: Can remove more than one buffer here.  Can also
                    // add the buffers back to the queue.
                    AL.SourceUnqueueBuffers(Source, 1, ref removedBuffer);

                    // Just remove the buffer and don't do anything else if
                    // we're at the end of the clip.
                    if (eof)
                    {
                        processedBuffers--;
                        continue;
                    }

                    // Buffer the next chunk
                    int bytesRead = 0;
                    if (CurrentClip is VorbisFileInstance)
                        bytesRead = (CurrentClip as VorbisFileInstance).read(SegmentBuffer, SegmentBuffer.Length, _BIGENDIANREADMODE, _WORDREADMODE, _SGNEDREADMODE, null);
                    else if (CurrentClip is WavFile)
                        bytesRead = (CurrentClip as WavFile).read(SegmentBuffer, SegmentBuffer.Length);
                    else
                        throw new NotImplementedException();

                    if (bytesRead > 0)
                    {
                        // TOOD: Queue multiple buffers here
                        AL.BufferData(removedBuffer, CurrentFormat, SegmentBuffer, bytesRead,
                            CurrentRate);
                        AL.SourceQueueBuffer(Source, removedBuffer);
                    }
                    else if (bytesRead == 0)
                    {
                        // Reached the end of the file
                        eof = true;
                    }
                    else
                    {
                        // A file read error has occurred, stop playing
                        AL.SourceStop(Source);
                        CurrentClip = null;
                        break;
                    }

                    // Check for OpenAL errors
                    ALError err = AL.GetError();
                    if (err != ALError.NoError)
                    {
                        AL.SourceStop(Source);
                        CurrentClip = null;
                        System.Console.WriteLine("OpenAL Error: " + err.ToString());
                        break;
                    }

                    processedBuffers--;
                }
            }
        }
    }
}
