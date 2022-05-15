using MyWeb.DataAccessLayer.Infrastructure.IRepository;
using MyWebApps.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //creating ApplciationDbContext
        private readonly ApplicationDbContext _context;
        public ICategoryRepository categoryRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            categoryRepository = new CategoryRepository(context); // intialise
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
