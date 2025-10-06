
using MediatR;

namespace Advertising.Application.Campaigns.Commands.UpdateCampaignStatus
{
    public record UpdateCampaignStatusCommand(Guid CampaignId, int NewStatusId) : IRequest<bool>;
    
}
