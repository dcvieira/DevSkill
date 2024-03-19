
using DevSkill.Order.Application.Features.Order.Queries.GetOrderByCourse;
using DevSkill.Order.Application.Contracts;
using DevSkill.Order.Application.Contracts.Persistence;
using MediatR;
using DevSkill.Order.Application.Exceptions;

namespace DevSkill.Order.Application.Features.Order.Queries.GetOrderByCourse
{
    public class GetOrderByCourseQueryHandler : IRequestHandler<GetOrderByCourseQuery, OrderVm>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggedInUserService _loggedInUserService;



        public GetOrderByCourseQueryHandler(IOrderRepository orderRepository,  ILoggedInUserService loggedInUserService)
        {
            _orderRepository = orderRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<OrderVm> Handle(GetOrderByCourseQuery request, CancellationToken cancellationToken)
        {
            var userId = _loggedInUserService.UserId;
            var order = await _orderRepository.GetOrdersByUserCourse(request.CourseId, userId);

            if(order == null)
            {
                throw new NotFoundException(nameof(Order), request.CourseId);
            }
            return new OrderVm
            {
                Id = order.Id,
                CourseId = order.CourseId,
                UserId = order.UserId,
                CourseName = order.CourseName,
                OrderDate = order.OrderDate,
                Price = order.Price,
                OrderStatus = order.OrderStatus
            };
        }
    }
}
