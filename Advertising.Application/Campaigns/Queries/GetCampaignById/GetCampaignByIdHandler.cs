using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Queries.GetCampaignById
{
    public class GetCampaignByIdHandler : IRequestHandler<GetCampaignByIdQuery, CampaignDto?>
    {
        private readonly AdvertisingDbContext _db;
        public GetCampaignByIdHandler(AdvertisingDbContext db)
        {
            _db = db;
        }

        public async Task<CampaignDto?> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _db.Campaigns
                .Include(c => c.Banners)
                .Include(c => c.Locations)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (campaign == null)
                return null;

            return new CampaignDto
            {
                Id = campaign.Id,
                Name = campaign.Name,
                From = campaign.From,
                To = campaign.To,
                Status = campaign.Status.ToString(),
                Amount = campaign.Amount,
                OwnerId = campaign.OwnerId,
                BannerUrls = campaign.Banners.Select(b => b.Url).ToList(),
                LocationIds = campaign.Locations.Select(l => l.LocationId).ToList()
            };
        }
    }
}
