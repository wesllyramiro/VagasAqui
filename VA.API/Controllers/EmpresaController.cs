using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VA.API.Models;
using VA.API.Services;

namespace VA.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServices _services;

        public EmpresaController(IEmpresaServices services)
        {
            _services = services;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarEmpresa(EmpresaModel model) 
        {
            if (model.IdCidade == 0) 
            {
                return BadRequest("Cidade deve ser infomado");
            }

            if (model.IdUsuario == 0)
            {
                return BadRequest("Usuário deve ser infomado");
            }

            if (model.Nome == "")
            {
                return BadRequest("O nome da empresa deve ser infomado");
            }

            _services.CriarEmpresa(model);

            return Ok();
        }
    }
}
