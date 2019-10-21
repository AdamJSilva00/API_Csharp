using aula2.models;
using Microsoft.EntityFrameworkCore;

namespace aula2.Context
{
    public class Aula2Context : DbContext
    {
        public Aula2Context() { }

        public Aula2Context(DbContextOptions<Aula2Context> options) : base(options)
        {

        }

        public virtual DbSet<UsuarioModel> tbl_usuario{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-PEJCJJI\SQLEXPRESS;DataBase=aula_api;Integrated Security=true");
            }

        }
    }
}