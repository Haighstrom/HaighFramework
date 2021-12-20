using System;


namespace HaighFramework.Audio.OpenAL.OggVorbis
{
	class Time0 : FuncTime
	{
		override internal void pack(Object i, csBuffer opb){}
		override internal Object unpack(Info vi , csBuffer opb){return "";}
		override internal Object look(DspState vd, InfoMode mi, Object i){return "";}
		override internal void free_info(Object i){}
		override internal void free_look(Object i){}
		override internal int forward(Block vb, Object i){return 0;}
		override internal int inverse(Block vb, Object i, float[] fin, float[] fout){return 0;}
	}
}
