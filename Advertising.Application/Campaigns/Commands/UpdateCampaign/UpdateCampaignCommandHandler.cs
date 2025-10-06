using Advertising.Domain.Entities;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.UpdateCampaign
{
    public class UpdateCampaignCommandHandler: IRequestHandler<UpdateCampaignCommand, bool>
    {
        private readonly AdvertisingDbContext _context;

        public UpdateCampaignCommandHandler(AdvertisingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Locations)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (campaign == null)
                return false;

          
            campaign.Name = request.Name;
            campaign.From = request.From;
            campaign.To = request.To;
            campaign.Amount = request.Amount;

            
            campaign.Locations.Clear();

            if (request.LocationIds != null && request.LocationIds.Any())
            {
                foreach (var locId in request.LocationIds)
                {
                    campaign.Locations.Add(new CampaignLocation
                    {
                        CampaignId = campaign.Id,
                        LocationId = locId,
                        DailyBudget = 0,
                        TotalBudget = 0
                    });
                }
            }

            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
