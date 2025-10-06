using Advertising.Domain.DTOs;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Queries.GetAllStatuses
{
    public class GetAllStatusesHandler: IRequestHandler<GetAllStatusesQuery, List<StatusDto>>
    {
        private readonly AdvertisingDbContext _db;
        public GetAllStatusesHandler(AdvertisingDbContext db) => _db = db;

        public async Task<List<StatusDto>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _db.Statuses
                .AsNoTracking()
                .Select(s => new StatusDto { Id = s.Id, Name = s.Name })
                .ToListAsync(cancellationToken);
        }
    }
}
