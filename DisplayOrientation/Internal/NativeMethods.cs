using System;
using System.Runtime.InteropServices;

namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// Native Methods.
    /// </summary>
    internal sealed class NativeMethods
    {
        /// <summary>
        /// Changes the settings of the specified display device to the specified graphics mode.
        /// </summary>
        /// <param name="lpszDeviceName">
        /// A pointer to a null-terminated string that specifies the display device whose graphics mode will change.
        /// Only display device names as returned by EnumDisplayDevices are valid.
        /// See EnumDisplayDevices for further information on the names associated with these display devices.
        /// </param>
        /// <param name="lpDevMode">
        /// A pointer to a DEVMODE structure that describes the new graphics mode.
        /// If lpDevMode is NULL, all the values currently in the registry will be used for the display setting.
        /// Passing NULL for the lpDevMode parameter and 0 for the dwFlags parameter is the easiest way to return to the default mode after a dynamic mode change.
        /// </param>
        /// <param name="hwnd">Reserved; must be NULL.</param>
        /// <param name="dwflags">Indicates how the graphics mode should be changed.</param>
        /// <param name="lParam">If dwFlags is CDS_VIDEOPARAMETERS, lParam is a pointer to a VIDEOPARAMETERS structure. Otherwise lParam must be NULL.</param>
        /// <returns>Result.</returns>
        /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd183413(v=vs.85).aspx"/>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern DISP_CHANGE ChangeDisplaySettingsEx(
            string lpszDeviceName,
            ref DEVMODE lpDevMode,
            IntPtr hwnd,
            DisplaySettingsFlags dwflags,
            IntPtr lParam);

        /// <summary>
        /// Obtains information about the display devices in the current session.
        /// </summary>
        /// <param name="lpDevice">A pointer to the device name. If NULL, function returns information for the display adapter(s) on the machine, based on iDevNum.</param>
        /// <param name="iDevNum">An index value that specifies the display device of interest.</param>
        /// <param name="lpDisplayDevice">A pointer to a DISPLAY_DEVICE structure that receives information about the display device specified by iDevNum. </param>
        /// <param name="dwFlags">
        /// Set this flag to EDD_GET_DEVICE_INTERFACE_NAME (0x00000001) to retrieve the device interface name for GUID_DEVINTERFACE_MONITOR, which is registered by the operating system on a per monitor basis.
        /// The value is placed in the DeviceID member of the DISPLAY_DEVICE structure returned in lpDisplayDevice.
        /// The resulting device interface name can be used with SetupAPI functions and serves as a link between GDI monitor devices and SetupAPI monitor devices. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false.
        /// </returns>
        /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd162609(v=vs.85).aspx"/>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumDisplayDevices(
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpDevice,
            uint iDevNum,
            ref DISPLAY_DEVICE lpDisplayDevice,
            uint dwFlags);

        /// <summary>
        /// Retrieves information about one of the graphics modes for a display device.
        /// To retrieve information for all the graphics modes of a display device, make a series of calls to this function.
        /// </summary>
        /// <param name="lpszDeviceName">A pointer to a null-terminated string that specifies the display device about whose graphics mode the function will obtain information.</param>
        /// <param name="iModeNum">The type of information to be retrieved.</param>
        /// <param name="lpDevMode">A pointer to a DEVMODE structure into which the function stores information about the specified graphics mode. Before calling EnumDisplaySettings, set the dmSize member to sizeof(DEVMODE), and set the dmDriverExtra member to indicate the size, in bytes, of the additional space available to receive private driver data.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd162611(v=vs.85).aspx"/>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int EnumDisplaySettings(
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpszDeviceName,
            int iModeNum,
            ref DEVMODE lpDevMode);

        /// <summary>
        /// Retrieves information about one of the graphics modes for a display device.
        /// To retrieve information for all the graphics modes of a display device, make a series of calls to this function.
        /// </summary>
        /// <param name="lpszDeviceName">A pointer to a null-terminated string that specifies the display device about whose graphics mode the function will obtain information.</param>
        /// <param name="iModeNum">The type of information to be retrieved.</param>
        /// <param name="lpDevMode">A pointer to a DEVMODE structure into which the function stores information about the specified graphics mode. Before calling EnumDisplaySettings, set the dmSize member to sizeof(DEVMODE), and set the dmDriverExtra member to indicate the size, in bytes, of the additional space available to receive private driver data.</param>
        /// <param name="dwFlags"></param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false.
        /// </returns>
        /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/cc428509.aspx"/>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumDisplaySettingsEx(
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpszDeviceName,
            int iModeNum,
            ref DEVMODE lpDevMode,
            DisplaySettingsExEnum dwFlags);

        /// <summary>
        /// Retrieves a handle to the display monitor that has the largest area of intersection with the bounding rectangle of a specified window.
        /// </summary>
        /// <param name="hwnd">A handle to the window of interest.</param>
        /// <param name="dwFlags">Determines the function's return value if the window does not intersect any display monitor.</param>
        /// <returns></returns>
        /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd145064%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396"/>
        [DllImport("User32.dll")]
        public static extern IntPtr MonitorFromWindow(
            IntPtr hwnd,
            MonitorDefaultReturnType dwFlags);

        /// <summary>
        /// Retrieves information about a display monitor.
        /// </summary>
        /// <param name="hMonitor">A handle to the display monitor of interest.</param>
        /// <param name="lpmi">A pointer to a MONITORINFOEX structure that receives information about the specified display monitor.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorInfo(
            IntPtr hMonitor,
            ref MONITORINFOEX lpmi);
    }
}