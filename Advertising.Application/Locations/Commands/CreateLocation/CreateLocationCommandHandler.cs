using Advertising.Domain.Entities;
using Advertising.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler: IRequestHandler<CreateLocationCommand, int>
    {
        private readonly AdvertisingDbContext _context;
        public CreateLocationCommandHandler(AdvertisingDbContext context) => _context = context;

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Location
            {
                Name = request.Name,
                State = request.State,
                Country = request.Country
            };

            _context.Locations.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
