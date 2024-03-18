using MediatR;

namespace DevSkill.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        public Guid CourseId { get; set; }
        public string Country { get; set; } = String.Empty;
        public string PostalCode { get; set; } = String.Empty;

        public string NameOnCard { get; set; } = String.Empty;
        public string CreditCardNumber { get; set; } = String.Empty;
        public string SecuityCode { get; set; } = String.Empty;
        public string ExpirationDate { get; set; } = String.Empty;

    }

}