using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class MetabaseUserSource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SourceId { get; set; }

        public virtual MetabaseSource Source { get; set; } = null!;
        public virtual MetabaseUser User { get; set; } = null!;
    }
}
