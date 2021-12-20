using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaighFramework.Window
{
    [Flags]
    public enum WindowCreationFlags
    {
        None = 0,
        InvisibleOnCreation = 1,
        HideCursor = 2
    }
}
