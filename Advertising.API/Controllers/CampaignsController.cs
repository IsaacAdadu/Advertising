using Advertising.Application.Campaigns.Commands.CreateCampaign;
using Advertising.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Advertising.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CampaignsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCampaignDto dto)
        {
            var cmd = new CreateCampaignCommand(
                dto.Name,
                dto.From,
                dto.To,
                dto.OwnerId,
                dto.Amount,
                dto.LocationIds,
                dto.Banners
            );

            var id = await _mediator.Send(cmd);
            return Ok(new { id });
        }
    }
}
