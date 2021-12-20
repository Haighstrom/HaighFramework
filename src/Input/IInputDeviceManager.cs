using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaighFramework.Input
{
    public interface IInputDeviceManager : IDisposable
    {
        IMouseManager MouseManager { get; }
        IKeyboardManager KeyboardManager { get; }
    }
}