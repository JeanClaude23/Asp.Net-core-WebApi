using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class WebApiUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Token { get; set; }
        public string? Email { get; set; }
    }
}
