using ColorHelper;
using System;
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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte a = Convert.ToByte(R.Value);
            byte b = Convert.ToByte(G.Value);
            byte c = Convert.ToByte(B.Value);
            byte d = Convert.ToByte(Gen.Value);
            
            frame.Background = new SolidColorBrush(Color.FromArgb(d, a, b, c));
            
            RGB rgb = new RGB(a, b, c);
            label1.Content = rgb;
            HEX hex = ColorHelper.ColorConverter.RgbToHex(rgb);
            label2.Content = "Hex " + hex;
        }
    }
}
