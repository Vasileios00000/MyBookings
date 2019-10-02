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
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult FirstLogIn()
        {
            string userid = User.Identity.GetUserId();
            ShownAttributes initial_attr = new ShownAttributes();
            initial_attr.ApplicationUser = _context.Users.Find(userid);

            _context.ShownAttributes.Add(initial_attr);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



            public ActionResult Index()
            {

            




            List<Booking> list = new List<Booking>();
            List<Property> properies_oftheUser = new List<Property>();
            
            string userid = User.Identity.GetUserId();

            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            };


            properies_oftheUser = _context.Properties.Where(x => x.ApplicationUserId == userid).ToList();

            foreach (var item1 in properies_oftheUser)
            {
                foreach (var item2 in _context.Bookings.ToList())
                {
                    if (item2.PropertyId == item1.Id)
                    {
                        list.Add(item2);
                    }
                }
            }

            FilteredBookingViewModel booking_list = new FilteredBookingViewModel()
            {
                FilteredBookings = list.OrderBy(x => x.CheckIn),
                PropertiesOfTheUser = properies_oftheUser,
                shownattributes_user = _context.ShownAttributes.Where(x => x.ApplicationUser.Id == userid).FirstOrDefault()
  
            };


            return View(booking_list);
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