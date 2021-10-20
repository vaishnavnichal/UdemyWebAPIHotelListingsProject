using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication2.IRepository
{
    public interface IRepository<T> where T:class
    {

        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            List<string> includes = null
            );
        Task<T> Get(Expression<Func<T, bool>> expression = null
            , List<string> includes = null
            );

        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);





        //IEnumerable<T> GetAll();
        //T GetById(int id);
        //void Insert(T Obj);
        //void update(T obj);
        //void Delete(T obj);



        //Task<IList<T>> GetAll(
        //    Expression<Func<T, bool>> expression = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
        //    List<string> includes = null
        //    );



    }
}
