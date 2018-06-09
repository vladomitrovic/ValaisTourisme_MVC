using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValaisTourisme_MVC.ViewModel
{
    public class CancelVM
    {

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public List<Booking> Booking { get; set; }
        public List<Hotel> Hotel { get; set; }
        public List<Room> Rooms { get; set; }

    }
}