using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Invoices.Domain.Services.Queries;

namespace Module.Invoices.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var rs = await _mediator.Send(new GetInvoiceQuery { Id = id });
            return Ok(rs);
        }
    }
}
