using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.UpdateCampaignStatus
{
    public class UpdateCampaignStatusCommandHandler: IRequestHandler<UpdateCampaignStatusCommand, bool>
    {
        private readonly AdvertisingDbContext _context;

        public UpdateCampaignStatusCommandHandler(AdvertisingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCampaignStatusCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _context.Campaigns
                .FirstOrDefaultAsync(c => c.Id == request.CampaignId, cancellationToken);

            if (campaign == null)
                return false;

            campaign.StatusId = request.NewStatusId;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
