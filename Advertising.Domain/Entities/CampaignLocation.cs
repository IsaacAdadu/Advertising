using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Domain.Entities
{
    public class CampaignLocation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CampaignId { get; set; }
        public int LocationId { get; set; }
        public decimal DailyBudget { get; set; }
        public decimal TotalBudget { get; set; }
    }
}
