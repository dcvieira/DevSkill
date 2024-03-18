using DevSkill.Catalog.Domain.Common;
using DevSkill.Catalog.Domain.Order.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Catalog.Application.Features.Order.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersListVm>>
    {
    }
}
