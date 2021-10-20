using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.IRepository;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DatabaseContext _dbcontext;

        public  IRepository<Country> _countries;
        public  IRepository<Hotel> _hotels;
        public UnitOfWork(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext; 
        }
        public IRepository<Country> Countries=> _countries??= new GenericRepository<Country>(_dbcontext);
        public IRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_dbcontext);


        public void Dispose()
        {
            _dbcontext.Dispose();
            GC.SuppressFinalize(this);
        
        }
        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
