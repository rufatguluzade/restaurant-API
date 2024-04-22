using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = false, params string[] includes);
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression, bool isTracking = false, params string[] includes);
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);


        //Get by Id relation olanda relation etdiyimiz obyektide gostermek ucun
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes);


        // gedib data basede tekrarin olub olmadigini yoxlayir
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression, bool isTracking = false, params string[] includes);

    }
}
