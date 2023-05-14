using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Members.Domain.Services.Commands;
using Module.Members.Domain.Services.Queries;

namespace Module.Members.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var rs = await _mediator.Send(new GetMemberQuery { Id = id });
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddMemberCommand command)
        {
            var rs = await _mediator.Send(command);
            return Ok(rs);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateMemberCommand command)
        {
            var rs = await _mediator.Send(command);
            return Ok(rs);
        }
    }
}
