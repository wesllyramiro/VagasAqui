using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VA.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmpresaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CriarEmpresa() 
        {
            return Ok();
        }
    }
}
