using System;


namespace HaighFramework.Audio.OpenAL.OggVorbis
{
	abstract class FuncResidue
	{
		internal static FuncResidue[] residue_P={new Residue0(),
												  new Residue1(),
												  new Residue2()};

		internal abstract void pack(Object vr, csBuffer opb);
		internal abstract Object unpack(Info vi, csBuffer opb);
		internal abstract Object look(DspState vd, InfoMode vm, Object vr);
		internal abstract void free_info(Object i);
		internal abstract void free_look(Object i);
		internal abstract int forward(Block vb,Object vl, float[][] fin, int ch);

		internal abstract int inverse(Block vb, Object vl, float[][] fin, int[] nonzero,int ch);
	}
}