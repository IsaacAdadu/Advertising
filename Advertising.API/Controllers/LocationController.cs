using Advertising.Application.Locations.Commands.CreateLocation;
using Advertising.Application.Locations.Commands.UpdateLocation;
using Advertising.Application.Locations.Queries.GetAllLocations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertising.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LocationController:ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Message = "Location created successfully" });
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationCommand command)
        {
            var success = await _mediator.Send(command);
            if (!success)
                return NotFound(new { Message = "Location not found" });

            return Ok(new { Message = "Location updated successfully" });
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLocationsQuery());
            return Ok(result);
        }
    }
}

