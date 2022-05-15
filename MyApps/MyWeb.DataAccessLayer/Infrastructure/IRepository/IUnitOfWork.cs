using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository categoryRepository { get; } //created a variable
        void Save();
    }
}
