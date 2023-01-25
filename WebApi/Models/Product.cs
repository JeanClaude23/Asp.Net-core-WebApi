using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Product
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Color { get; set; }
        public int? PriceId { get; set; }
    }
}
