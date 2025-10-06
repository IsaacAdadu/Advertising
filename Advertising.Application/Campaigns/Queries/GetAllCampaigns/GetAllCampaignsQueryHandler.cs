using Advertising.Application.Campaigns.Queries.GetCampaignById;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Queries.GetAllCampaigns
{
    public class GetAllCampaignsQueryHandler: IRequestHandler<GetAllCampaignsQuery, List<CampaignDto>>
    {
        private readonly AdvertisingDbContext _context;

        public GetAllCampaignsQueryHandler(AdvertisingDbContext context)
        {
            _context = context;
        }

        public async Task<List<CampaignDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
        {
            var campaigns = await _context.Campaigns
                .Include(c => c.Banners)
                .Include(c => c.Locations)
                .ToListAsync(cancellationToken);

            return campaigns.Select(c => new CampaignDto
            {
                Id = c.Id,
                Name = c.Name,
                From = c.From,
                To = c.To,
                Status = c.Status.ToString(),
                Amount = c.Amount,
                OwnerId = c.OwnerId,
                Banners = c.Banners.Select(b => new BannerDto
                {
                    Id = b.Id,
                    Url = b.Url,
                    PublicId = b.PublicId
                }).ToList(),
                Locations = c.Locations.Select(l => new LocationDto
                {
                    Id = l.LocationId,
                    Name = _context.Locations.FirstOrDefault(x => x.Id == l.LocationId)!.Name,
                    State = _context.Locations.FirstOrDefault(x => x.Id == l.LocationId)!.State,
                    Country = _context.Locations.FirstOrDefault(x => x.Id == l.LocationId)!.Country
                }).ToList()
            }).ToList();
        }
    }
}
