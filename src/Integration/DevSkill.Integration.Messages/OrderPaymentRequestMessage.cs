namespace DevSkill.Integration.Messages;


public class OrderPaymentRequestMessage
{
    public Guid Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public Guid OrderId { get; set; }
    public int Total { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string CardName { get; set; } = string.Empty;
    public string CardExpiration { get; set; } = string.Empty;
}