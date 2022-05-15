using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Models
{
    public class Product
    {
        //Automatically id into Primary Key
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public double Price { get; set; }

        public string Image { get; set; }

        //Automatically categoryId into a Foreign Key.
        public int  CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
