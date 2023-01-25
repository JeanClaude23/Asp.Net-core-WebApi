using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class CoreMvcCustomerDetail
    {
        public int CustomerDetailId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Pincode { get; set; } = null!;
        public bool IsPrimary { get; set; }

        public virtual CoreMvcCustomer Customer { get; set; } = null!;
    }
}
