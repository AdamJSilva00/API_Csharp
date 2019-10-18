using aula2.models;
using Microsoft.EntityFrameworkCore;

namespace aula2.Controllers
{
    public class Aula2Context : DbContext
    {
        // Construtor
        public Aula2Context() { }

        // Cofigurando o acesso ao banco
        public Aula2Context(DbContextOptions<Aula2Context> options) : base(options)
        {

        }

        public virtual DbSet<UsuarioModel> tbl_usuario{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;DataBase=aula_api;Integrated Security=true");
            }
        }
    }
}