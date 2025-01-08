namespace ConsimpleTZ.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public float TotalCost { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<PurchaseItem> PurchaseItems { get; set; } = null!;
    }
}
