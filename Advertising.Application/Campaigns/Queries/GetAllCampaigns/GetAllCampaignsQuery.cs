using Advertising.Application.Campaigns.Queries.GetCampaignById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Queries.GetAllCampaigns
{
    public record GetAllCampaignsQuery: IRequest<List<CampaignDto>>;

}
