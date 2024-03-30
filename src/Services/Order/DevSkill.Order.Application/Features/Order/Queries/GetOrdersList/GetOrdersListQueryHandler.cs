

using DevSkill.Order.Application.Contracts;
using DevSkill.Order.Application.Contracts.Persistence;
using MediatR;

namespace DevSkill.Catalog.Application.Features.Order.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersListVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, ILoggedInUserService loggedInUserService)
        {
            _orderRepository = orderRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<OrdersListVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var userId = _loggedInUserService!.UserId ?? "";
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return orders.Select(order => new OrdersListVm
            {
                Id = order.Id,
                CourseId = order.CourseId,
                CourseName = order.CourseName,
                OrderDate = order.OrderDate,
                Price = order.Price,
                OrderStatus = order.OrderStatus
            }).ToList();    
        }
    }   
}
