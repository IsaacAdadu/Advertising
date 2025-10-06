using Advertising.Domain.Entities;
using Advertising.Domain.Enums;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.CreateCampaign
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Guid>
    {
        private readonly AdvertisingDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public CreateCampaignCommandHandler(AdvertisingDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<Guid> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var ownerId = _httpContext.HttpContext?.User?.FindFirstValue("uid");
            if (ownerId is null)
                throw new UnauthorizedAccessException("User not authenticated.");

            var campaign = new Campaign
            {
                Name = request.Name,
                From = request.From,
                To = request.To,
                OwnerId = Guid.Parse(ownerId),
                Amount = request.Amount,
                Status = CampaignStatus.Draft
            };

            // attach selected locations
            foreach (var loc in request.Locations)
            {
                campaign.Locations.Add(new CampaignLocation
                {
                    LocationId = loc.LocationId,
                    DailyBudget = loc.DailyBudget,
                    TotalBudget = loc.TotalBudget
                });
            }

            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync(cancellationToken);
            return campaign.Id;
        }
    }
}

