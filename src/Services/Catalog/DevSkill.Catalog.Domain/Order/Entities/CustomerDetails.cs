using DevSkill.Catalog.Domain.Order.ValueObjects;

namespace DevSkill.Catalog.Domain.Order.Entities;

public class OrderDetails
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string Country { get; set; } = String.Empty;
    public string PostalCode { get; set; } = String.Empty;
    public CreditCardNumber CreditCardNumber { get; set; }
    public string NameOnCard { get; set; } = String.Empty;
    public string SecuityCode { get; set; } = String.Empty;
    public string ExpirationDate { get; set; } = String.Empty;
}