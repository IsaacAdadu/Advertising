using Advertising.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Auth.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler: IRequestHandler<UpdateUserProfileCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateUserProfileCommandHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
            if (userId is null) return false;

            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.CompanyName = request.CompanyName;
            user.ProfileCompleted = !string.IsNullOrWhiteSpace(user.FirstName)
                                    && !string.IsNullOrWhiteSpace(user.LastName)
                                    && !string.IsNullOrWhiteSpace(user.CompanyName);

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
