using System.Runtime.InteropServices;

namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// The DEVMODE data structure contains information about the initialization and environment of a printer or a display device. 
    /// <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd183565(v=vs.85).aspx">MSDN</a>
    /// <a href="https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/NativeMethods.cs,478d6b005e9903a6,references">Reference Source</a>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct DEVMODE
    {
        /// <summary>
        /// A zero-terminated character array that specifies the "friendly" name of the printer or display;
        /// for example, "PCL/HP LaserJet" in the case of PCL/HP LaserJet. This string is unique among device drivers.
        /// Note that this name may be truncated to fit in the dmDeviceName array. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;

        /// <summary>
        /// The version number of the initialization data specification on which the structure is based.
        /// To ensure the correct version is used for any operating system, use DM_SPECVERSION.
        /// </summary>
        public ushort dmSpecVersion;

        /// <summary>
        /// The driver version number assigned by the driver developer.
        /// </summary>
        public ushort dmDriverVersion;

        /// <summary>
        /// Specifies the size, in bytes, of the DEVMODE structure, not including any private driver-specific data that might follow the structure's public members.
        /// Set this member to sizeof (DEVMODE) to indicate the version of the DEVMODE structure being used.
        /// </summary>
        public ushort dmSize;

        /// <summary>
        /// Contains the number of bytes of private driver-data that follow this structure.
        /// If a device driver does not use device-specific information, set this member to zero.
        /// </summary>
        public ushort dmDriverExtra;

        /// <summary>
        /// Specifies whether certain members of the DEVMODE structure have been initialized. If a member is initialized, its corresponding bit is set, otherwise the bit is clear.
        /// A driver supports only those DEVMODE members that are appropriate for the printer or display technology.
        /// </summary>
        public int dmFields;

        /// <summary>
        /// Indicates the positional coordinates of the display device in reference to the desktop area.
        /// The horizontal(x) coordinate of the point.
        /// </summary>
        public int dmPositionX;

        /// <summary>
        /// Indicates the positional coordinates of the display device in reference to the desktop area.
        /// The vertical (y) coordinate of the point.
        /// </summary>
        public int dmPositionY;

        /// <summary>
        /// For display devices only, the orientation at which images should be presented. If DM_DISPLAYORIENTATION is not set, this member must be zero.
        /// To determine whether the display orientation is portrait or landscape orientation, check the ratio of dmPelsWidth to dmPelsHeight.
        /// </summary>
        public DevModeDisplayOrientation dmDisplayOrientation;

        /// <summary>
        /// For fixed-resolution display devices only, how the display presents a low-resolution mode on a higher-resolution display.
        /// For example, if a display device's resolution is fixed at 1024 x 768 pixels but its mode is set to 640 x 480 pixels, the device can either display a 640 x 480 image somewhere in the interior of the 1024 x 768 screen space or stretch the 640 x 480 image to fill the larger screen space.
        /// If DM_DISPLAYFIXEDOUTPUT is not set, this member must be zero.
        /// </summary>
        public int dmDisplayFixedOutput;

        //// ---- ----

        /// <summary>
        /// Switches between color and monochrome on color printers.
        /// The following are the possible values:
        /// - DMCOLOR_COLOR
        /// - DMCOLOR_MONOCHROME
        /// </summary>
        public short dmColor;

        /// <summary>
        /// Selects duplex or double-sided printing for printers capable of duplex printing.
        /// </summary>
        public short dmDuplex;

        /// <summary>
        /// Specifies the y-resolution, in dots per inch, of the printer.
        /// If the printer initializes this member, the dmPrintQuality member specifies the x-resolution, in dots per inch, of the printer.
        /// </summary>
        public short dmYResolution;

        /// <summary>
        /// Specifies how TrueType fonts should be printed.
        /// </summary>
        public short dmTTOption;

        /// <summary>
        /// Specifies whether collation should be used when printing multiple copies.
        /// (This member is ignored unless the printer driver indicates support for collation by setting the dmFields member to DM_COLLATE.)
        /// </summary>
        public short dmCollate;

        /// <summary>
        /// A zero-terminated character array that specifies the name of the form to use; for example, "Letter" or "Legal".
        /// A complete set of names can be retrieved by using the EnumForms function.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;

        /// <summary>
        /// The number of pixels per logical inch. Printer drivers do not use this member.
        /// </summary>
        public ushort dmLogPixels;

        /// <summary>
        /// Specifies the color resolution, in bits per pixel, of the display device (for example: 4 bits for 16 colors, 8 bits for 256 colors, or 16 bits for 65,536 colors).
        /// Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmBitsPerPel;

        /// <summary>
        /// Specifies the width, in pixels, of the visible device surface.
        /// Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmPelsWidth;

        /// <summary>
        /// Specifies the height, in pixels, of the visible device surface.
        /// Display drivers use this member, for example, in the ChangeDisplaySettings function.
        /// Printer drivers do not use this member. 
        /// </summary>
        public int dmPelsHeight;

        /// <summary>
        /// Specifies the device's display mode. This member can be a combination of the following values.
        /// - DM_GRAYSCALE  : Specifies that the display is a noncolor device. If this flag is not set, color is assumed.
        /// - DM_INTERLACED : Specifies that the display mode is interlaced. If the flag is not set, noninterlaced is assumed.
        /// Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        public int dmDisplayFlags;

        /// <summary>
        /// Specifies the frequency, in hertz (cycles per second), of the display device in a particular mode.
        /// This value is also known as the display device's vertical refresh rate. Display drivers use this member. It is used, for example, in the ChangeDisplaySettings function.
        /// Printer drivers do not use this member.
        /// </summary>
        public int dmDisplayFrequency;

        /// <summary>
        /// Specifies how ICM is handled. For a non-ICM application, this member determines if ICM is enabled or disabled.
        /// For ICM applications, the system examines this member to determine how to handle ICM support.
        /// </summary>
        public int dmICMMethod;

        /// <summary>
        /// Specifies which color matching method, or intent, should be used by default. This member is primarily for non-ICM applications.
        /// ICM applications can establish intents by using the ICM functions.
        /// </summary>
        public int dmICMIntent;

        /// <summary>
        /// Specifies the type of media being printed on.
        /// </summary>
        public int dmMediaType;

        /// <summary>
        /// Specifies how dithering is to be done.
        /// </summary>
        public int dmDitherType;

        /// <summary>
        /// This member must be zero.
        /// </summary>
        public int dmICCManufacturer;

        /// <summary>
        /// This member must be zero.
        /// </summary>
        public int dmICCModel;

        /// <summary>
        /// This member must be zero.
        /// </summary>
        public int dmPanningWidth;

        /// <summary>
        /// This member must be zero.
        /// </summary>
        public int dmPanningHeight;
    }
}