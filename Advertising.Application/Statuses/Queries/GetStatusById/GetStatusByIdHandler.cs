using Advertising.Domain.DTOs;
using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Queries.GetStatusById
{
    public class GetStatusByIdHandler: IRequestHandler<GetStatusByIdQuery, StatusDto?>
    {
        private readonly AdvertisingDbContext _db;
        public GetStatusByIdHandler(AdvertisingDbContext db) => _db = db;

        public async Task<StatusDto?> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var s = await _db.Statuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (s == null) return null;
            return new StatusDto { Id = s.Id, Name = s.Name };
        }
    }
}
