﻿namespace DisplayOrientationCtrl.Internal
{
    /// <summary>
    /// Members of the DEVMODE structure.
    /// </summary>
    /// <see cref="!:https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd183565(v=vs.85).aspx"/>
    [System.Flags]
    internal enum DM
    {
        /// <summary>
        /// dmOrientation.
        /// </summary>
        DM_ORIENTATION = 0x00000001,

        /// <summary>
        /// dmPaperSize.
        /// </summary>
        DM_PAPERSIZE = 0x00000002,

        /// <summary>
        /// dmPaperLength.
        /// </summary>
        DM_PAPERLENGTH = 0x00000004,

        /// <summary>
        /// dmPaperWidth.
        /// </summary>
        DM_PAPERWIDTH = 0x00000008,

        /// <summary>
        /// dmScale.
        /// </summary>
        DM_SCALE = 0x00000010,

        /// <summary>
        /// dmPosition.
        /// </summary>
        DM_POSITION = 0x00000020,

        /// <summary>
        /// dmNup.
        /// </summary>
        DM_NUP = 0x00000040,

        /// <summary>
        /// dmDisplayOrientation.
        /// </summary>
        DM_DISPLAYORIENTATION = 0x00000080,

        /// <summary>
        /// dmCopies
        /// </summary>
        DM_COPIES = 0x00000100,

        /// <summary>
        /// dmDefaultSource.
        /// </summary>
        DM_DEFAULTSOURCE = 0x00000200,

        /// <summary>
        /// dmPrintQuality.
        /// </summary>
        DM_PRINTQUALITY = 0x00000400,

        /// <summary>
        /// dmColor.
        /// </summary>
        DM_COLOR = 0x00000800,

        /// <summary>
        /// dmDuplex.
        /// </summary>
        DM_DUPLEX = 0x00001000,

        /// <summary>
        /// dmYResolution.
        /// </summary>
        DM_YRESOLUTION = 0x00002000,

        /// <summary>
        /// dmTTOption.
        /// </summary>
        DM_TTOPTION = 0x00004000,

        /// <summary>
        /// dmCollate.
        /// </summary>
        DM_COLLATE = 0x00008000,

        /// <summary>
        /// dmFormName.
        /// </summary>
        DM_FORMNAME = 0x00010000,

        /// <summary>
        /// dmLogPixels.
        /// </summary>
        DM_LOGPIXELS = 0x00020000,

        /// <summary>
        /// dmBitsPerPixel.
        /// </summary>
        DM_BITSPERPIXEL = 0x00040000,

        /// <summary>
        /// dmPelsWidth.
        /// </summary>
        DM_PELSWIDTH = 0x00080000,

        /// <summary>
        /// dmPelsHeight.
        /// </summary>
        DM_PELSHEIGHT = 0x00100000,

        /// <summary>
        /// dmDisplayFlags.
        /// </summary>
        DM_DISPLAYFLAGS = 0x00200000,

        /// <summary>
        /// dmDisplayFrequency.
        /// </summary>
        DM_DISPLAYFREQUENCY = 0x00400000,

        /// <summary>
        /// dmICMMethod.
        /// </summary>
        DM_ICMMETHOD = 0x00800000,

        /// <summary>
        /// dmICMIntent.
        /// </summary>
        DM_ICMINTENT = 0x01000000,

        /// <summary>
        /// dmMediaType.
        /// </summary>
        DM_MEDIATYPE = 0x02000000,

        /// <summary>
        /// dmDitherType.
        /// </summary>
        DM_DITHERTYPE = 0x04000000,

        /// <summary>
        /// dmPanningWidth.
        /// </summary>
        DM_PANNINGWIDTH = 0x08000000,

        /// <summary>
        /// dmPanningHeight.
        /// </summary>
        DM_PANNINGHEIGHT = 0x10000000,

        /// <summary>
        /// dmDisplayFixedOutput.
        /// </summary>
        DM_DISPLAYFIXEDOUTPUT = 0x20000000
    }
}