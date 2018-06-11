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
        //No changes
        public static List<Booking> GetBooking(String firstname, String lastname)
        {
            return DAL.BookingREST.GetBooking(firstname, lastname);
        }

        //No changes
        public static bool PostNewBooking(Booking b)
        {
            return DAL.BookingREST.PostNewBooking(b);
        }

        //No changes
        public static bool DeleteBooking(int idBook)
        {
            return DAL.BookingREST.DeleteBooking(idBook);
        }

    }
}
