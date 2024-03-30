using DevSkill.Integration.Messages;
using DevSkill.Order.Application.Features.Order.Commands.CreateOrder;
using DevSkill.Order.Application.Messages;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System.Text;

namespace DevSkill.Order.API.Messaging;
public class AzServiceBusConsumer : IAzServiceBusConsumer
{
    private readonly string subscriptionName = "devskillorder";
    private readonly IReceiverClient checkoutMessageReceiverClient;
    private readonly IReceiverClient orderPaymentUpdateMessageReceiverClient;

    private readonly IConfiguration _configuration;

    private readonly IMediator _mediator;
    private readonly IMessageBus _messageBus;

    private readonly string checkoutMessageTopic;
    private readonly string orderPaymentRequestMessageTopic;
    private readonly string orderPaymentUpdatedMessageTopic;

    public AzServiceBusConsumer(IConfiguration configuration, IMessageBus messageBus, IMediator mediator)
    {
        _configuration = configuration;

        _mediator = mediator;
        _messageBus = messageBus;

        var serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
        checkoutMessageTopic = _configuration.GetValue<string>("CheckoutMessageTopic");
        orderPaymentRequestMessageTopic = _configuration.GetValue<string>("OrderPaymentRequestMessageTopic");
        orderPaymentUpdatedMessageTopic = _configuration.GetValue<string>("OrderPaymentUpdatedMessageTopic");

        checkoutMessageReceiverClient = new SubscriptionClient(serviceBusConnectionString, checkoutMessageTopic, subscriptionName);
        orderPaymentUpdateMessageReceiverClient = new SubscriptionClient(serviceBusConnectionString, orderPaymentUpdatedMessageTopic, subscriptionName);
    }

    public void Start()
    {
        var messageHandlerOptions = new MessageHandlerOptions(OnServiceBusException) { MaxConcurrentCalls = 4 };

        checkoutMessageReceiverClient.RegisterMessageHandler(OnCheckoutMessageReceived, messageHandlerOptions);
        //orderPaymentUpdateMessageReceiverClient.RegisterMessageHandler(OnOrderPaymentUpdateReceived, messageHandlerOptions);
    }

    private async Task OnCheckoutMessageReceived(Message message, CancellationToken arg2)
    {
        var body = Encoding.UTF8.GetString(message.Body);//json from service bus

        //save order with status not paid
        CheckoutRequestMessage checkoutMessage = JsonConvert.DeserializeObject<CheckoutRequestMessage>(body);


        var command = new CreateOrderCommand
        {
            UserId = checkoutMessage.UserId,
            CoursePrice = checkoutMessage.CoursePrice,
            CourseId = checkoutMessage.CourseId,
            CourseName = checkoutMessage.CourseName,
            Country = checkoutMessage.Country,
            PostalCode = checkoutMessage.PostalCode,
            NameOnCard = checkoutMessage.NameOnCard,
            CreditCardNumber = checkoutMessage.CreditCardNumber,
            SecuityCode = checkoutMessage.SecuityCode,
            ExpirationDate = checkoutMessage.ExpirationDate
        };
        
        await _mediator.Send(command);

    }

    //private async Task OnOrderPaymentUpdateReceived(Message message, CancellationToken arg2)
    //{
    //    var body = Encoding.UTF8.GetString(message.Body);//json from service bus
    //    OrderPaymentUpdateMessage orderPaymentUpdateMessage =
    //        JsonConvert.DeserializeObject<OrderPaymentUpdateMessage>(body);

    //    await _orderRepository.UpdateOrderPaymentStatus(orderPaymentUpdateMessage.OrderId, orderPaymentUpdateMessage.PaymentSuccess);
    //}

    private Task OnServiceBusException(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
        Console.WriteLine(exceptionReceivedEventArgs);

        return Task.CompletedTask;
    }

    public void Stop()
    {
    }
}

