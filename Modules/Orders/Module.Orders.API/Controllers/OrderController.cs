using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Orders.Domain.Services.Commands;
using Module.Orders.Domain.Services.Queries;

namespace Module.Orders.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var rs = await _mediator.Send(new GetOrderQuery { Id = id });
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddOrderCommand command)
        {
            var rs = await _mediator.Send(command);
            return Ok(rs);
        }
    }
}
