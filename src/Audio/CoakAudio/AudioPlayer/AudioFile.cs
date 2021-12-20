using System;
using System.IO;
using System.Collections.Generic;


namespace HaighFramework.Audio.OpenAL
{
    internal abstract class AudioFile 
    {
        internal Stream datasource;

        internal AudioFile()
            : base()
        {

        }

        internal abstract void Dispose();
    }
}
