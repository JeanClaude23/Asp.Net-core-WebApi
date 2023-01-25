using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class StudentDetail
    {
        public int? StudentId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Grade { get; set; }
        public string? Total { get; set; }
    }
}
