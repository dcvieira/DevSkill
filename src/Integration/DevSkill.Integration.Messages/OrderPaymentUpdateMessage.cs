

namespace DevSkill.Integration.Messages;
public class OrderPaymentUpdateMessage 
{
    public Guid Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public Guid OrderId { get; set; }
    public bool PaymentSuccess { get; set; }
}