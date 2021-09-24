using Microsoft.EntityFrameworkCore;

namespace api_livraria_dio.Services
{
    public class LivrariaContext : DbContext
    {

        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        { }

        public DbSet<Livro> Livros { get; set; }
    }
}