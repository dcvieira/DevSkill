using DevSkill.Domain.Common;
using DevSkill.Domain.Order.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Application.Features.Order.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersListVm>>
    {
    }
}
