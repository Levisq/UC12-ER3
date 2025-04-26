using Chapter.Web.API.Entities.Livros;
using Chapter.Web.API.Entities.Usuarios;
using Chapter.Web.API.Entities.Reservas;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Web.API.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions <ChapterContext> options) : base(options)
        {
        }
        
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Reserva> Reservas { get; set;}
    }
}