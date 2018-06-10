using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValaisTourisme_MVC.ViewModel;

namespace ValaisTourisme_MVC.Controllers
{
    public class CancelController : Controller
    {
        // GET: Cancel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CancelVM cancelVM)
        {


            if (ModelState.IsValid)
            {
                List<Booking> booking = BookingManager.GetBooking(cancelVM.Firstname, cancelVM.Lastname);

                if (booking.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "No booking with this name");
                    return View();
                }

                cancelVM.Dates= booking.Select(x => x.Date).Distinct().ToList();
                cancelVM.Booking = booking;

                Session["CancelVM"] = cancelVM;
                return RedirectToAction("MyBooking");
            }
            return View();
        }

        public ActionResult MyBooking()
        {
            if (Session["cancelVM"] == null)
            {
                return RedirectToAction("Index", "Cancel");
            }

            CancelVM cancelVM = (CancelVM)Session["cancelVM"];
            cancelVM.Booking = BookingManager.GetBooking(cancelVM.Firstname, cancelVM.Lastname);
            return View(cancelVM);
        }

        public ActionResult Cancel(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            BookingManager.DeleteBooking(id);

            return RedirectToAction("MyBooking", "Cancel");
        }


    }
}