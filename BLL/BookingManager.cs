using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingManager
    {

        public static List<Booking> GetBooking(String firstname, String lastname)
        {
            return DAL.BookingREST.GetBooking(firstname, lastname);
        }

        public static bool PostNewBooking(Booking b)
        {
            return DAL.BookingREST.PostNewBooking(b);
        }

        public static bool DeleteBooking(int idBook)
        {
            return DAL.BookingREST.DeleteBooking(idBook);
        }

    }
}
