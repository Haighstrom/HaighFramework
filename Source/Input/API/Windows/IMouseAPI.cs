using HaighFramework.Input;
using HaighFramework.WinAPI;

namespace HaighFramework.Input.Windows;

internal interface IMouseAPI
{
    MouseState GetAggregateState();

    bool ProcessInputData(RawInput data);

    void UpdateDevices();
}