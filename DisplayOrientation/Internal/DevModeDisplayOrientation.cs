namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// dmDisplayOrientation value of the DEVMODE struct.
    /// </summary>
    internal enum DevModeDisplayOrientation
    {
        /// <summary>
        /// Default(0 degrees).
        /// </summary>
        Default = 0,

        /// <summary>
        /// 90 degrees.
        /// </summary>
        Orientation90 = 1,

        /// <summary>
        /// 180 degrees.
        /// </summary>
        Orientation180 = 2,

        /// <summary>
        /// 270 degrees.
        /// </summary>
        Orientation270 = 3
    }
}