using Microsoft.EntityFrameworkCore;
using MyWeb.DataAccessLayer.Infrastructure.IRepository;
using MyWebApps.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccessLayer.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Database ko yaha se access karnege
        private readonly ApplicationDbContext _context;
        //db set bhi access krnge
        private DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); //_context.category
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity); //database me add karna hai
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList(); // return database fields
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}
