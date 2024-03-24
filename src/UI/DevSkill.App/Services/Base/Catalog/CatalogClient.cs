namespace DevSkill.App.Services.Base.Catalog;

public partial class CatalogClient : ICatalogClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }

