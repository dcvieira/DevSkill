using System.ComponentModel.DataAnnotations;

namespace DevSkill.App.ViewModels
{
    public class CheckoutViewModel
    {
        public Guid CourseId { get; set; }

        [Required]
        public string Country { get; set; } = String.Empty;

        [Required]
        public string PostalCode { get; set; } = String.Empty;

        [Required]
        public string CreditCardNumber { get; set; } = String.Empty;

        [Required]
        public string NameOnCard { get; set; } = String.Empty;

        [Required]
        public string SecuityCode { get; set; } = String.Empty;

        [Required]
        public string ExpirationDate { get; set; } = String.Empty;
    }
}
