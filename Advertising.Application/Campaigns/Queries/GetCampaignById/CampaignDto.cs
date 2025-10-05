using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Queries.GetCampaignById
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Status { get; set; } = default!;
        public decimal Amount { get; set; }
        public Guid OwnerId { get; set; }
        public List<string> BannerUrls { get; set; } = new();
        public List<int> LocationIds { get; set; } = new();
    }
}
