using Microsoft.AspNet.Identity;
using MyBookings.Models;
using MyBookings.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ActionResult PropertiesSelection(int[] Properties, string[] Attributes)
        {
            string userid = User.Identity.GetUserId();


            List<Booking> filtered_booking_list = new List<Booking>();

            if (Properties != null)
            {
                foreach (var item in Properties)
                {
                    var booking = _context.Bookings.Where(x => x.PropertyId == item).ToList();
                    filtered_booking_list.AddRange(booking);
                }
            }
            else
            {
                var PropertiesOfTheUser = _context.Properties.Where(x => x.ApplicationUserId == userid).ToList();

                foreach (var item in PropertiesOfTheUser)
                {
                    var booking = _context.Bookings.Where(x => x.PropertyId == item.Id).ToList();
                    filtered_booking_list.AddRange(booking);
                }
            }



            FilteredBookingViewModel filteredBooking = new FilteredBookingViewModel()
            {
                FilteredBookings = filtered_booking_list.OrderBy(x => x.CheckIn),
                PropertiesOfTheUser = _context.Properties.Where(x => x.ApplicationUserId == userid),
                SavedWebsitesImages = _context.Images.Where(x => x.ImageType == "Website").Select(x=>x.ImageName).ToList()
                
            };




            if (Attributes == null)
            {
                filteredBooking.shownattributes_user = _context.ShownAttributes.Where(x => x.ApplicationUser.Id == userid).FirstOrDefault();

            }
            else
            {
                List<string> AttributesList = Attributes.ToList();

                var selected_attributes = _context.ShownAttributes.Where(x => x.ApplicationUser.Id == userid).FirstOrDefault();


                if (AttributesList.Contains("Id")) { selected_attributes.Show_Id = true; } else { selected_attributes.Show_Id = false; };
                if (AttributesList.Contains("Property")) { selected_attributes.Property = true; } else { selected_attributes.Property = false; };
                if (AttributesList.Contains("ClientName")) { selected_attributes.ClientName = true; } else { selected_attributes.ClientName = false; };
                if (AttributesList.Contains("CheckIn")) { selected_attributes.CheckIn = true; } else { selected_attributes.CheckIn = false; };
                if (AttributesList.Contains("CheckOut")) { selected_attributes.CheckOut = true; } else { selected_attributes.CheckOut = false; };
                if (AttributesList.Contains("Guests")) { selected_attributes.Guests = true; } else { selected_attributes.Guests = false; };
                if (AttributesList.Contains("WebSite")) { selected_attributes.WebSite = true; } else { selected_attributes.WebSite = false; };
                if (AttributesList.Contains("Country")) { selected_attributes.Country = true; } else { selected_attributes.Country = false; };
                if (AttributesList.Contains("Email")) { selected_attributes.Email = true; } else { selected_attributes.Email = false; };
                if (AttributesList.Contains("PhoneNumber")) { selected_attributes.PhoneNumber = true; } else { selected_attributes.PhoneNumber = false; };
                if (AttributesList.Contains("ArrivalDetails")) { selected_attributes.ArrivalDetails = true; } else { selected_attributes.ArrivalDetails = false; };
                if (AttributesList.Contains("Notes")) { selected_attributes.Notes = true; } else { selected_attributes.Notes = false; };

                filteredBooking.shownattributes_user = selected_attributes;
                _context.SaveChanges();

            }



            return View("~/Views/Home/Index.cshtml",filteredBooking);
        }
    }
}