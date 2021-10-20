using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.IRepository
{
   public interface IUnitOfWork
    {
        IRepository<Country> Countries { get;  }
        IRepository<Hotel> Hotels { get;  }
        Task Save();


    }
}
