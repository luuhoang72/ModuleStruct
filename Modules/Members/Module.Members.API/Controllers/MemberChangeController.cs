using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Members.Domain.Services.Queries;

namespace Module.Members.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberChangeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberChangeController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("{memberId}")]
        public async Task<IActionResult> Get([FromRoute] string memberId)
        {
            var rs = await _mediator.Send(new GetMemberChangeQuery { MemberId = memberId });
            return Ok(rs);
        }
    }
}
