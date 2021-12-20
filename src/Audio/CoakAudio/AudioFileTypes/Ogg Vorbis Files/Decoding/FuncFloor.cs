using System;


namespace HaighFramework.Audio.OpenAL.OggVorbis
{
	abstract class FuncFloor
	{
		internal static FuncFloor[] floor_P={new Floor0(),new Floor1()};

		internal abstract void pack(Object i, csBuffer opb);
		internal abstract Object unpack(Info vi, csBuffer opb);
		internal abstract Object look(DspState vd, InfoMode mi, Object i);
		internal abstract void free_info(Object i);
		internal abstract void free_look(Object i);
		internal abstract void free_state(Object vs);
		internal abstract int forward(Block vb, Object i, float[] fin, float[] fout, Object vs);
		internal abstract Object inverse1(Block vb, Object i, Object memo);
		internal abstract int inverse2(Block vb, Object i, Object memo, float[] fout);
	}
}
