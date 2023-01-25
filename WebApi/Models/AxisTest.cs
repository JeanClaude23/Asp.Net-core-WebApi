using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class AxisTest
    {
        public string? TicketId { get; set; }
        public string? Agent { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? Source { get; set; }
        public string? Associationtype { get; set; }
    }
}
