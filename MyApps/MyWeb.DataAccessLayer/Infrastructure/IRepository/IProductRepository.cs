using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccessLayer.Infrastructure.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
       void Update(Product product);
    }
}
