namespace ConsimpleTZ.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Article { get; set; } = null!;
        public float Price { get; set; }
    }
}
