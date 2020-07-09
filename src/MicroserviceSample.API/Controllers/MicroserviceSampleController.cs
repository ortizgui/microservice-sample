using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MicroserviceSample.Domain.Commands;

namespace MicroserviceSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MicroserviceSampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MicroserviceSampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] GetPersonCommand command)
        {
            var serviceResponse = await _mediator.Send(command);
            return Ok(serviceResponse);
        }
    }
}