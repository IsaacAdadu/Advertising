using Advertising.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Queries.GetAllStatuses
{
    public class GetAllStatusesQuery: IRequest<List<StatusDto>>;
    
}
