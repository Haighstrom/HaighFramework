using System.IO;

namespace HaighFramework.Audio.OpenAL;

internal abstract class AudioFile 
{
    internal Stream? datasource;

    internal AudioFile()
        : base()
    {

    }

    internal abstract void Dispose();
}
