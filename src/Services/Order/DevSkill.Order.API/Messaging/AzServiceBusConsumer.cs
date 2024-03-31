
using DevSkill.Integration.Messages;
using DevSkill.Order.Application.Contracts.Persistence;
using DevSkill.Order.Application.Messages;
using DevSkill.Order.Domain.ValueObjects;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System.Text;

namespace DevSkill.Order.API.Messaging;
public class AzServiceBusConsumer : IAzServiceBusConsumer
{
    private readonly string subscriptionName = "devskillorder";
    private readonly IReceiverClient checkoutMessageReceiverClient;

    private readonly IConfiguration _configuration;

    private readonly IServiceProvider _serviceProvider;

    private readonly string checkoutMessageTopic;

    public AzServiceBusConsumer(IConfiguration configuration, IMessageBus messageBus, IServiceProvider serviceProvider)
    {
        _configuration = configuration;

        _serviceProvider = serviceProvider;

        var serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
        checkoutMessageTopic = _configuration.GetValue<string>("CheckoutMessageTopic");

        checkoutMessageReceiverClient = new SubscriptionClient(serviceBusConnectionString, checkoutMessageTopic, subscriptionName);
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

        using (var scope = _serviceProvider.CreateScope())
        {

            var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();


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

    private Task OnServiceBusException(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
        Console.WriteLine(exceptionReceivedEventArgs);

        return Task.CompletedTask;
    }

    public void Stop()
    {
    }
}

