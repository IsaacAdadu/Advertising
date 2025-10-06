using Advertising.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Application.Statuses.Queries.GetStatusById
{
    public record GetStatusByIdQuery(int Id) : IRequest<StatusDto?>;
   
}
