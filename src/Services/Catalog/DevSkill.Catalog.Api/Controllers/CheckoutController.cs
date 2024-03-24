using DevSkill.Catalog.Application.Features.Checkout.Command;
using DevSkill.Catalog.Application.Features.Course.GetCoursesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost(Name = "Checkout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CheckoutCommandResponse>> Checkout([FromBody] CheckoutCommand cmd)
        {
            var dtos = await _mediator.Send(cmd);
            return Ok(dtos);
        }
    }
}
