using System;

namespace Sistema_de_cadastro_de_tarefas.Models
{
    public class TarefaModel
    {
        public int id_tarefa { get; set; }
        public string nome_tarefa { get; set; }
        public string descricao_tarefa { get; set; }
        public DateTime DataTerefa { get; set; }
    }
}