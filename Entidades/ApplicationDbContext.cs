using Microsoft.EntityFrameworkCore;

namespace WebApiPokemon.Entidades
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Entrenador> Entrenador { get; set;}
    }
}
