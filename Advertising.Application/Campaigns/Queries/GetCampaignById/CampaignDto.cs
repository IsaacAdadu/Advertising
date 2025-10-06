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

        public List<LocationDto> Locations { get; set; } = new();
        public List<BannerDto> Banners { get; set; } = new();
    }
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
    public class BannerDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = default!;
        public string PublicId { get; set; } = default!;
    }
}
