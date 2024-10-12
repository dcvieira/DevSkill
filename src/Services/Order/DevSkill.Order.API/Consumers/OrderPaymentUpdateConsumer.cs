using DevSkill.Integration.Messages;
using DevSkill.Order.Application.Contracts.Persistence;
using MassTransit;

namespace DevSkill.Order.API.Consumers;
public class OrderPaymentUpdateConsumer : IConsumer<OrderPaymentUpdateMessage>
{
    private readonly IOrderRepository _orderRepository;

    public OrderPaymentUpdateConsumer(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Consume(ConsumeContext<OrderPaymentUpdateMessage> context)
    {
        var message = context.Message;
        var order = await _orderRepository.GetByIdAsync(message.OrderId);
        if (order != null)
        {
            if (message.PaymentSuccess)
            {
                order.OrderStatus = Domain.Enums.OrderStatus.Completed;
            }
            else
            {
                order.OrderStatus = Domain.Enums.OrderStatus.Cancelled;
            }
            await _orderRepository.UpdateAsync(order);
        }


    }
}

