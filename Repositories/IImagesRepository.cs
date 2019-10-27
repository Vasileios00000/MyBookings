using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookings.Repositories
{
    public interface IImagesRepository
    {
        IEnumerable<string> GetAllCountries();

        IEnumerable<string> GetAllWebsites();
    }
}