using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.CreateCampaign
{
    public class CreateCampaignValidator : AbstractValidator<CreateCampaignCommand>
    {
        public CreateCampaignValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.From)
                .LessThan(x => x.To)
                .WithMessage("'From' date must be earlier than 'To' date.");
            RuleFor(x => x.Amount).GreaterThan(0);

            RuleForEach(x => x.Locations).ChildRules(location =>
            {
                location.RuleFor(l => l.LocationId).GreaterThan(0);
                location.RuleFor(l => l.DailyBudget).GreaterThanOrEqualTo(0);
                location.RuleFor(l => l.TotalBudget).GreaterThanOrEqualTo(0);
            });
        }
    }
}
