using AutoMapper;
using Blazored.LocalStorage;
using DevSkill.App.Contracts;
using DevSkill.App.Services.Base;
using DevSkill.App.Services.Base.Catalog;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Services
{
    public class CheckoutDataService : BaseCatalogDataService, ICheckoutDataService
    {
        private readonly IMapper _mapper;

        public CheckoutDataService(ICatalogClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> Checkout(CheckoutViewModel vm)
        {

            try
            {
                await AddBearerToken();
                var apiResponse = new ApiResponse<Guid>();
                CheckoutCommand createOrderCommand = _mapper.Map<CheckoutCommand>(vm);
                var createOrderCommandResponse = await _client.CheckoutAsync(createOrderCommand);
                if (createOrderCommandResponse.Success)
                {
                    apiResponse.Success = true;
                }
                else
                {
                    foreach (var error in createOrderCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }


        }
    }
}
