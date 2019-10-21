using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_cadastro_de_tarefas.Context;
using Sistema_de_cadastro_de_tarefas.Models;

namespace Sistema_de_cadastro_de_tarefas.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class TarefaController : ControllerBase
    {

        TarefaContext conexao = new TarefaContext();

        /// <summary>
        ///     Lista de tarefas
        /// </summary>
        /// <returns>
        ///     Função que retorna o conteudo do banco dem forma de lista
        /// </returns>
        [HttpGet]
        public IActionResult listar()
        {
            List<TarefaModel> Lista = conexao.registros_tarefas.ToList();
            return Ok(Lista);
        }

        /// <summary>
        ///     Cadastrar no banco
        /// </summary>
        /// <param name="insert">
        ///     Parametro para pegar as informações inscritas e inserir no banco
        /// </param>
        /// <returns>
        ///     Retorna sucesso quando for cadastrado 
        /// </returns>
        [HttpPost]
        public IActionResult cadastrar(TarefaModel insert)
        {
            conexao.registros_tarefas.Add(insert);
            conexao.SaveChanges();
            return Ok("Cadastro realizado com sucesso");
        }
        
        /// <summary>
        ///     Atualizar dados no banco
        /// </summary>
        /// <param name="update">
        ///     Parametro para atualizar os registros
        /// </param>
        /// <returns>
        ///     Retorna sucesso quando for atualizado
        /// </returns>
        [HttpPut]
        public IActionResult Atualizar(TarefaModel update)
        {
            TarefaModel up = conexao.registros_tarefas.FirstOrDefault(a => a.id_tarefa == update.id_tarefa);
            if (up == null)
            {
                return NotFound();
            }

            up.id_tarefa = update.id_tarefa;
            up.nome_tarefa = update.nome_tarefa;
            up.descricao_tarefa = update.descricao_tarefa;
            up.data_tarefa = update.data_tarefa;

            conexao.registros_tarefas.Update(up);
            conexao.SaveChanges();
            return Ok("Atualização realizada com sucesso");
        }

        /// <summary>
        ///     Deletar usuario
        /// </summary>
        /// <param name="id">
        ///     Trazer o id do usuario por meio da url para deletar
        /// </param>
        /// <returns>
        ///     Sucesso quando for excluido
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            TarefaModel del = conexao.registros_tarefas.FirstOrDefault(a => a.id_tarefa == id);
            if (del == null)
            {
                return NotFound();
            }

            conexao.registros_tarefas.Remove(del);
            conexao.SaveChanges();
            return Ok("Excluido com sucesso");
        }

    }
}