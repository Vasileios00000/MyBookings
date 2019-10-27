using MyBookings.Models;
using MyBookings.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookings.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IImagesRepository Images { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Images = new ImagesRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }


    }
}