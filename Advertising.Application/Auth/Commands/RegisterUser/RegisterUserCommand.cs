using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Auth.Commands.RegisterUser
{
    public record RegisterUserCommand(string Email, string Password, string FirstName, string LastName) : IRequest<AuthResult>;
    
}
