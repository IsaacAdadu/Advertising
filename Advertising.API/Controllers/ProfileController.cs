using Advertising.Application.Auth.Commands.UpdateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertising.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController:ControllerBase
    {
        private readonly IMediator _mediator;
        public ProfileController(IMediator mediator) => _mediator = mediator;

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest("Failed to update profile.");
            return Ok("Profile updated successfully.");
        }
    }
}
