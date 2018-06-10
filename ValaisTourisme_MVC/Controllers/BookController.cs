using ValaisTourisme_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;

namespace ValaisTourisme_MVC.Controllers
{
    public class BookController : Controller
    {
        // List of hotels
        public ActionResult Index()
        {
 
            ReserveVM ReserveVM = (ReserveVM)Session["ReserveVM"];
            return View(ReserveVM);
        }

        // Details of the hotel
        public ActionResult Details(int id = 0)
        {

            if (id == 0 || Session["ReserveVM"] == null)
            {
                return RedirectToAction("Index", "Home");
            }


            ReserveVM ReserveVMsession = (ReserveVM)Session["ReserveVM"];
            ReserveVMsession.days = ReserveVMsession.Checkout.Date.Subtract(ReserveVMsession.Checkin).Days;
            ReserveVMsession.Hotel = HotelManager.Getid(id);
            List<Room> tempRooms = ReserveVMsession.Rooms.Where(r => r.IdHotel == id).ToList();
            ReserveVMsession.Rooms = new List<Room>();
            int nbPerson = ReserveVMsession.nbPerson;

           

            while (nbPerson > 0)
            {
                Room room = tempRooms.Where(r => r.Type == 2).FirstOrDefault();

                if (room == null)
                    room = tempRooms.FirstOrDefault();

                if (room == null)
                    break;

                ReserveVMsession.Rooms.Add(room);
                nbPerson -= room.Type;
                tempRooms.Remove(room);
            }

            if (nbPerson == -1)
            {
                Room roomTemp = ReserveVMsession.Rooms.Last();
                ReserveVMsession.Rooms.Remove(ReserveVMsession.Rooms.Last());

                if (tempRooms.FirstOrDefault(r => r.Type == 1) != null)
                {
                    Room room = tempRooms.FirstOrDefault(r => r.Type == 1);
                    ReserveVMsession.Rooms.Add(room);
                }
                else
                {
                    ReserveVMsession.Rooms.Add(roomTemp);
                }
            }



            decimal totalPrice = 0;
            foreach (var room in ReserveVMsession.Rooms)
            {
                room.Price = room.Price * ReserveVMsession.days;

                totalPrice += room.Price;
            }

            ReserveVMsession.TotalPrice = totalPrice;

            return View(ReserveVMsession);
        }

        // Book the stay
        public ActionResult Book()
        {

            if (Session["ReserveVM"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ReserveVM ReserveVM = (ReserveVM)Session["ReserveVM"];

            return View(ReserveVM);
        }

        [HttpPost]
        public ActionResult Book(ReserveVM ReserveVM = null)
        {

            if (ReserveVM == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid && ReserveVM.Firstname != null && ReserveVM.Lastname != null)
            {
                ReserveVM reserveVMSession = (ReserveVM)Session["ReserveVM"];
                reserveVMSession.Firstname = ReserveVM.Firstname;
                reserveVMSession.Lastname = ReserveVM.Lastname;

                Session["ReserveVM"] = reserveVMSession;
                Booking b = new Booking() { CheckIn= reserveVMSession.Checkin, CheckOut=reserveVMSession.Checkout,
                    Date =System.DateTime.Now, Firstname=reserveVMSession.Firstname,
                    Lastname =reserveVMSession.Lastname};
                foreach(Room r in reserveVMSession.Rooms)
                {
                    b.Room = r;
                    b.Price = r.Price;
                    BookingManager.PostNewBooking(b);
                }
                
                return RedirectToAction("Confirmation", "Book");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "The firstname and/or lastname are empty !");
                ReserveVM reserveVMSession = (ReserveVM)Session["ReserveVM"];
                return View(reserveVMSession);

            }
        }



        // Validate the reservation
        public ActionResult Confirmation()
        {

            if (Session["ReserveVM"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ReserveVM ReserveVM = (ReserveVM)Session["ReserveVM"];

            return View(ReserveVM);
        }
    }
}
