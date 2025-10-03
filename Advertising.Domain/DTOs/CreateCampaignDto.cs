using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Domain.DTOs
{
    public class CreateCampaignDto
    {
        public string Name { get; set; } = default!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid OwnerId { get; set; }
        public decimal Amount { get; set; }
        public System.Collections.Generic.List<int> LocationIds { get; set; } = new();
        public System.Collections.Generic.List<IFormFile>? Banners { get; set; }
    }
}
