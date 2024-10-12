

using DevSkill.Integration.Messages;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace DevSkill.Payment.Worker.Consumers;
public class OrderPaymentRequestConsumer : IConsumer<OrderPaymentRequestMessage>
{
    public async Task Consume(ConsumeContext<OrderPaymentRequestMessage> context)
    {
        var success = new Random().Next(0, 2) == 1;
        var message = new OrderPaymentUpdateMessage
        {
            Id = Guid.NewGuid(),
            CreationDateTime = DateTime.UtcNow,
            OrderId = context.Message.OrderId,
            PaymentSuccess = success
        };

        await context.Publish(message);
    }
}