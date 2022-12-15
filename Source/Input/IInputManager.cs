namespace HaighFramework.Input;

public interface IInputManager : IDisposable
{
    MouseState MouseState { get; }
    KeyboardState KeyboardState { get; }
}
