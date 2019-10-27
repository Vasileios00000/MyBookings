using MyBookings.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookings.Persistance
{
    public interface IUnitOfWork
    {
        IImagesRepository Images { get; }
        void Complete();

    }
}
