using DisplayOrientationCtrl;

namespace ScreenRotateApp
{
    public partial class MainWindow : System.Windows.Window
    {
        /// <summary>
        /// Set a target display number.
        /// </summary>
        private const ushort DisplayNumber = 0;

        private DisplayOrientation currentOrientation;

        public MainWindow()
        {
            this.InitializeComponent();
            var orientation = API.GetCurrentDisplayOrientation(DisplayNumber);
            if (!orientation.HasValue)
            {
                System.Windows.MessageBox.Show(string.Format("Display number {0} is not available.", DisplayNumber), "Error");
                System.Environment.Exit(0);
            }

            this.currentOrientation = orientation.Value;
        }

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);

            if (this.currentOrientation != DisplayOrientation.Default)
            {
                API.TryChangeOrientation(DisplayNumber, DisplayOrientation.Default);
            }
        }

        private void OnClick0Degrees(object sender, System.Windows.RoutedEventArgs e)
        {
            if (API.TryChangeOrientation(DisplayNumber, DisplayOrientation.Default))
            {
                this.currentOrientation = DisplayOrientation.Default;
            }
        }

        private void OnClick90Degrees(object sender, System.Windows.RoutedEventArgs e)
        {
            if (API.TryChangeOrientation(DisplayNumber, DisplayOrientation.Rotate90Degrees))
            {
                this.currentOrientation = DisplayOrientation.Rotate90Degrees;
            }
        }

        private void OnClick180Degrees(object sender, System.Windows.RoutedEventArgs e)
        {
            if (API.TryChangeOrientation(DisplayNumber, DisplayOrientation.Rotate180Degrees))
            {
                this.currentOrientation = DisplayOrientation.Rotate180Degrees;
            }
        }

        private void OnClick270Degrees(object sender, System.Windows.RoutedEventArgs e)
        {
            if (API.TryChangeOrientation(DisplayNumber, DisplayOrientation.Rotate270Degrees))
            {
                this.currentOrientation = DisplayOrientation.Rotate270Degrees;
            }
        }
    }
}