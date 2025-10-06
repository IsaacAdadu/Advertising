using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.ExtendCampaign
{
    public record ExtendCampaignCommand(
        Guid CampaignId,
        List<int> LocationIds
    ) : IRequest<bool>;
    
}
