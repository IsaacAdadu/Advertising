using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.UpdateCampaign
{
    public record UpdateCampaignCommand(
        Guid Id,
        string Name,
        DateTime From,
        DateTime To,
        decimal Amount,
        List<int> LocationIds
    ) : IRequest<bool>;
}
