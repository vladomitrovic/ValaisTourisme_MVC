using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomManager
    {
        //Sort the rooms with advanced search
        public static List<Room> GetSearch(String city, DateTime cin, DateTime cout, bool hairDryer, bool tv, bool parking, bool wifi, decimal minPrice, decimal maxPrice, int minCat, int maxCat)
        {

            List<Room> rooms = DAL.RoomREST.GetSearch(city, cin, cout).Where(r => r.Price >= minPrice && r.Price <= maxPrice && r.Hotel.Category >= minCat && r.Hotel.Category <= maxCat).ToList();

            if (hairDryer)
                rooms = rooms.Where(r => r.HasHairDryer == hairDryer).ToList();

            if (tv)
                rooms = rooms.Where(r => r.HasTV == tv).ToList();

            if (parking)
                rooms = rooms.Where(r => r.Hotel.HasParking == parking).ToList();

            if (wifi)
                rooms = rooms.Where(r => r.Hotel.HasWifi == wifi).ToList();

            return rooms;
        }

        //No changes
        public static Room Getid(int id)
        {
            return DAL.RoomREST.Getid(id);
        }

    }
}
