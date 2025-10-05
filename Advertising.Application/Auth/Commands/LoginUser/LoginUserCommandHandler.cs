using Advertising.Domain.Entities;
using Advertising.Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler: IRequestHandler<LoginUserCommand, AuthResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtService;

        public LoginUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJwtTokenService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new AuthResult { Success = false, Message = "Invalid email or password" };

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                return new AuthResult { Success = false, Message = "Invalid email or password" };

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResult { Success = true, Token = token, Message = "Login successful" };
        }
    }
}
