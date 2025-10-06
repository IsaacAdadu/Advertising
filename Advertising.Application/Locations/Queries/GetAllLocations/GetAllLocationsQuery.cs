using Advertising.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Locations.Queries.GetAllLocations
{
    public record GetAllLocationsQuery: IRequest<List<Location>>;
    
}
