using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsimpleTZ.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        public string Article { get; set; } = null!;

        [Required]
        [Range(0.0, float.MaxValue)]
        public float Price { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
    }
}
