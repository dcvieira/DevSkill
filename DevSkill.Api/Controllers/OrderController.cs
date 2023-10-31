using DevSkill.Application.Features.Course.GetCoursesList;
using DevSkill.Application.Features.Order.Commands.CreateOrder;
using DevSkill.Application.Features.Order.Queries.GetOrdersList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DevSkill.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet( Name = "GetAllUserOrders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrdersListVm>>> GetAllUserOrders()
    {
        var dtos = await _mediator.Send(new GetOrdersListQuery());
        return Ok(dtos);
    }

    [Authorize]
    [HttpPost(Name = "CreateOrder")]
    public async Task<ActionResult<CreateOrderCommandResponse>> Create([FromBody] CreateOrderCommand createOrderCommand)
    {
        var response = await _mediator.Send(createOrderCommand);
        return Ok(response);
    }
}




