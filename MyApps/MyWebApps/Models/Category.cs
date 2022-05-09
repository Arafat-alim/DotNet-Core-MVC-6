namespace MyWebApps.Models
{
    public class Category
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now();
    }
}
