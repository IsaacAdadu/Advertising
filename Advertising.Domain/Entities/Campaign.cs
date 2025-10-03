using Advertising.Domain.Enums;
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
        public CampaignStatus Status { get; set; } = CampaignStatus.Draft;
        public Guid OwnerId { get; set; }
        public decimal Amount { get; set; }
        public List<Banner> Banners { get; set; } = new();
        public List<CampaignLocation> Locations { get; set; } = new();
        public bool IsPaid => Status == CampaignStatus.Paid || Status == CampaignStatus.Running;
    }
}
