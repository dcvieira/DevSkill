using AutoMapper;
using DevSkill.Application.Contracts;
using DevSkill.Application.Contracts.Persistence;
using DevSkill.Application.Exceptions;
using MediatR;

namespace DevSkill.Application.Features.Order.Queries.GetOrderByCourse
{
    public class GetOrderByCourseQueryHandler : IRequestHandler<GetOrderByCourseQuery, OrderVm>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;



        public GetOrderByCourseQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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
            return _mapper.Map<OrderVm>(order);
        }
    }
}
