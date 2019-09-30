﻿using MyBookings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookings.ViewModel
{
    public class AddPropertyViewModel
    {
            public int Id { get; set; }
            [Required]
            public Category CategoryType { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Owner { get; set; }

            public string Image { get; set; }

            public string Notes { get; set; }

            public ICollection<Booking> Bookings { get; set; }



    }
}