using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VA.Application.UseCase.Commands.CriarCidade;
using VA.Application.UseCase.Commands.CriarEmpresa;
using VA.Application.UseCase.Queries.BuscarCidade;
using VA.Infrastructure.CrossCutting.Shared;

namespace VA.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
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
        [Route("{idEstado}/cidade")]
        public async Task<IActionResult> CriarCidade(int idEstado, string nome)
        {
            var command = new CriarCidadeCommand(nome, idEstado);
            var outPut = await _mediator.Send(command);


            if (outPut.IsValid)
            {
                int id = outPut.GetResult();
                return CreatedAtAction(nameof(BuscarCidade), routeValues: new
                {
                    idEstado,
                    idCidade = id
                }, id);
            }

            return Ok(new Response(outPut.GetResult()));
        }
        [HttpGet]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{idEstado}/cidade/{idCidade}")]
        public async Task<IActionResult> BuscarCidade(int idEstado, int idCidade)
        {
            var query = new BuscarCidadeQuery(idEstado, idCidade);
            var output = await _mediator.Send(query);

            if (output.IsValid)
            {
                var cidade = output.GetResult();

                if (cidade == null)
                    return NotFound();

                return Ok(new Response(cidade));
            }

            return BadRequest(new Response(output.ErrorMessages));
        }
    }
}
