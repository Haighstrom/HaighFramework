using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HaighFramework.Win32API;

namespace HaighFramework.Input
{
    public interface IMouseManager
    {
        MouseState State { get; }
        MouseState GetState(int index);
        void RefreshDevices();
    }
}