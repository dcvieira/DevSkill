using AutoMapper;
using DevSkill.Application.Contracts;
using DevSkill.Application.Contracts.Persistence;
using MediatR;

namespace DevSkill.Application.Features.Order.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersListVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<OrdersListVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var userId = _loggedInUserService!.UserId ?? "";
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<List<OrdersListVm>>(orders);
        }
    }   
}
