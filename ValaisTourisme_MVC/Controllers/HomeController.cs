using ValaisTourisme_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace ValaisTourisme_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
        
            ReserveVM ReserveVM = new ReserveVM();
            ReserveVM.Locations = HotelREST.GetAll().Select(x => x.Location).Distinct().ToList();
            ViewBag.Message = "Choose your dates";

            return View(ReserveVM);
        }

        [HttpPost]
        public ActionResult Search(ReserveVM ReserveVM = null)
        {
            if (ReserveVM.Checkin < DateTime.Now)
            {
                ModelState.AddModelError(string.Empty, "The check-in can not be before today");
                return View();
            }

            if (ReserveVM.Checkin > ReserveVM.Checkout)
            {
                ModelState.AddModelError(string.Empty, "Check-in must be before check-out");
                return View();
            }

            ReserveVM.Rooms = RoomREST.GetSearch(ReserveVM.Location, ReserveVM.Checkin, ReserveVM.Checkout)
                .Where(r => r.HasTV == ReserveVM.HasTV &&  r.HasHairDryer == ReserveVM.HasHairDryer && r.Price>ReserveVM.MinPrice && r.Price<ReserveVM.MaxPrice
                && r.Hotel.HasParking==ReserveVM.HasParking && r.Hotel.HasWifi==ReserveVM.HasWifi).ToList();

            ReserveVM.Hotels = ReserveVM.Rooms.Select(x => x.Hotel).Distinct().ToList();
            Session["ReserveVM"] = ReserveVM;
            return RedirectToAction("Index", "Book");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}