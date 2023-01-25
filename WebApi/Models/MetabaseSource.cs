using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class MetabaseSource
    {
        public MetabaseSource()
        {
            MetabaseTickets = new HashSet<MetabaseTicket>();
        }

        public int Id { get; set; }
        public string SourceName { get; set; } = null!;

        public virtual ICollection<MetabaseTicket> MetabaseTickets { get; set; }
    }
}
