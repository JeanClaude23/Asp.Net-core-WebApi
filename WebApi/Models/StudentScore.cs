using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class StudentScore
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int? StudentScore1 { get; set; }
        public string? Class { get; set; }
    }
}
