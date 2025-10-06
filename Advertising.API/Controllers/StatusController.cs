using Advertising.Application.Statuses.Commands.CreateStatus;
using Advertising.Application.Statuses.Commands.UpdateStatus;
using Advertising.Application.Statuses.Queries.GetAllStatuses;
using Advertising.Application.Statuses.Queries.GetStatusById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertising.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // you can change to [Authorize(Roles = "Admin")] for admin-only
    public class StatusController:ControllerBase
    {
        private readonly IMediator _mediator;
        public StatusController(IMediator mediator) => _mediator = mediator;

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateStatusCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id, Message = "Status created" });
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStatusCommand command)
        {
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("Status not found");
            return Ok("Status updated");
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _mediator.Send(new GetAllStatusesQuery());
            return Ok(list);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await _mediator.Send(new GetStatusByIdQuery(id));
            if (s == null) return NotFound("Status not found");
            return Ok(s);
        }
    }
}
