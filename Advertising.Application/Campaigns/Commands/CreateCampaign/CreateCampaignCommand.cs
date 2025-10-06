using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.CreateCampaign
{
    public record CampaignLocationDto(int LocationId, decimal DailyBudget, decimal TotalBudget);
    public record CreateCampaignCommand(
        string Name,
        DateTime From,
        DateTime To,
        decimal Amount,
        List<CampaignLocationDto> Locations
    ) : IRequest<Guid>;
}
