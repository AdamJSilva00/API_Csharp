using System.Collections.Generic;
using System.Linq;
using aula2.Context;
using aula2.models;
using Microsoft.AspNetCore.Mvc;

namespace aula2.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        Aula2Context Context = new Aula2Context();

        /// <summary>
        ///     Metodo get para listar os usuarios que estão no banco de dados
        /// </summary>
        /// <returns>
        ///     Retorno da lista de todos os usuarios
        /// </returns>
        [HttpGet]
        public IActionResult listar()
        {
            List<UsuarioModel> listaDeUsuarios = Context.tbl_usuario.ToList();

            return Ok(listaDeUsuarios);
        }

        /// <summary>
        ///     Cadastra um novo usuario no banco de dados 
        /// </summary>
        /// <param name="usuario">
        ///     recebe o usuario para ser cadastrado no banco
        /// </param>
        /// <returns>
        ///     retorna Ok se foi cadastrado
        /// </returns>
        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            Context.tbl_usuario.Add(usuario);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        ///     Metodo para listar o usuario pelo id
        /// </summary>
        /// <param name="id">
        ///     Recebe o id para conseguir selecionar pelo banco
        /// </param>
        /// <returns>
        ///     Retorna o usuario que foi solicitado pela URL
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            UsuarioModel usuarioRetornado = Context.tbl_usuario.FirstOrDefault(x => x.usuario_id == id);

            return Ok(usuarioRetornado);
        }

        /// <summary>
        ///     Metodo para Excluir o usuario do banco de dados
        /// </summary>
        /// <param name="usuario">
        ///     Parametro usuario serve para localizar o usuario e o excluir
        /// </param>
        /// <returns>
        ///     Retorna Ok se foi excluido com exito
        /// </returns>
        [HttpPut]
        public IActionResult Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioRetornadoAntigo = Context.tbl_usuario.FirstOrDefault(x => x.usuario_id == usuario.usuario_id);
            if (usuarioRetornadoAntigo == null)
            {

                return NotFound();
            }

            usuarioRetornadoAntigo.usuario_id = usuario.usuario_id;
            usuarioRetornadoAntigo.usuario_nome = usuario.usuario_nome;
            usuarioRetornadoAntigo.usuario_email = usuario.usuario_email;
            usuarioRetornadoAntigo.usuario_senha = usuario.usuario_senha;

            Context.tbl_usuario.Update(usuarioRetornadoAntigo);
            Context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioModel usuarioRetornado = Context.tbl_usuario.FirstOrDefault(x => x.usuario_id == id);

            if (usuarioRetornado == null)
            {
                return NotFound();
            }
            Context.tbl_usuario.Remove(usuarioRetornado);
            Context.SaveChanges();
            return Ok();
        }
    }
}