using Microsoft.EntityFrameworkCore;
using Sistema_de_cadastro_de_tarefas.Models;

namespace Sistema_de_cadastro_de_tarefas.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext() { }

        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) { }

        public virtual DbSet<TarefaModel> registros_tarefas{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;DataBase=tarefas;Integrated Security=true");
            }

        }
    }
}