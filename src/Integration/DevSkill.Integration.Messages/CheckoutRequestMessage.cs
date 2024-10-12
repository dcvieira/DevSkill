

namespace DevSkill.Integration.Messages;
public class CheckoutRequestMessage 
{
    public Guid Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public Guid CourseId { get; set; }
    public int CoursePrice { get; set; }
    public string CourseName { get; set; } = String.Empty;
    public string UserId { get; set; } = String.Empty;
    public string Country { get; set; } = String.Empty;
    public string PostalCode { get; set; } = String.Empty;

    public string NameOnCard { get; set; } = String.Empty;
    public string CreditCardNumber { get; set; } = String.Empty;
    public string SecuityCode { get; set; } = String.Empty;
    public string ExpirationDate { get; set; } = String.Empty;

}