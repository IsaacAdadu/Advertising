using Advertising.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.UpdateCampaignStatus
{
    public record UpdateCampaignStatusCommand(Guid CampaignId, CampaignStatus NewStatus) : IRequest<bool>;
    
}
