using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;

        // Optional back reference if you need navigation
        public List<CampaignLocation> Campaigns { get; set; } = new();
    }
}
