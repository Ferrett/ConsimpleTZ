﻿namespace ConsimpleTZ.Models
{
    public class PurchaseItem
    {
        public int PurchaseItemID { get; set; }
        public int PurchaseID { get; set; }
        public int Quantity { get; set; }
        public Purchase Purchase { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
