using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookingAssignment3.ServiceReference1;
using Newtonsoft.Json;
namespace BookingAssignment3
{
    public partial class AjaxReceiver : System.Web.UI.Page
    {
       static Service1Client client = new Service1Client();
       static BookingItem[] bookings;



        [WebMethod]
        public static string help()
        {
            return "help";
        }

        public BookingItem[] GetBookings()
        {

            bool created = client.CreateBookingNumber(666, 9);
            bookings = client.GetBookingItems(666);

            if (created)
            {
                for (int i = 0; i < bookings.Length; i++)
                {
                    bookings[i].Name = $"Button{ i + 1 }";
                }
                client.SetBookingItems(666, bookings);
            }
            return bookings;

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string SerializeBookings()
        {
            return JsonConvert.SerializeObject(GetBookings());
        }

        [WebMethod]
        public string SetBooking(string name)
        {
            return "ass";
        //    var bookings = GetBookings();
        //    foreach (var booking in bookings)
        //    {
        //        if (booking.Name == name) {
        //            if (booking.State == 0)
        //            {
        //                booking.State = 1;
        //            }
        //            else {
        //                booking.State = 0;
        //            }
        //            client.SetBookingItems(666, bookings);
        //            return booking.State.ToString();
        //        }
        //    }
        //    return "";
        }


    }
}