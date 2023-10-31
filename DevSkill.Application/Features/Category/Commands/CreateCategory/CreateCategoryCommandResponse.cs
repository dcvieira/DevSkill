using DevSkill.Application.Responses;


namespace DevSkill.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse() : base()
    {

    }

    public CreateCategoryDto Category { get; set; } = default!;
}
