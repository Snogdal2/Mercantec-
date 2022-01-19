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
using WpfBooking.ServiceReference1;
using WpfBooking;

namespace WpfBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        BookingItem[] bookings = new BookingItem[12];

        Service1Client client = new Service1Client();

        public MainWindow()
        {
            InitializeComponent();

            client.CreateBookingNumber(2999, 12);
            bookings = client.GetBookingItems(2999);
            int i = 0;
            int te = 1;

            while (i < bookings.Length) {

                Image img = (Image)this.FindName("image" + te);

                if (bookings[i].State == 0)
                {
                    img.Source = new BitmapImage(new Uri(@"images/SeatOpen.png", UriKind.RelativeOrAbsolute));
                }
                else if (bookings[i].State == 1)
                {
                    img.Source = new BitmapImage(new Uri(@"images/SeatClose.png", UriKind.RelativeOrAbsolute));
                }
                te++;
                i++;
            }
        }
        
        
        private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 0;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);               
        }

        private void Image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 1;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 2;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 3;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 4;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 5;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 6;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 7;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 8;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 9;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 10;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 11;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }
        private void changeTilstandAndImage(int pos, Image img)
        {            
            if (bookings[pos].State == 0)
            {
                img.Source = new BitmapImage(new Uri(@"images/SeatClose.png", UriKind.RelativeOrAbsolute));
                bookings[pos].State = 1;
            }
            else if (bookings[pos].State == 1)
            {
                img.Source = new BitmapImage(new Uri(@"images/SeatOpen.png", UriKind.RelativeOrAbsolute));
                bookings[pos].State = 0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.SetBookingItems(2999, bookings);
        }
    }
}
