using System;


namespace HaighFramework.Audio.OpenAL.OggVorbis
{
	abstract class FuncTime
	{
		internal static FuncTime[] time_P={new Time0()};

		internal abstract void pack(Object i, csBuffer opb);
		internal abstract Object unpack(Info vi , csBuffer opb);
		internal abstract Object look(DspState vd, InfoMode vm, Object i);
		internal abstract void free_info(Object i);
		internal abstract void free_look(Object i);
		internal abstract int forward(Block vb, Object i);
		internal abstract int inverse(Block vb, Object i, float[] fin, float[] fout);
	}
}