using ValaisTourisme_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

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
            ReserveVM.Locations = HotelManager.GetAll().Select(x => x.Location).Distinct().ToList();
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

            ReserveVM.Rooms = RoomManager.GetSearch(ReserveVM.Location, ReserveVM.Checkin, ReserveVM.Checkout, ReserveVM.HasHairDryer, ReserveVM.HasTV,
                ReserveVM.HasParking, ReserveVM.HasWifi, ReserveVM.MinPrice, ReserveVM.MaxPrice, ReserveVM.MinCategory, ReserveVM.MaxCategory);
                
   

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