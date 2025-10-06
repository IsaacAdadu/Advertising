using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Locations.Commands.UpdateLocation
{
    public class UpdateLocationValidator: AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.State).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
        }
    }
}
