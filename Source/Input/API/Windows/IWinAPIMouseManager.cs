using HaighFramework.Input;
using HaighFramework.WinAPI;

namespace HaighFramework.Input.Windows;

internal interface IWinAPIMouseManager
{
    MouseState GetAggregateState();
    bool ProcessInputData(RawInput data);
    void UpdateDevices();
}