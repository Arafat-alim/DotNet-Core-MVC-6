using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class //T jo hai wo koi class aa skti hai
    {
        IEnumerable<T> GetAll();

        T GetT(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entity); //multiple data delete kr skte hai
        // ek class me multiple list aa sakte h
    }
}
