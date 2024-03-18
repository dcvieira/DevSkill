using MediatR;

namespace DevSkill.Catalog.Application.Features.Categories.Queries.GetCategoriesList;
public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
{
}
