using AutoMapper;
using Blazored.LocalStorage;
using DevSkill.App.Contracts;
using DevSkill.App.Services.Base.Order;


namespace DevSkill.App.Services
{
    public class OrderDataService : BaseOrderDataService, IOrderDataService
    {
        private readonly IMapper _mapper;
        public OrderDataService(IMapper mapper, IOrderClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        //public async Task<ApiResponse<Guid>> CreateOrder(CreateOrderViewModel createOrderViewModel)
        //{
        //    try
        //    {
        //        await AddBearerToken();
        //        var apiResponse = new ApiResponse<Guid>();
        //        CreateOrderCommand createOrderCommand = _mapper.Map<CreateOrderCommand>(createOrderViewModel);
        //        var createOrderCommandResponse = await _client.CreateOrderAsync(createOrderCommand);
        //        if (createOrderCommandResponse.Success)
        //        {
        //            apiResponse.Success = true;
        //        }
        //        else
        //        {
        //            foreach (var error in createOrderCommandResponse.ValidationErrors)
        //            {
        //                apiResponse.ValidationErrors += error + Environment.NewLine;
        //            }
        //        }
        //        return apiResponse;
        //    }
        //    catch (ApiException ex)
        //    {
        //        return ConvertApiExceptions<Guid>(ex);
        //    }



        //}

        public async Task<List<OrdersListVm>> GetAllUserOrdersAsync()
        {
            await AddBearerToken();

            var allOrders = await _client.GetAllUserOrdersAsync();
            return allOrders.ToList();
        }


        public async Task<OrderVm?> GetCourseOrderAsync(Guid courseId)
        {
            await AddBearerToken();

            try {
                var order = await _client.GetCourseOrderAsync(courseId);
                return order;
            }
         
            catch (Base.Order.ApiException)
            {
                return null;
            }
        }
    }
}
