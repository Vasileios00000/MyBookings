using Microsoft.AspNet.Identity;
using MyBookings.Models;
using MyBookings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookings.Controllers
{
    public class FilteredBookingsController : Controller
    {
        private ApplicationDbContext _context;

        public FilteredBookingsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public ActionResult PropertiesSelection(int [] Properties, string [] Attributes)
        {
            List<Booking> filtered_booking_list = new List<Booking>();

            if (Properties!=null)
            {
                foreach (var item in Properties)
                {
                    var booking = _context.Bookings.Where(x => x.PropertyId == item).ToList();
                    filtered_booking_list.AddRange(booking);
                }
            }

           List<string> AttributesList = Attributes.ToList();
            



            string userid = User.Identity.GetUserId();
            FilteredBookingViewModel filteredBooking = new FilteredBookingViewModel()

            {
                FilteredBookings = filtered_booking_list.OrderBy(x => x.CheckIn),
                PropertiesOfTheUser = _context.Properties.Where(x => x.ApplicationUserId == userid),
                //shownattributes_user = Attributes.ToList()
                
            };


            return View("~/Views/Home/Index.cshtml",filteredBooking);
        }
    }
}