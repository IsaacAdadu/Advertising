using Advertising.Domain.Entities;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.ExtendCampaign
{
    public class ExtendCampaignCommandHandler: IRequestHandler<ExtendCampaignCommand, bool>
    {
        private readonly AdvertisingDbContext _context;

        public ExtendCampaignCommandHandler(AdvertisingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ExtendCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Locations)
                .FirstOrDefaultAsync(c => c.Id == request.CampaignId, cancellationToken);

            if (campaign == null)
                return false;

            var existingLocationIds = campaign.Locations.Select(x => x.LocationId).ToHashSet();

            foreach (var locId in request.LocationIds)
            {
                
                if (existingLocationIds.Contains(locId))
                    continue;

                campaign.Locations.Add(new CampaignLocation
                {
                    CampaignId = campaign.Id,
                    LocationId = locId,
                    DailyBudget = 0,
                    TotalBudget = 0
                });
            }

            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
