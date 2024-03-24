namespace DevSkill.App.Services.Base.Order;

public partial class OrderClient : IOrderClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }

