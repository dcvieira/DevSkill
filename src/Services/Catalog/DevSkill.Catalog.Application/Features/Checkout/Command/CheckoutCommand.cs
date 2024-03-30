using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Catalog.Application.Features.Checkout.Command;
public class CheckoutCommand : IRequest<CheckoutCommandResponse>
{
    public Guid CourseId { get; set; }
    public string Country { get; set; } = String.Empty;
    public string PostalCode { get; set; } = String.Empty;

    public string NameOnCard { get; set; } = String.Empty;
    public string CreditCardNumber { get; set; } = String.Empty;
    public string SecuityCode { get; set; } = String.Empty;
    public string ExpirationDate { get; set; } = String.Empty;
}

