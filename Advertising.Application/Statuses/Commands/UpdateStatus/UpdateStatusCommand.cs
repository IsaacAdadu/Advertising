using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Commands.UpdateStatus
{
    public record UpdateStatusCommand(int Id, string Name) : IRequest<bool>;
    
}
