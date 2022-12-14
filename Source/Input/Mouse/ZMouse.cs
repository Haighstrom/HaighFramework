using HaighFramework.Window;

namespace HaighFramework.Input;

public class ZMouse
{
    private readonly Dictionary<MouseButton, ButtonState> _buttonStates = new()
    {
        { MouseButton.Left, ButtonState.Up },
        { MouseButton.Middle, ButtonState.Up },
        { MouseButton.Right, ButtonState.Up },
        { MouseButton.Mouse4, ButtonState.Up },
        { MouseButton.Mouse5, ButtonState.Up },
    };

    public ZMouse(IWindow window)
    {
        window.MouseButtonDown += Window_MouseButtonStateChanged;
        window.MouseButtonUp += Window_MouseButtonStateChanged;
    }

    private void Window_MouseButtonStateChanged(object? sender, ZMouseButtonEventArgs e)
    {
        _buttonStates[e.Button] = e.ButtonState;
    }

    public ButtonState GetButtonState(MouseButton button) => _buttonStates[button];

    public bool MouseLeftDown => _buttonStates[MouseButton.Left] == ButtonState.Down;
    public bool MouseMiddleDown => _buttonStates[MouseButton.Middle] == ButtonState.Down;
    public bool MouseRightDown => _buttonStates[MouseButton.Right] == ButtonState.Down;
    public bool Mouse4Down => _buttonStates[MouseButton.Mouse4] == ButtonState.Down;
    public bool Mouse5Down => _buttonStates[MouseButton.Mouse5] == ButtonState.Down;

    public override string ToString() => $"Mouse State:\n  Buttons: L:{_buttonStates[MouseButton.Left]}, M:{_buttonStates[MouseButton.Middle]}, R:{_buttonStates[MouseButton.Right]}, M4:{_buttonStates[MouseButton.Mouse4]}, M5:{_buttonStates[MouseButton.Mouse5]}";
}