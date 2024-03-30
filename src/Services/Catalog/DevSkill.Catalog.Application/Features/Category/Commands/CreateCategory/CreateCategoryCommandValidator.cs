using FluentValidation;

namespace DevSkill.Catalog.Application.Features.Category.Commands.CreateCategory;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{

    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
    }
}

