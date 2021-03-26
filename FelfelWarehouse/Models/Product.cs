using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FelfelWarehouse.Models
{
    public class Product
    {
        private string name;

        public int Id { get; set; }
        public string Name { get => name; set => name = (string.IsNullOrWhiteSpace(value) ? name : value); }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
