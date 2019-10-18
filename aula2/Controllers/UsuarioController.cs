using System.Collections.Generic;
using System.Linq;
using aula2.models;
using Microsoft.AspNetCore.Mvc;

namespace aula2.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        Aula2Context context = new Aula2Context();
        [HttpGet]
        public IActionResult listar()
        {
            List<UsuarioModel> lista = context.tbl_usuario.ToList();
            return Ok(lista);
        }
    }
}