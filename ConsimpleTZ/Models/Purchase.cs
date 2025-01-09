using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsimpleTZ.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.0, float.MaxValue)]
        public float TotalCost { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
    }
}
