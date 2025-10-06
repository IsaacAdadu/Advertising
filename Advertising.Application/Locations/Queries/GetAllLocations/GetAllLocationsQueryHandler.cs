using Advertising.Domain.Entities;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Locations.Queries.GetAllLocations
{
    public class GetAllLocationsQueryHandler: IRequestHandler<GetAllLocationsQuery, List<Location>>
    {
        private readonly AdvertisingDbContext _context;
        public GetAllLocationsQueryHandler(AdvertisingDbContext context) => _context = context;

        public async Task<List<Location>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Locations.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
