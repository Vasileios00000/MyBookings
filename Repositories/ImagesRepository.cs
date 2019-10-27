using MyBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookings.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ApplicationDbContext _context;

        public ImagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetAllCountries()
        {
            return _context.Images.Where(z=>z.ImageType=="Country").OrderBy(a => a.ImageName).Select(a => a.ImageName).ToList();
        }

        public IEnumerable<string> GetAllWebsites()
        {
            return _context.Images.Where(z=>z.ImageType=="Website").OrderBy(a => a.ImageName).Select(a => a.ImageName).ToList();
        }


    }
}