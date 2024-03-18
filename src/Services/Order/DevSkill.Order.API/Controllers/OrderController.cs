
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DevSkill.Order.Api.Controllers;


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
    [HttpGet(Name = "GetAllUserOrders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrdersListVm>>> GetAllUserOrders()
    {
        var dtos = await _mediator.Send(new GetOrdersListQuery());
        return Ok(dtos);
    }
}




