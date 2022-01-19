using System;
using ColorHelper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{

    public partial class Page1 : Page
    {
        int valueFromPage1;
        public Page1()
        {
            InitializeComponent();
        }
        public Page1(int val) : this()
        {
            valueFromPage1 = val;
            this.Loaded += new RoutedEventHandler(Page2_Loaded);

        }
        void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            jeg.Content = "Value passed from page1 is: " + valueFromPage1;
        }

        public void farve()
        {
            BitmapSource visual_BitmapSource = get_BitmapSource_of_Element(farveplatte);

            CroppedBitmap cb = new CroppedBitmap(visual_BitmapSource, new Int32Rect((int)Mouse.GetPosition(farveplatte).X, (int)Mouse.GetPosition(farveplatte).Y, 1, 1));

            byte[] pixels = new byte[4];

            try

            {
                cb.CopyPixels(pixels, 4, 0);
            }

            catch (Exception)

            {
                //error
            }

            frame.Background = new SolidColorBrush(Color.FromRgb(pixels[2], pixels[1], pixels[0]));

            RGB rgb = new RGB(pixels[2], pixels[1], pixels[0]);
            RGB.Content = rgb;
            HEX hex = ColorHelper.ColorConverter.RgbToHex(rgb);
            HEX.Content = "Hex " + hex;

            sliderR.Value = pixels[2];
            sliderG.Value = pixels[1];
            sliderB.Value = pixels[0];
        }

        public BitmapSource get_BitmapSource_of_Element(FrameworkElement element)

        {

            if (element == null) { return null; }

            double dpi = 96;

            Double width = element.ActualWidth;

            Double height = element.ActualHeight;


            RenderTargetBitmap bitmap_of_Element = null;

            if (bitmap_of_Element == null)

            {

                try

                {
                    bitmap_of_Element = new RenderTargetBitmap((int)width, (int)height, dpi, dpi, PixelFormats.Default);

                    DrawingVisual visual_area = new DrawingVisual();

                    using (DrawingContext dc = visual_area.RenderOpen())

                    {
                        VisualBrush visual_brush = new VisualBrush(element);

                        dc.DrawRectangle(visual_brush, null, new Rect(new Point(), new Size(width, height)));

                    }

                    bitmap_of_Element.Render(visual_area);

                }

                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }

            }

            return bitmap_of_Element;

        }

        private void farveplatte_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            farve();
           
        }

        private void sliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte a = Convert.ToByte(sliderR.Value);
            byte b = Convert.ToByte(sliderG.Value);
            byte c = Convert.ToByte(sliderB.Value);


            frame.Background = new SolidColorBrush(Color.FromRgb(a, b, c));

            RGB rgb = new RGB(a, b, c);
            RGB.Content = rgb;
            HEX hex = ColorHelper.ColorConverter.RgbToHex(rgb);
            HEX.Content = "Hex " + hex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frameCopy.Background = frame.Background;
        }
    }

}

