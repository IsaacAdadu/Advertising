using Advertising.Application.Campaigns.Commands.CreateCampaign;
using Advertising.Application.Campaigns.Commands.ExtendCampaign;
using Advertising.Application.Campaigns.Commands.UpdateCampaign;
using Advertising.Application.Campaigns.Commands.UpdateCampaignStatus;
using Advertising.Application.Campaigns.Queries.GetAllCampaigns;
using Advertising.Application.Campaigns.Queries.GetCampaignById;
using Advertising.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertising.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CampaignsController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCampaignCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Message = "Campaign created successfully." });
        }

        [HttpPatch("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateCampaignStatusCommand command)
        {
            var success = await _mediator.Send(command);
            if (!success) return NotFound("Campaign not found.");
            return Ok("Campaign status updated successfully.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCampaignsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCampaignByIdQuery(id));
            if (result == null) return NotFound("Campaign not found.");
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCampaignCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Campaign not found or could not be updated.");
            return Ok("Campaign updated successfully.");
        }

        [HttpPost("extend")]
        public async Task<IActionResult> Extend([FromBody] ExtendCampaignCommand command)
        {
            var success = await _mediator.Send(command);
            if (!success)
                return NotFound("Campaign not found or could not be extended.");

            return Ok("Campaign extended successfully with new location(s).");
        }
    }
}
