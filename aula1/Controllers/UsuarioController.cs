using System.Collections.Generic;
using System.Linq;
using aula1.Models;
using Microsoft.AspNetCore.Mvc;

namespace aula1.Controllers
{
    [ApiController] // Mostra que é uma api
    [Route("v1/[controller]")] // Define a rota -> nome da rota
    [Produces("application/json")] // Define o tipo de dado transmitido -> nesse caso é json
    public class UsuarioController : ControllerBase
    {
        // Lista de usuarios global
        List<UsuarioModel> listaDeUsuarios = new List<UsuarioModel>();

        // O Nome da rota -> v1/nome_controller/listarUsuario
        [HttpGet("listarUsuario")]
        // ActionResult -> mostra o resultado de uma ação
        public IActionResult Usuarios()
        {
            // Criando um usuario
            UsuarioModel usuario = new UsuarioModel();
            usuario.id_usuario = 1;
            usuario.nome_usuario = "Gabriel Moraes";
            usuario.email = "gmmartins06@gmail.com";
            usuario.senha = "123";

            UsuarioModel usuario2 = new UsuarioModel();
            usuario2.id_usuario = 2;
            usuario2.nome_usuario = "Gabriella Evangelista";
            usuario2.email = "gabi.evangelista07@gmail.com";
            usuario2.senha = "456";

            // Adicionando na lista de usuarios 

            listaDeUsuarios.Add(usuario);
            listaDeUsuarios.Add(usuario2);

            // Retornar a lista de usuarios
            return Ok(listaDeUsuarios);
        }

        [HttpGet("listarUsuario/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // Função que lista os usuarios 
            Usuarios();

            // Retorno dos dados que é passado por meio da URL 
            return Ok(listaDeUsuarios.FirstOrDefault(rs => rs.id_usuario == id)); 
        }

        [HttpPost("cadastro")]
        public IActionResult Cadastrar(UsuarioModel usuario){
            Usuarios();
            listaDeUsuarios.Add(usuario);
            return Ok(listaDeUsuarios);
        }
    }
}