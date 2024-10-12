using MassTransit;
using DevSkill.Integration.Messages;
using DevSkill.Order.Domain.ValueObjects;
using DevSkill.Order.Application.Contracts.Persistence;

namespace DevSkill.Order.API.Consumers;

public class CheckoutMessageConsumer : IConsumer<CheckoutRequestMessage>
{
    private readonly IOrderRepository orderRepository;

    public CheckoutMessageConsumer(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }


    public async Task Consume(ConsumeContext<CheckoutRequestMessage> context)
    {
        var checkoutMessage = context.Message;


        var Order = new Domain.Entities.Order()
        {
            CourseId = checkoutMessage.CourseId,
            Price = checkoutMessage.CoursePrice,
            CourseName = checkoutMessage.CourseName,
            UserId = checkoutMessage.UserId,
            OrderDate = DateTime.Now,
            OrderStatus = Domain.Enums.OrderStatus.Completed,
            OrderDetails = new Domain.Entities.OrderDetails
            {
                Country = checkoutMessage.Country,
                PostalCode = checkoutMessage.PostalCode,
                NameOnCard = checkoutMessage.NameOnCard,
                CreditCardNumber = CreditCardNumber.From(checkoutMessage.CreditCardNumber),
                SecuityCode = checkoutMessage.SecuityCode,
                ExpirationDate = checkoutMessage.ExpirationDate
            }

        };
        await orderRepository.AddAsync(Order);
    }
}