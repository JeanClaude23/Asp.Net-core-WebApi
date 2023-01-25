using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class MetabaseUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
    }
}
