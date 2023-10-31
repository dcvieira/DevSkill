using MediatR;

namespace DevSkill.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }

