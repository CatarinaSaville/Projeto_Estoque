using EvoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoEstoque.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        { }

        public DbSet<Mercadoria> Mercadoria { get; set; }
    }
}
