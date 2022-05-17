using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Models.ViewModels
{
    public class CategoryVM
    {
        //for making loosely coupled
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
