using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyBookings.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }

        public int Guests { get; set; }

        public string WebSite { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ArrivalDetails { get; set; }

        public string Notes { get; set; }

        public int PropertyId { get; set; }

        public string PropertyName { get; set; }

        public Property Property { get; set; }


    }


}