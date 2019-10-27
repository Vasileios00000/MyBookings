using MyBookings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MyBookings.ViewModels
{
    public class AddBookingViewModel
    {
        public int Id { get; set; }

        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        [DisplayName("Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [DisplayName("Number of Guests")]
        public int Guests { get; set; }

        [DisplayName("WebSite/Tour Agent")]
        public string WebSite { get; set; }

        [DisplayName("Country of Origin")]
        public string Country { get; set; }

        [DisplayName("Client's Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Client's Phone")]
        public string PhoneNumber { get; set; }

        [DisplayName("Arrival Details/Flight Details")]
        public string ArrivalDetails { get; set; }

        [DisplayName("Additional Notes")]
        public string Notes { get; set; }

        public IEnumerable<Property> Properties { get; set; }

        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Websites { get; set; }

        public int PropertyId { get; set; }

    }






}