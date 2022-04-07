﻿namespace HaighFramework.Input
{
    public interface IInputDeviceManager : IDisposable
    {
        IMouseManager MouseManager { get; }
        IKeyboardManager KeyboardManager { get; }
    }
}