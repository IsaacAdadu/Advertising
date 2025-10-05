using Advertising.Domain.Entities;
using Advertising.Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler: IRequestHandler<RegisterUserCommand, AuthResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtService;

        public RegisterUserCommandHandler(UserManager<User> userManager, IJwtTokenService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ProfileCompleted = false
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = string.Join("; ", result.Errors.Select(e => e.Description))
                };
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResult { Success = true, Token = token, Message = "User registered successfully" };
        }
    }
}
