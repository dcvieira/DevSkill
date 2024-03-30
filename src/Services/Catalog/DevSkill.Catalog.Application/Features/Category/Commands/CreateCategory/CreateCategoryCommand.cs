using MediatR;

namespace DevSkill.Catalog.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }

