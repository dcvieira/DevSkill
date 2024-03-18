

using MediatR;

namespace DevSkill.Catalog.Application.Features.Order.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersListVm>>
    {
    }
}
