using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectOne.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id , string[] includes = null)
        {
             return _context.Set<T>().Find(id);
            /*
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
                foreach (var include in includes)
                    query.Include(include);
            T result = query.First(b => b.id);
            return result;*/
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null) 
        {
            IQueryable<T> query = _context.Set<T>();
            //var item = _context.Set<T>().SingleOrDefault(match);
            if (includes != null)
                foreach(var include in includes)
                    query = query.Include(include);


            return query.SingleOrDefault(match);
            
        }


        
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null , string[] includes2 = null)
        {
            //IQueryable<T> query = _context.Set<T>();
            var query = _context.Set<T>().Where(match).ToList();

            

            if (includes != null)
                foreach (var item in query)
                    foreach (var include in includes)
                        _context.Entry(item).Reference(include).Load();
            //query = query.Include(include);


            
            if (includes2 != null)
                foreach (var item in query)
                    foreach (var include in includes2)
                        _context.Entry(item).Collection(include).Load();
               
            
                

            return query;
        }



        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }



        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }
        public int Count()
        {
            return _context.Set<T>().Count();
        }
        public int Count(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Count(match);
        }

        
    }
    
}
