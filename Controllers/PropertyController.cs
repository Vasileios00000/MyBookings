using Microsoft.AspNet.Identity;
using MyBookings.Models;
using MyBookings.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookings.Controllers
{
    public class PropertyController : Controller
    {
        private ApplicationDbContext _context;

        public PropertyController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult AddProperty()
        {
            AddPropertyViewModel model = new AddPropertyViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveProperty(AddPropertyViewModel viewmodel, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProperty", viewmodel);
            }

            string path = "";
            if (image != null)
            {
                path = Path.Combine(Server.MapPath("~/Data/properties"), $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}");
                image.SaveAs(path);
            }

            Property NewProperty = new Property()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                Name = viewmodel.Name,
                CategoryType = viewmodel.CategoryType,
                Owner = viewmodel.Owner,
                Bedrooms=viewmodel.Bedrooms,
                Bathrooms=viewmodel.Bedrooms,
                Sleeps=viewmodel.Sleeps,
                Notes = viewmodel.Notes


            };

            if (image != null)
            {
                NewProperty.Image = Path.GetFileName(path);
            };

            _context.Properties.Add(NewProperty);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProperties()
        {
            string userid = User.Identity.GetUserId();
            IEnumerable<Property> list = _context.Properties.Where(x => x.ApplicationUserId == userid);

            return View(list);
        }


        public ActionResult DeleteProperty(int id)
        {
            Property property = _context.Properties.Where(x => x.Id == id).FirstOrDefault();

            _context.Properties.Remove(property);
            _context.SaveChanges();

            return RedirectToAction("MyProperties", "Property");
        }
    }

}