using System;

namespace HaighFramework.Audio.OpenAL.OggVorbis
{
	internal class csorbisException : Exception 
	{
		internal csorbisException ()
			:base(){}
		internal csorbisException (String s)
			:base("csorbis: "+s){}
	}
}
