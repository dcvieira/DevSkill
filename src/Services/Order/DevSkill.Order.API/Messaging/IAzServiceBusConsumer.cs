namespace DevSkill.Order.API.Messaging;

public interface IAzServiceBusConsumer
{
    void Start();
    void Stop();
}