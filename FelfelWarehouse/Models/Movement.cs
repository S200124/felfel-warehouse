using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelfelWarehouse.Models
{
    public class Movement
    {
        private int batchId;
        private int amount;
        private DateTime timestamp;
        private string reason;

        public int Id { get; set; }
        public int BatchId { get => batchId; set => batchId = (value == 0 ? batchId : value); }
        public int Amount { get => amount; set => amount = (value == 0 ? amount : value); }
        public DateTime Timestamp { get => timestamp; set => timestamp = (value.Millisecond == 0 ? timestamp : value); }
        public String Reason { get => reason; set => reason = (string.IsNullOrWhiteSpace(value) ? reason : value); }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
