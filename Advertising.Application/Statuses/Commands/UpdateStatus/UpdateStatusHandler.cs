using Advertising.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusHandler: IRequestHandler<UpdateStatusCommand, bool>
    {
        private readonly AdvertisingDbContext _db;
        public UpdateStatusHandler(AdvertisingDbContext db) => _db = db;

        public async Task<bool> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _db.Statuses.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (status == null) return false;

            status.Name = request.Name.Trim();
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
