using MyWeb.DataAccessLayer.Infrastructure.IRepository;
using MyWeb.Models;
using MyWebApps.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productDb = _context.products.FirstOrDefault(x=>x.Id == product.Id);
            if (productDb != null)
            {
                productDb.Name = product.Name;
                productDb.Price = product.Price;
                productDb.Description = product.Description;
                if(productDb.Image != null)
                {
                    productDb.Image = product.Image;
                }
            }
        }
    }
}
