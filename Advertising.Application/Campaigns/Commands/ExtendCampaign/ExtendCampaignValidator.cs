using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Campaigns.Commands.ExtendCampaign
{
    public class ExtendCampaignValidator: AbstractValidator<ExtendCampaignCommand>
    {
        public ExtendCampaignValidator()
        {
            RuleFor(x => x.CampaignId).NotEmpty();
            RuleFor(x => x.LocationIds)
                .NotNull().NotEmpty()
                .WithMessage("At least one location ID must be provided.");
        }
    }
}
