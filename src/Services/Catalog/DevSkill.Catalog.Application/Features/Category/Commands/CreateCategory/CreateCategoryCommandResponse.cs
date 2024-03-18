using DevSkill.Catalog.Application.Responses;


namespace DevSkill.Catalog.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse() : base()
    {

    }

    public CreateCategoryDto Category { get; set; } = default!;
}
