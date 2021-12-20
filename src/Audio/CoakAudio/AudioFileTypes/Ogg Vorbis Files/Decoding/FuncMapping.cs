using System;


namespace HaighFramework.Audio.OpenAL.OggVorbis
{
	abstract class FuncMapping
	{
		internal static FuncMapping[] mapping_P={new Mapping0()};

		internal abstract void pack(Info info , Object imap, csBuffer buffer);
		internal abstract Object unpack(Info info , csBuffer buffer);
		internal abstract Object look(DspState vd, InfoMode vm, Object m);
		internal abstract void free_info(Object imap);
		internal abstract void free_look(Object imap);
		internal abstract int inverse(Block vd, Object lm);
	}
}