﻿

using DevSkill.Integration.Messages;
using DevSkill.Order.Application.Contracts;
using DevSkill.Order.Application.Contracts.Persistence;
using DevSkill.Order.Domain.ValueObjects;
using MediatR;

namespace DevSkill.Order.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderCommandResponse();

            var Order = new Domain.Entities.Order()
            {
                CourseId = request.CourseId,
                Price = request.CoursePrice,
                CourseName = request.CourseName,
                UserId = request.UserId,
                OrderDate = DateTime.Now,
                OrderStatus = Domain.Enums.OrderStatus.Completed,
                OrderDetails = new Domain.Entities.OrderDetails
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

            //send order payment request message
            //OrderPaymentRequestMessage orderPaymentRequestMessage = new OrderPaymentRequestMessage
            //{
            //    CardExpiration = basketCheckoutMessage.CardExpiration,
            //    CardName = basketCheckoutMessage.CardName,
            //    CardNumber = basketCheckoutMessage.CardNumber,
            //    OrderId = orderId,
            //    Total = basketCheckoutMessage.BasketTotal
            //};

            //try
            //{
            //    await _messageBus.PublishMessage(orderPaymentRequestMessage, orderPaymentRequestMessageTopic);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            return response;
        }
    }

}