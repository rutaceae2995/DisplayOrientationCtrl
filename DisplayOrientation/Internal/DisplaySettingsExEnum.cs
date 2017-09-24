namespace DisplayOrientationCtrl.Internal
{
    [System.Flags]
    internal enum DisplaySettingsExEnum : uint
    {
        /// <summary>
        /// If set, the function will return all graphics modes reported by the adapter driver, regardless of monitor capabilities.
        /// Otherwise, it will only return modes that are compatible with current monitors.
        /// </summary>
        EDS_RAWMODE = 0x02,

        /// <summary>
        /// If set, the function will return graphics modes in all orientations.
        /// Otherwise, it will only return modes that have the same orientation as the one currently set for the requested display.
        /// </summary>
        EDS_ROTATEDMODE = 0x04
    }
}