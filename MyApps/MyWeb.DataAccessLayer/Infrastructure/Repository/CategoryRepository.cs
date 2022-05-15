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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        //creating database connection
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            //_context.categories.Update(category);
            //We fetch the data and then update
            var categoryDb = _context.categories.FirstOrDefault(x => x.Id == category.Id);
            if(categoryDb != null )
            {
                categoryDb.Name = category.Name;
                categoryDb.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
