using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.UpdateCampaign
{
    public class UpdateCampaignValidator: AbstractValidator<UpdateCampaignCommand>
    {
        public UpdateCampaignValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.From)
                .LessThan(x => x.To)
                .WithMessage("'From' must be earlier than 'To'.");
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
