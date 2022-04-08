﻿namespace HaighFramework.Input;

public interface IKeyboardManager
{
    KeyboardState State { get; }
    KeyboardState GetState(int index);
    void RefreshDevices();
}
