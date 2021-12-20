using System;
using System.Collections.Generic;
using System.Linq;
using HaighFramework.Win32API;

namespace HaighFramework.Input
{
    public interface IKeyboardManager
    {
        KeyboardState State { get; }
        KeyboardState GetState(int index);
        void RefreshDevices();
    }
}