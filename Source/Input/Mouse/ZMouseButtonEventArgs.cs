namespace HaighFramework.Input;

public class ZMouseButtonEventArgs : EventArgs
{
    public ZMouseButtonEventArgs(MouseButton button, ButtonState state)
    {
        Button = button;
        ButtonState = state;
    }

    public MouseButton Button { get; }
    public ButtonState ButtonState { get; }

    public bool Pressed => ButtonState == ButtonState.Down;
}