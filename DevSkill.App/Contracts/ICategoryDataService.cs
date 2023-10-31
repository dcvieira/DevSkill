using DevSkill.App.Services.Base;
using DevSkill.App.ViewModels;

namespace DevSkill.App.Contracts;

public interface ICategoryDataService
{
    Task<List<CategoryViewModel>> GetAllCategories();
    Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
}