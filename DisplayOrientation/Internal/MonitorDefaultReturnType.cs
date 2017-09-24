namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// MonitorFromWindow's return value if the window does not intersect any display monitor.
    /// </summary>
    /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd145064%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396"/>
    public enum MonitorDefaultReturnType : uint
    {
        /// <summary>
        /// Returns NULL.
        /// </summary>
        MONITOR_DEFAULTTONULL = 0x00000000,

        /// <summary>
        /// Returns a handle to the primary display monitor.
        /// </summary>
        MONITOR_DEFAULTTOPRIMARY = 0x00000001,

        /// <summary>
        /// Returns a handle to the display monitor that is nearest to the window.
        /// </summary>
        MONITOR_DEFAULTTONEAREST = 0x00000002,
    }
}