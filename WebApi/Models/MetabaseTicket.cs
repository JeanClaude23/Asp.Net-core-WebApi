using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class MetabaseTicket
    {
        public int TicketId { get; set; }
        public string? Subject { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public int Source { get; set; }
        public string? Type { get; set; }
        public string? Agent { get; set; }
        public string? Group { get; set; }
        public DateTime? InitialResponseTime { get; set; }
        public TimeSpan? FirstResponseTimeHr { get; set; }
        public int? CustomerInteractions { get; set; }
        public string? Product { get; set; }
        public string? CustomerSignature { get; set; }
        public string? Fullname { get; set; }
        public string? ContactId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDomains { get; set; }
        public string? HealthScore { get; set; }
        public string? AccountTier { get; set; }
        public DateTime? RenewalDate { get; set; }
        public string? Industry { get; set; }

        public virtual MetabaseSource SourceNavigation { get; set; } = null!;
    }
}
