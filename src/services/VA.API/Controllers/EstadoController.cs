using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VA.Application.UseCase.Commands;

namespace VA.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstadoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarEstado(string estado)
        {
            var command = new CriarEstadoCommand(estado);
            var id = await _mediator.Send(command);

            return Ok(id);
        }
        [HttpPost]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{id}/cidade")]
        public async Task<IActionResult> CriarCidade(string cidade)
        {
            return Ok();
        }
    }
}
