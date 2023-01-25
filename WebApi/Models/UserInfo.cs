using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? IsAlive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
