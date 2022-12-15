namespace HaighFramework.Input;

public interface IKeyboardManager
{
    KeyboardState GetAggregateState { get; }
    KeyboardState GetState(int index);
    void UpdateDevices();
}
