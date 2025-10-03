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
    public record CreateCampaignCommand(
        string Name,
        DateTime From,
        DateTime To,
        Guid OwnerId,
        decimal Amount,
        List<int>LocationIds,
        List<IFormFile> Banners
        ):IRequest<Guid>;
}
