using AutoMapper;
using DevSkill.Catalog.Application.Contracts;
using DevSkill.Catalog.Application.Contracts.Persistence;
using DevSkill.Catalog.Application.Exceptions;
using DevSkill.Catalog.Domain.Order.ValueObjects;
using MediatR;
using DevSkill.Integration.Messages;

namespace DevSkill.Catalog.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMessageBus _messageBus;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ICourseRepository courseRepository, IMessageBus messageBus, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            _orderRepository = orderRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
            _messageBus = messageBus;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderCommandResponse();

            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            if (course == null)
            {
                throw new NotFoundException("Course Not Found", request.CourseId);
            }

            //try
            //{
            //    await _messageBus.PublishMessage(null, "checkoutmessage");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}


            var Order = new Domain.Order.Entities.Order()
            {
                CourseId = request.CourseId,
                Price = course.Price,
                CourseName = course.Name,
                UserId = _loggedInUserService.UserId,
                OrderDate = DateTime.Now,
                OrderStatus = Domain.Order.Enums.OrderStatus.Completed,
                OrderDetails = new Domain.Order.Entities.OrderDetails
                {
                    Country = request.Country,
                    PostalCode = request.PostalCode,
                    NameOnCard = request.NameOnCard,
                    CreditCardNumber = CreditCardNumber.From(request.CreditCardNumber),
                    SecuityCode = request.SecuityCode,
                    ExpirationDate = request.ExpirationDate
                }


            };

            await _orderRepository.AddAsync(Order);

            return response;
        }
    }

}