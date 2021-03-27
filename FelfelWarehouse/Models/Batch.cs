using System;

namespace FelfelWarehouse.Models
{
    public class Batch
    {
        private int productId;
        private int quantity;
        private DateTime expirationDate;

        public enum Freshness { EXPIRED, EXPIRING_TODAY, FRESH };

        public int Id { get; set; }
        public int ProductId { get => productId; set => productId = (value == 0 ? productId : value); }
        public int Quantity { get => quantity; set => quantity = (value < 0 ? quantity : value); }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = (value <= DateTime.Now ? expirationDate : value); }
        public string FreshnessStatus { get => ((Freshness)(ExpirationDate.Date.CompareTo(DateTime.Today.Date) + 1)).ToString(); }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
