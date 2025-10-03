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
            RuleFor(x => x.From).LessThan(x => x.To).WithMessage("'From' must be earlier than 'To'.");
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Banners)
                .Must(b => b == null || b.All(f => f.Length <= 2 * 1024 * 1024))
                .WithMessage("Each banner must be <= 2MB.");
        }
    }
}
