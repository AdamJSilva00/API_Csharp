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

        [HttpGet]
        public IActionResult listar()
        {
            List<TarefaModel> Lista = conexao.registros_tarefas.ToList();
            return Ok(Lista);
        }

        [HttpPost]
        public IActionResult cadastrar(TarefaModel insert)
        {
            conexao.registros_tarefas.Add(insert);
            conexao.SaveChanges();
            return Ok();
        }

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
            return Ok();
        }

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
            return Ok();
        }

    }
}