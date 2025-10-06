
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Domain.Entities
{
    public class Campaign
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int StatusId { get; set; } = 0; // default to Draft (0)
        public Status? Status { get; set; }
        public Guid OwnerId { get; set; }
        public decimal Amount { get; set; }
        public List<Banner> Banners { get; set; } = new();
        public List<CampaignLocation> Locations { get; set; } = new();
        public bool IsPaid => Status != null && (Status.Name == "Paid" || Status.Name == "Running");
    }
}
