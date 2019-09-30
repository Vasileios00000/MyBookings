using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookings.Models
{
    public enum Category {Villa, Apartment }

    public class Property
    {
        public int Id { get; set; }

        public Category CategoryType { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string Image { get; set; }

        public string Notes { get; set; }

        public string ApplicationUserId { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}