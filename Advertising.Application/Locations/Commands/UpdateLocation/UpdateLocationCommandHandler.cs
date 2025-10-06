using Advertising.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler: IRequestHandler<UpdateLocationCommand, bool>
    {
        private readonly AdvertisingDbContext _context;
        public UpdateLocationCommandHandler(AdvertisingDbContext context) => _context = context;

        public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.FindAsync(new object[] { request.Id }, cancellationToken);
            if (location == null)
                return false;

            location.Name = request.Name;
            location.State = request.State;
            location.Country = request.Country;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
