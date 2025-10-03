using Advertising.Domain.Entities;
using Advertising.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.CreateCampaign
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Guid>
    {
        private readonly AdvertisingDbContext _db;
        // For now we won't implement cloud uploads; store files later.
        public CreateCampaignCommandHandler(AdvertisingDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = new Campaign
            {
                Name = request.Name,
                From = request.From,
                To = request.To,
                OwnerId = request.OwnerId,
                Amount = request.Amount,
               
            };

            if (request.LocationIds != null)
            {
                foreach (var loc in request.LocationIds)
                {
                    campaign.Locations.Add(new CampaignLocation
                    {
                        LocationId = loc,
                        DailyBudget = 0,
                        TotalBudget = 0
                    });
                }
            }

            _db.campaigns.Add(campaign);
            await _db.SaveChangesAsync(cancellationToken);

            // NOTE: Banners upload: for now we do not persist uploaded bytes. We will wire ICloudinaryService later.
            if (request.Banners != null && request.Banners.Any())
            {
                foreach (var file in request.Banners)
                {
                    // placeholder: create Banner with a temp url (later replace with upload)
                    campaign.Banners.Add(new Banner
                    {
                        CampaignId = campaign.Id,
                        Url = $"temp://{file.FileName}",
                        PublicId = $"temp-{Guid.NewGuid()}"
                    });
                }
                await _db.SaveChangesAsync(cancellationToken);
            }

            return campaign.Id;
        }
    }
}
