using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Queries.GetCampaignById
{
    public record GetCampaignByIdQuery(Guid Id) : IRequest<CampaignDto>;
    
}
