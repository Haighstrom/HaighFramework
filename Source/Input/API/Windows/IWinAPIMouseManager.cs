using HaighFramework.Input;
using HaighFramework.WinAPI;

namespace HaighFramework.Source.Input.Mouse;

internal interface IWinAPIMouseManager
{
    MouseState GetAggregateState();
    bool ProcessInputData(RawInput data);
    void UpdateDevices();
}