

namespace DevSkill.Integration.Messages;
public interface IMessageBus
{
    Task PublishMessage(IntegrationBaseMessage message, string topicName);
}

