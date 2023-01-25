using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Testview
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? ManagerId { get; set; }
    }
}
