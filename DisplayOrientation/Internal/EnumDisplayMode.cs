namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// Mode of EnumDisplaySettings.
    /// </summary>
    internal enum EnumDisplayMode
    {
        /// <summary>
        /// Retrieve the settings for the display device that are currently stored in the registry.
        /// </summary>
        ENUM_REGISTRY_SETTINGS = -2,

        /// <summary>
        /// Retrieve the current settings for the display device.
        /// </summary>
        ENUM_CURRENT_SETTINGS = -1

        //// Or 0, 1, 2, ...
        //// is draphics mode index.
    }
}