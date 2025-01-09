using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsimpleTZ.Models
{
    public class PurchaseProduct
    {
        [Key]
        public int PurchaseProductID { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public int PurchaseID { get; set; }

        [JsonIgnore]
        public Purchase? Purchase { get; set; }

        [Required]
        public int ProductID { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
