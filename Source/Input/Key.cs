﻿namespace HaighFramework.Input
{
    public enum Key : int
    {
        Unknown = 0,
        None = 0,

        ESC,
        Enter,
        Space,
        Tab,
        Backspace,
        Delete,
        PrintScreen,
        Insert,
        PageUp,
        PageDown,
        Home,
        End,
        CapsLock,
        ScrollLock,
        NumLock, 

        #region Modifiers
        LeftControl,
        RightControl,
        LeftShift,
        RightShift,
        LeftAlt,
        RightAlt,
        #endregion

        #region F-Keys
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        #endregion

        #region Numbers
        Num1,
        Num2,
        Num3,
        Num4,
        Num5,
        Num6,
        Num7,
        Num8,
        Num9,
        Num0,
        #endregion

        #region Keypad
        Keypad0,
        Keypad1,
        Keypad2,
        Keypad3,
        Keypad4,
        Keypad5,
        Keypad6,
        Keypad7,
        Keypad8,
        Keypad9,
        KeypadDivide,
        KeypadMultiply,
        KeypadSubtract,
        KeypadAdd,
        KeypadPeriod,
        KeypadEnter,
        #endregion

        #region Letters
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        #endregion

        #region Arrow keys
        Up,
        Down,
        Left,
        Right,
        #endregion

        #region Windows Keys
        LeftWindows,
        Menu,
        #endregion

        #region Symbol Keys
        Minus,
        Equals,
        LeftBracket,
        RightBracket,
        Semicolon,
        Quote,
        Comma,
        Period,
        Slash,
        BackSlash,
        Hash,
        Pause,
        GraveAccent,
        #endregion
        
        LastKey            
    }

    public static class KeyExtensions
    {
        /// <summary>
        /// Extension method for Key to get the official Windows readable string for the key. May not handle Left/Right shift properly because eat a dick Bill Gates
        /// </summary>
        public static string ToWindowsString(this Key k)
        {
            //Handle wierd cases
            switch (k)
            {
                case (Key.Pause): return "Pause/Break";
                case (Key.PrintScreen): return "Print screen";
                case (Key.RightShift): return "RIGHT SHIFT";
            }


            return Win32API.User32.GetKeyNameText(KeyMap.GetExtendedScanCodeFromKey(k));
        }
    }
}