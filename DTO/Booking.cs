﻿
namespace DTO
{
    using System;
    using System.Collections.Generic;

    public partial class Booking
    {
        public int IdBooking { get; set; }
        public System.DateTime CheckIn { get; set; }
        public System.DateTime CheckOut { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Date { get; set; }
        public int IdRoom { get; set; }

        public virtual Room Room { get; set; }
    }
}
