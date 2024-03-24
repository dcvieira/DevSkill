using AutoMapper;
using Blazored.LocalStorage;
using DevSkill.App.Contracts;
using DevSkill.App.Services.Base;
using DevSkill.App.Services.Base.Catalog;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Services;

public class CategoryDataService : BaseCatalogDataService, ICategoryDataService
{
    private readonly IMapper _mapper;

    public CategoryDataService(ICatalogClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<List<CategoryViewModel>> GetAllCategories()
    {
        await AddBearerToken();

        var allCategories = await _client.GetAllCategoriesAsync();
        var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);
        return mappedCategories.ToList();

    }

    public async Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryViewModel categoryViewModel)
    {
        try
        {
            ApiResponse<CreateCategoryDto> apiResponse = new ApiResponse<CreateCategoryDto>();
            CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(categoryViewModel);
            var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
            if (createCategoryCommandResponse.Success)
            {
                apiResponse.Data = createCategoryCommandResponse.Category;
                apiResponse.Success = true;
            }
            else
            {
                apiResponse.Data = null;
                foreach (var error in createCategoryCommandResponse.ValidationErrors)
                {
                    apiResponse.ValidationErrors += error + Environment.NewLine;
                }
            }
            return apiResponse;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<CreateCategoryDto>(ex);
        }
    }

}
