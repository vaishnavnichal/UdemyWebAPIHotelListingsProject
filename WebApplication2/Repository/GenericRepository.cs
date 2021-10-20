using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.IRepository;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private readonly DatabaseContext _dbcontext;

        private readonly DbSet<T> _dbset;

        public GenericRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbset = _dbcontext.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _dbset.FindAsync(id);
           _dbcontext.Remove(id);
       
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _dbset;

            if (includes != null)
            {
                foreach (var includeprop in includes )
                {
                    query=query.Include(includeprop);
                }
            
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, List<string> includes = null)
        {
            IQueryable<T> query = _dbset;

            if (expression != null)
            {

                query = query.Where(expression);
            
            }
            
            if (includes != null)
            {
                foreach (var includeprop in includes)
                {
                    query = query.Include(includeprop);
                }

            }

            if (orderby != null)
            {
                query=orderby(query);
            
            }


            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
        }
    }
}
