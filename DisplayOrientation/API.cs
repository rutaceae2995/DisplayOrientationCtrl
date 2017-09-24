using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using DisplayOrientationCtrl.Internal;

namespace DisplayOrientationCtrl
{
    /// <summary>
    /// Display orientation API.
    /// </summary>
    public static class API
    {
        /// <summary>
        /// Gets current display device name.
        /// </summary>
        /// <param name="source">Source visual.</param>
        /// <returns>Device name.</returns>
        public static string GetDeviceName(Visual source)
        {
            var hwndSource = PresentationSource.FromVisual(source) as HwndSource;
            if (hwndSource == null)
            {
                return null;
            }

            var monitorInfo = new MONITORINFOEX
            {
                cbSize = (uint) Marshal.SizeOf(typeof(MONITORINFOEX))
            };

            var monitorHandle = NativeMethods.MonitorFromWindow(hwndSource.Handle, MonitorDefaultReturnType.MONITOR_DEFAULTTONEAREST);
            if (!NativeMethods.GetMonitorInfo(monitorHandle, ref monitorInfo))
            {
                return null;
            }

            return monitorInfo.szDevice;
        }

        /// <summary>
        /// Gets orientation of the specific display.
        /// </summary>
        /// <param name="deviceName">Display device name.</param>
        /// <returns>DisplayOrientation. If error, returns null.</returns>
        public static DisplayOrientation? GetCurrentDisplayOrientation(string deviceName)
        {
            var devModeResult = GetDevMode(deviceName);
            if (!devModeResult.HasValue)
            {
                return null;
            }

            return ToDisplayOrientation(devModeResult.Value.dmDisplayOrientation);
        }

        /// <summary>
        /// Gets orientation of the specific display.
        /// </summary>
        /// <param name="displayNumber">Display number (0, 1, 2, ...)</param>
        /// <returns>DisplayOrientation. If error, returns null.</returns>
        public static DisplayOrientation? GetCurrentDisplayOrientation(ushort displayNumber)
        {
            var devModeResult = GetDevMode(displayNumber);
            if (devModeResult == null
                || !devModeResult.Item1.HasValue)
            {
                return null;
            }

            return ToDisplayOrientation(devModeResult.Item1.Value.dmDisplayOrientation);
        }

        /// <summary>
        /// Changes display orientation.
        /// </summary>
        /// <param name="displayDeviceName">Display device name.</param>
        /// <param name="orientation">Orientation.</param>
        /// <returns>Result.</returns>
        public static bool TryChangeOrientation(string displayDeviceName, DisplayOrientation orientation)
        {
            var devModeResult = GetDevMode(displayDeviceName);
            if (!devModeResult.HasValue)
            {
                return false;
            }

            return TryChangeOrientation(displayDeviceName, devModeResult.Value, orientation);
        }

        /// <summary>
        /// Changes display orientation.
        /// </summary>
        /// <param name="displayNumber">Display number (0, 1, 2, ...)</param>
        /// <param name="orientation">Orientation.</param>
        /// <returns>Result.</returns>
        public static bool TryChangeOrientation(ushort displayNumber, DisplayOrientation orientation)
        {
            var devModeResult = GetDevMode(displayNumber);
            if (devModeResult == null
                || !devModeResult.Item1.HasValue)
            {
                return false;
            }

            var devMode = devModeResult.Item1.Value;
            var deviceName = devModeResult.Item2;
            return TryChangeOrientation(deviceName, devMode, orientation);
        }

        /// <summary>
        /// Gets all device names of available displays.
        /// </summary>
        /// <returns>Device names.</returns>
        public static IEnumerable<string> GetAllActiveDisplayNames()
        {
            var displayDevice = new DISPLAY_DEVICE();
            displayDevice.dwSize = Marshal.SizeOf(displayDevice);
            for (ushort i = 0; i < 64; i++)
            {
                if (NativeMethods.EnumDisplayDevices(null, i, ref displayDevice, 0u) &&
                    displayDevice.StateFlags != DisplayDeviceStateFlags.DISPLAY_DEVICE_NONE)
                {
                    yield return displayDevice.DeviceName;
                }
            }
        }

        /// <summary>
        /// Changes display orientation.
        /// </summary>
        /// <param name="deviceName">Display device name.</param>
        /// <param name="devMode">DEVMODE.</param>
        /// <param name="orientation">Orientation.</param>
        /// <returns>Result.</returns>
        private static bool TryChangeOrientation(string deviceName, DEVMODE devMode, DisplayOrientation orientation)
        {
            // Check display orientation.
            // If orientation changed (portrait or landscape), swap width and height.
            var currentDisplayOrientation = devMode.dmDisplayOrientation;
            devMode.dmDisplayOrientation = ToDevModeOrientation(orientation);
            if (currentDisplayOrientation == devMode.dmDisplayOrientation)
            {
                // No change.
                return true;
            }

            var changeWidthHeight = false;
            if (currentDisplayOrientation == DevModeDisplayOrientation.Default
                || currentDisplayOrientation == DevModeDisplayOrientation.Orientation180)
            {
                if (devMode.dmDisplayOrientation == DevModeDisplayOrientation.Orientation270
                    || devMode.dmDisplayOrientation == DevModeDisplayOrientation.Orientation90)
                {
                    changeWidthHeight = true;
                }
            }
            else
            {
                if (devMode.dmDisplayOrientation == DevModeDisplayOrientation.Default
                    || devMode.dmDisplayOrientation == DevModeDisplayOrientation.Orientation180)
                {
                    changeWidthHeight = true;
                }
            }

            if (changeWidthHeight)
            {
                var height = devMode.dmPelsHeight;
                devMode.dmPelsHeight = devMode.dmPelsWidth;
                devMode.dmPelsWidth = height;
            }

            var res = NativeMethods.ChangeDisplaySettingsEx(
                deviceName,
                ref devMode,
                IntPtr.Zero,
                DisplaySettingsFlags.CDS_UPDATEREGISTRY,
                IntPtr.Zero);
            return DISP_CHANGE.DISP_CHANGE_SUCCESSFUL == res;
        }

        /// <summary>
        /// Gets DEVMODE from device name.
        /// </summary>
        /// <param name="deviceName">Device name.</param>
        /// <returns>DEVMODE. If error, returns null.</returns>
        private static DEVMODE? GetDevMode(string deviceName)
        {
            var devMode = new DEVMODE();
            if (0 == NativeMethods.EnumDisplaySettings(
                deviceName,
                (int)EnumDisplayMode.ENUM_CURRENT_SETTINGS,
                ref devMode))
            {
                // Error
                return null;
            }

            return devMode;
        }

        /// <summary>
        /// Gets DEVMODE structure.
        /// </summary>
        /// <param name="displayNumber">Display number (0, 1, 2, ...)</param>
        /// <returns>DEVMODE struct, and deviceName. If error, returns null.</returns>
        private static Tuple<DEVMODE?, string> GetDevMode(ushort displayNumber)
        {
            var displayDevice = new DISPLAY_DEVICE();
            displayDevice.dwSize = Marshal.SizeOf(displayDevice);

            // Obtains information about the display devices in the current session.
            if (!NativeMethods.EnumDisplayDevices(null, displayNumber, ref displayDevice, 0u))
            {
                return null;
            }

            if (displayDevice.StateFlags == DisplayDeviceStateFlags.DISPLAY_DEVICE_NONE)
            {
                // No available
                return null;
            }

            // Retrieves information about one of the graphics modes for a display device.
            var devMode = new DEVMODE();
            if (0 == NativeMethods.EnumDisplaySettings(
                    displayDevice.DeviceName,
                    (int)EnumDisplayMode.ENUM_CURRENT_SETTINGS,
                    ref devMode))
            {
                // Error
                return null;
            }

            return new Tuple<DEVMODE?, string>(devMode, displayDevice.DeviceName);
        }

        /// <summary>
        /// Converts to DevModeDisplayOrientation from DisplayOrientation.
        /// </summary>
        /// <param name="orientation">DisplayOrientation.</param>
        /// <returns>DevModeDisplayOrientation.</returns>
        private static DevModeDisplayOrientation ToDevModeOrientation(DisplayOrientation orientation)
        {
            switch (orientation)
            {
                case DisplayOrientation.Default:
                    return DevModeDisplayOrientation.Default;

                case DisplayOrientation.Rotate90Degrees:
                    return DevModeDisplayOrientation.Orientation90;

                case DisplayOrientation.Rotate180Degrees:
                    return DevModeDisplayOrientation.Orientation180;

                case DisplayOrientation.Rotate270Degrees:
                    return DevModeDisplayOrientation.Orientation270;

                default:
                    throw new ArgumentOutOfRangeException("orientation", orientation, null);
            }
        }

        /// <summary>
        /// Converts to DisplayOrientation from DevModeDisplayOrientation.
        /// </summary>
        /// <param name="orientation">DevModeDisplayOrientation.</param>
        /// <returns>DisplayOrientation.</returns>
        private static DisplayOrientation ToDisplayOrientation(DevModeDisplayOrientation orientation)
        {
            switch (orientation)
            {
                case DevModeDisplayOrientation.Default:
                    return DisplayOrientation.Default;

                case DevModeDisplayOrientation.Orientation90:
                    return DisplayOrientation.Rotate90Degrees;

                case DevModeDisplayOrientation.Orientation180:
                    return DisplayOrientation.Rotate180Degrees;

                case DevModeDisplayOrientation.Orientation270:
                    return DisplayOrientation.Rotate270Degrees;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}