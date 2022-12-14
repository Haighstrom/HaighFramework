namespace HaighFramework.Input;

public interface IMouse
{
    /// <summary>
    /// The X position of the mouse cursor on the application window's client area (ignoring borders and title bar).
    /// </summary>
    int ClientX { get; }

    /// <summary>
    /// The Y position of the mouse cursor on the application window's client area (ignoring borders and title bar).
    /// </summary>
    int ClientY { get; }

    /// <summary>
    /// X position of the mouse on the overall desktop (may return negative or large values for multiple desktop setups).
    /// </summary>
    int DesktopX { get; }

    /// <summary>
    /// Y position of the mouse on the overall desktop (may return negative or large values for multiple desktop setups).
    /// </summary>
    int DesktopY { get; }

    /// <summary>
    /// The current position of the mouse wheel.
    /// </summary>
    float WheelScroll { get; }

    /// <summary>
    /// The X position of the mouse cursor on the current screen.
    /// </summary>
    int ScreenX { get; }

    /// <summary>
    /// The Y position of the mouse cursor on the current screen.
    /// </summary>
    int ScreenY { get; }

    /// <summary>
    /// The X position of the mouse cursor on the application window (including borders and title bar).
    /// </summary>
    int WindowX { get; }

    /// <summary>
    /// The Y position of the mouse cursor on the application window (including borders and title bar).
    /// </summary>
    int WindowY { get; }

    /// <summary>
    /// Whether a specified mouse button is currently pressed down.
    /// </summary>
    /// <param name="button">The button to query.</param>
    /// <returns>Returns true if the mouse button is currently pressed down, false if it is up.</returns>
    bool IsDown(MouseButton button);
}