using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Auth.Commands.UpdateUserProfile
{
    public record UpdateUserProfileCommand(string FirstName,string LastName,string CompanyName) :IRequest<bool>;
}
