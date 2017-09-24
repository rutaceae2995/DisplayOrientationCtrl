namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// Indicates how the graphics mode should be changed.
    /// </summary>
    /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd183413(v=vs.85).aspx"/>
    /// <see cref="!:http://www.pinvoke.net/default.aspx/user32/ChangeDisplaySettingsFlags.html"/>
    [System.Flags]
    internal enum DisplaySettingsFlags
    {
        /// <summary>
        /// The graphics mode for the current screen will be changed dynamically.
        /// </summary>
        CDS_NONE = 0,

        /// <summary>
        /// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry.
        /// The mode information is stored in the USER profile.
        /// </summary>
        CDS_UPDATEREGISTRY = 1,

        /// <summary>
        /// The system tests if the requested graphics mode could be set.
        /// </summary>
        CDS_TEST = 2,

        /// <summary>
        /// The mode is temporary in nature. 
        /// If you change to and from another desktop, this mode will not be reset.
        /// </summary>
        CDS_FULLSCREEN = 4,

        /// <summary>
        /// The settings will be saved in the global settings area so that they will affect all users on the machine.
        /// Otherwise, only the settings for the user are modified.
        /// This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
        /// </summary>
        CDS_GLOBAL = 8,

        /// <summary>
        /// This device will become the primary device.
        /// </summary>
        CDS_SET_PRIMARY = 0x10,

        /// <summary>
        /// Video parameters.
        /// </summary>
        CDS_VIDEOPARAMETERS = 0x20,

        /// <summary>
        /// Enable unsafe modes.
        /// </summary>
        CDS_ENABLE_UNSAFE_MODES = 0x100,

        /// <summary>
        /// Disable unsafe modes.
        /// </summary>
        CDS_DISABLE_UNSAFE_MODES = 0x200,

        /// <summary>
        /// The settings should be changed, even if the requested settings are the same as the current settings.
        /// </summary>
        CDS_RESET = 0x40000000,

        /// <summary>
        /// Reset.
        /// </summary>
        CDS_RESET_EX = 0x20000000,

        /// <summary>
        /// The settings will be saved in the registry, but will not take effect.
        /// This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
        /// </summary>
        CDS_NORESET = 0x10000000
    }
}