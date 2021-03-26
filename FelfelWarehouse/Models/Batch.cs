using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FelfelWarehouse.Models
{
    public class Batch
    {
        private int productId;
        private int quantity;
        private DateTime expirationDate;

        public int Id { get; set; }
        public int ProductId { get => productId; set => productId = (value == 0 ? productId : value); }
        public int Quantity { get => quantity; set => quantity = (value == 0 ? quantity : value); }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = (value.Millisecond == 0 ? expirationDate : value); }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
