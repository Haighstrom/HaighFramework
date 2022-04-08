namespace HaighFramework.Audio.OpenAL.OggVorbis;

    /// <summary>
    /// Summary description for Packet.
    /// </summary>
    internal class Packet
{
	internal byte[] packet_base;
	internal int packet;
	internal int bytes;
	internal int b_o_s;
	internal int e_o_s;

	internal long granulepos;

	internal long packetno; // sequence number for decode; the framing
	// knows where there's a hole in the data,
	// but we need coupling so that the codec
	// (which is in a seperate abstraction
	// layer) also knows about the gap

	internal Packet()
	{
		// No constructor
	}
}
