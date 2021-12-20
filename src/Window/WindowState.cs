﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaighFramework.Window
{
    /// <summary>
    /// Enumerates available window states - Fullscreen, windowed, maximised, minimised.
    /// </summary>
    public enum WindowState
    {
        /// <summary>
        /// The window is in its normal state.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// The window is minimized to the taskbar (also known as 'iconified').
        /// </summary>
        Minimized,
        /// <summary>
        /// The window covers the whole working area, which includes the desktop but not the taskbar and/or panels.
        /// </summary>
        Maximized,
        /// <summary>
        /// The window covers the whole screen, including all taskbars and/or panels.
        /// </summary>
        Fullscreen
    }
}
