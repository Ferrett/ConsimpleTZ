using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsimpleTZ.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [JsonIgnore]
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
