using DevSkill.App.Services.Base;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Contracts
{
    public interface ICheckoutDataService
    {
        public Task<ApiResponse<Guid>> Checkout(CheckoutViewModel vm);
    }
}
