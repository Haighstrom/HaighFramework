﻿namespace HaighFramework.Input;

public class MouseState
{
    internal readonly Dictionary<MouseButton, bool> ButtonsDown = new()
    {
        { MouseButton.Left, false },
        { MouseButton.Middle, false },
        { MouseButton.Right, false },
        { MouseButton.Mouse4, false },
        { MouseButton.Mouse5, false },
    };
    
    internal bool IsConnected { get; set; }

    /// <summary>
    /// The X position of the mouse cursor, relative to the top left of the primary monitor.
    /// </summary>
    public int ScreenX { get; internal set; }

    /// <summary>
    /// The Y position of the mouse cursor, relative to the top left of the primary monitor.
    /// </summary>
    public int ScreenY { get; internal set; }

    /// <summary>
    /// The absolute wheel scroll position. Increases as the wheel is rolled forward, and reduces as the wheel is rolled back.
    /// </summary>
    public float WheelY { get; internal set; }

    internal void SetButton(MouseButton button, bool isDown)
    {
        ButtonsDown[button] = isDown;
    }

    /// <summary>
    /// Checks if a specified mouse button is currently pressed down.
    /// </summary>
    /// <param name="button">The button to query.</param>
    /// <returns>Returns true if the mouse button is currently pressed down, false if it is up.</returns>
    public bool IsDown(MouseButton button)
    {
        return ButtonsDown[button];
    }

    public override string ToString()
    {
        return 
            $"Mouse State:\n" +
            $"  Position: Screen:({ScreenX},{ScreenY})\n" +
            $"  Buttons: L:{(ButtonsDown[MouseButton.Left] ? "Y" : "N")}, M:{(ButtonsDown[MouseButton.Middle] ? "Y" : "N")}, R:{(ButtonsDown[MouseButton.Right] ? "Y" : "N")}, M4:{(ButtonsDown[MouseButton.Mouse4] ? "Y" : "N")}, M5:{(ButtonsDown[MouseButton.Mouse5] ? "Y" : "N")}\n" +
            $"  Wheel Position: {WheelY}";
    }
}
