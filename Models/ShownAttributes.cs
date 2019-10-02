using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBookings.Models
{
    public enum Shown_Attributes_enum
    {   Id,
        Property,
        ClientName,
        CheckIn,
        CheckOut,
        Guests,
        WebSite,
        Country,
        Email,
        PhoneNumber,
        ArrivalDetails,
        Note
    }


    public class ShownAttributes
    {
        [ForeignKey("ApplicationUser")]
        public string ShownAttributesId { get; set; } = "all_true";

        public bool Show_Id { get; set; } = true;

        public bool Property { get; set; } = true;

        public bool ClientName { get; set; } = true;

        public bool CheckIn { get; set; } = true;

        public bool CheckOut { get; set; } = true;

        public bool Guests { get; set; } = true;

        public bool WebSite { get; set; } = true;

        public bool Country { get; set; } = true;

        public bool Email { get; set; } = true;

        public bool PhoneNumber { get; set; } = true;

        public bool ArrivalDetails { get; set; } = true;

        public bool Notes { get; set; } = true;


        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}