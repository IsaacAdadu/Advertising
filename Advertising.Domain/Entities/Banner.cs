using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Domain.Entities
{
    public class Banner
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CampaignId { get; set; }
        public string Url { get; set; } = default!;
        public string PublicId { get; set; } = default!;
    }
}
