using MyBookings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyBookings.ViewModels
{
    public class FilteredBookingViewModel
    {


        public IEnumerable<Booking> FilteredBookings { get; set; }

        public IEnumerable<Property> PropertiesOfTheUser { get; set; }

        public IEnumerable<ShownAttributes> ShownAttributes { get; set; }

        public ShownAttributes shownattributes_user { get; set; }

        public CultureInfo cultureinfo { get; set; }

        public IEnumerable<string> SavedWebsitesImages { get; set; }


        public List<string> GetEnumValues()
        {
            return Enum.GetNames(typeof(Shown_Attributes_enum)).ToList();
        }

        public FilteredBookingViewModel()
        {
           cultureinfo = new CultureInfo("en-US");
           SavedWebsitesImages = new List<string>();

        }


    }
}