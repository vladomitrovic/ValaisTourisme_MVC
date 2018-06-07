using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValaisTourisme_MVC.ViewModel
{
    public class ReserveVM
    {
        public List<string> Locations { get; set; }

        public string Location { get; set; }

        public int days { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }

        public bool HasWifi { get; set; }

        public bool HasParking { get; set; }

        public bool HasTV { get; set; }

        public bool HasHairDryer { get; set; }

        public List<Hotel> Hotels { get; set; }

        public List<Picture> Images { get; set; }

        public Hotel Hotel { get; set; }

        public List<Room> Rooms { get; set; }
        public decimal TotalPrice { get; set; }
        public int nbPerson { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int MinCategory { get; set; }
        public int MaxCategory { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}