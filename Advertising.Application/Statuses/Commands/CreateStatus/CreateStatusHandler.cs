using Advertising.Domain.Entities;
using Advertising.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Commands.CreateStatus
{
    public class CreateStatusHandler: IRequestHandler<CreateStatusCommand, int>
    {
        private readonly AdvertisingDbContext _db;

        public CreateStatusHandler(AdvertisingDbContext db) => _db = db;

        public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = new Status { Name = request.Name.Trim() };
            _db.Statuses.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
