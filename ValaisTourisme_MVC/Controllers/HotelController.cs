using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;

namespace ValaisTourisme_MVC.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            List<Hotel> hotels = HotelManager.GetAll();
            return View(hotels);
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            Hotel hotel = HotelManager.Getid(id);
            return View(hotel);
        }


    }
}
