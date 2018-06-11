using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HotelManager
    {
        //No changes
        public static List<Hotel> GetAll()
        {
            return DAL.HotelREST.GetAll();
        }

        //No changes
        public static Hotel Getid(int id)
        {
            return DAL.HotelREST.Getid(id);
        }

    }
}
