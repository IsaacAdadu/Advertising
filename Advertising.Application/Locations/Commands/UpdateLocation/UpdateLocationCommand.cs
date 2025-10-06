using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Locations.Commands.UpdateLocation
{
    public record UpdateLocationCommand(int Id, string Name, string State, string Country) : IRequest<bool>;
    
}
