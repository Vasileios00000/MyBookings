using MyBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBookings.ViewModels;
using MyBookings.ViewModel;
using Microsoft.AspNet.Identity;

namespace MyBookings.Controllers
{
    public class BookingController : Controller
    {

        private ApplicationDbContext _context;

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult AddBooking()
        {
            AddBookingViewModel model = new AddBookingViewModel();

            var user_id = User.Identity.GetUserId();
            var propertiesofowner = _context.Properties.Where(x => x.ApplicationUserId == user_id).ToList();
            model.Properties = propertiesofowner;

            return View(model);
        }


        [HttpPost]
        public ActionResult SaveBooking(AddBookingViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddBooking", viewmodel);
            }

            string prop_name = _context.Properties.Find(viewmodel.PropertyId).Name;

            Booking NewBooking = new Booking()
            {
                ClientName = viewmodel.ClientName,
                CheckIn = viewmodel.CheckIn,
                CheckOut = viewmodel.CheckOut,
                Guests = viewmodel.Guests,
                WebSite = viewmodel.WebSite,
                Country = viewmodel.Country,
                Email = viewmodel.Email,
                PhoneNumber = viewmodel.PhoneNumber,
                ArrivalDetails = viewmodel.ArrivalDetails,
                Notes = viewmodel.Notes,
                PropertyId=viewmodel.PropertyId,
                PropertyName = prop_name

            };

            _context.Bookings.Add(NewBooking);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeleteBooking(int id)
        {
            Booking bookingToDel = _context.Bookings.Where(x => x.Id == id).FirstOrDefault();

            _context.Bookings.Remove(bookingToDel);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }


        public ActionResult EditBooking(int id)
        {
            Booking BookingToEdit = _context.Bookings.Where(x => x.Id == id).FirstOrDefault();

            AddBookingViewModel model = new AddBookingViewModel()
            {
                Id = BookingToEdit.Id,
                ClientName = BookingToEdit.ClientName,
                CheckIn = BookingToEdit.CheckIn,
                CheckOut = BookingToEdit.CheckOut,
                Country = BookingToEdit.Country,
                Guests = BookingToEdit.Guests,
                WebSite = BookingToEdit.WebSite,
                Email = BookingToEdit.Email,
                PhoneNumber = BookingToEdit.PhoneNumber,
                ArrivalDetails = BookingToEdit.ArrivalDetails,
                Notes = BookingToEdit.Notes
            };

            return View("EditBooking", model);

        }

        [HttpPost]
        public ActionResult EditBooking(AddBookingViewModel model)
        {
            var item = _context.Bookings.Where(x => x.Id == model.Id).FirstOrDefault();

            item.ClientName = model.ClientName;
            item.CheckIn = model.CheckIn;
            item.CheckOut = model.CheckOut;
            item.Country = model.Country;
            item.Guests = model.Guests;
            item.WebSite = model.WebSite;
            item.Email = model.Email;
            item.PhoneNumber = model.PhoneNumber;
            item.ArrivalDetails = model.ArrivalDetails;
            item.Notes = model.Notes;

            _context.SaveChanges();


            return RedirectToAction("Index", "Home");

        }
    }
}