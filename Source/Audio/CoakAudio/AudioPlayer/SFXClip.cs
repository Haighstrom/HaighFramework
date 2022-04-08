﻿using HaighFramework.Audio.OpenAL;
using HaighFramework.Audio.OpenAL.Wav;
using HaighFramework.Audio.OpenAL.OggVorbis;

namespace HaighFramework.Audio;

/// <summary>
/// A container for audio. Represents a single piece of audio that can
/// be repeatedly played. 
/// </summary>
public class SFXClip : AudioClip
{
    public SFXClip(string fileName)
        : base(fileName)
    {
    }

    /// <summary>
    /// Plays the audio clip.
    /// </summary>
    internal override void Play()
    {
        lock (AudioManager.Manager)
        {
            if (rawClip is VorbisFile)
                AudioManager.Manager.PlaySFXClip(((VorbisFile)rawClip).makeInstance());
            else if (rawClip is WavFile)
                AudioManager.Manager.PlaySFXClip((WavFile)rawClip);
            else
                throw new NotImplementedException();
        }
    }
}
