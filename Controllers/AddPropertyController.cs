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
    public class AddPropertyController : Controller
    {
        private ApplicationDbContext _context;

        public AddPropertyController()
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
                path = Path.Combine(Server.MapPath("~/Data"), $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}");
                image.SaveAs(path);
            }

            Property NewProperty = new Property()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                Name = viewmodel.Name,
                CategoryType = viewmodel.CategoryType,
                Owner = viewmodel.Owner,
                Notes = viewmodel.Notes
            };

            _context.Properties.Add(NewProperty);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }

}