﻿using System.Runtime.InteropServices;

namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// Information about a display monitor.
    /// </summary>
    /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd145066(v=vs.85).aspx"/>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct MONITORINFOEX
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates.
        /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        /// </summary>
        public RECT rcMonitor;

        /// <summary>
        /// A RECT structure that specifies the work area rectangle of the display monitor that can be used by applications, expressed in virtual-screen coordinates.
        /// Windows uses this rectangle to maximize an application on the monitor.
        /// The rest of the area in rcMonitor contains system windows such as the task bar and side bars.
        /// Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        /// </summary>
        public RECT rcWork;

        /// <summary>
        /// The attributes of the display monitor.
        /// </summary>
        public uint dwFlags;

        /// <summary>
        /// A string that specifies the device name of the monitor being used.
        /// Most applications have no use for a display monitor name, and so can save some bytes by using a MONITORINFO structure
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szDevice;
    }
}
