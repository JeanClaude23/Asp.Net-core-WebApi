using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class CoreMvcCustomer
    {
        public CoreMvcCustomer()
        {
            CoreMvcCustomerDetails = new HashSet<CoreMvcCustomerDetail>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool StatusId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CoreMvcCustomerDetail> CoreMvcCustomerDetails { get; set; }
    }
}
