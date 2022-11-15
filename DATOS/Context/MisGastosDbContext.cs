using DATOS.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DATOS.Context
{
    public class MisGastosDbContext: DbContext
    {
        public DbSet<Ahorros> Ahorros { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        public DbSet<ObjetivosDeAhorro> ObjetivosDeAhorros { get; set; }

        public MisGastosDbContext(DbContextOptions<MisGastosDbContext> options) : base(options)
        { }
    }
}
