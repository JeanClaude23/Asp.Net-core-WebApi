using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class TblAuthUser
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
