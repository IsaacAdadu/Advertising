﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Auth.Commands.LoginUser
{
    public record LoginUserCommand(string Email, string Password) : IRequest<AuthResult>;
    
}
