using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id , string[] includes = null);

        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> match, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null, string[] includes2 = null);

        T Update(T entity);

        T Insert(T entity);
        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);  
        int Count(Expression<Func<T, bool>> match);
        int Count();
    }
}
