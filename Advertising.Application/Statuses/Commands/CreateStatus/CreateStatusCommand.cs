using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Commands.CreateStatus
{
    public record CreateStatusCommand(string Name) : IRequest<int>;
    
}
