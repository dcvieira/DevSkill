using DevSkill.Application.Features.Categories.Queries.GetCategoriesList;
using DevSkill.Application.Features.Category.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet(Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
    {
        var dtos = await _mediator.Send(new GetCategoriesListQuery());
        return Ok(dtos);
    }



    [HttpPost(Name = "AddCategory")]
    public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var response = await _mediator.Send(createCategoryCommand);
        return Ok(response);
    }
}
