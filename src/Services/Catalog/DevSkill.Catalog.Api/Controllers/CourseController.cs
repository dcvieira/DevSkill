using DevSkill.Catalog.Application.Features.Course.GetCourse;
using DevSkill.Catalog.Application.Features.Course.GetCoursesList;
using DevSkill.Catalog.Application.Features.Order.Queries.GetOrderByCourse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet(Name = "GetAllCourses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CourseListVm>>> GetAllCourses()
    {
        var dtos = await _mediator.Send(new GetCoursesListQuery());
        return Ok(dtos);
    }

    [Authorize]
    [HttpGet("/{courseId}", Name = "GetCourse")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CourseVm?>> GetCourse(Guid courseId)
    {
        var course = await _mediator.Send(new GetCourseQuery { CourseId = courseId });
        return Ok(course);
    }

    [Authorize]
    [HttpGet("/{courseId}/order", Name = "GetCourseOrder")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrderVm>> GetCourseOrder(Guid courseId)
    {
        OrderVm dtos = await _mediator.Send(new GetOrderByCourseQuery {  CourseId = courseId});  
        return Ok(dtos);
    }
}




