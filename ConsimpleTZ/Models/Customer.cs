namespace ConsimpleTZ.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
