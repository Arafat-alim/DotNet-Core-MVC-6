using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebApps.Models
{
    public class Category
    {
        //properties
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        //jab bhi apna order add hoga toh uska datetime add hojyga 
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
