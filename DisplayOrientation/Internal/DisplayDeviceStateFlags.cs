namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// Device state flags.
    /// </summary>
    /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd183569(v=vs.85).aspx"/>
    [System.Flags]
    internal enum DisplayDeviceStateFlags
    {
        /// <summary>
        /// None.
        /// </summary>
        DISPLAY_DEVICE_NONE = 0x00,

        /// <summary>
        /// DISPLAY_DEVICE_ACTIVE specifies whether a monitor is presented as being "on" by the respective GDI view.
        /// </summary>
        DISPLAY_DEVICE_ACTIVE = 0x1,

        /// <summary>
        /// MultiDeiver.
        /// </summary>
        DISPLAY_DEVICE_MULTIDRIVER = 0x2,

        /// <summary>
        /// The primary desktop is on the device. For a system with a single display card, this is always set. For a system with multiple display cards, only one device can have this set.
        /// </summary>
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x4,

        /// <summary>
        /// Represents a pseudo device used to mirror application drawing for remoting or other purposes.
        /// An invisible pseudo monitor is associated with this device.
        /// For example, NetMeeting uses it.
        /// Note that GetSystemMetrics (SM_MONITORS) only accounts for visible display monitors.
        /// </summary>
        DISPLAY_DEVICE_MIRRORINGDRIVER = 0x8,

        /// <summary>
        /// The device is VGA compatible.
        /// </summary>
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x10,

        /// <summary>
        /// The device is removable; it cannot be the primary display.
        /// </summary>
        DISPLAY_DEVICE_REMOVABLE = 0x20,

        /// <summary>
        /// The device has more display modes than its output devices support.
        /// </summary>
        DISPLAY_DEVICE_MODESPRUNED = 0x8000000,

        /// <summary>
        /// Remote.
        /// </summary>
        DISPLAY_DEVICE_Remote = 0x4000000,

        /// <summary>
        /// Disconnect.
        /// </summary>
        DISPLAY_DEVICE_Disconnect = 0x2000000
    }
}