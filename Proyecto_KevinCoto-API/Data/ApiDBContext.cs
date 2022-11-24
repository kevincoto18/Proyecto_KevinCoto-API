using Microsoft.EntityFrameworkCore;
using Proyecto_KevinCoto_API.Modelo;

namespace Proyecto_KevinCoto_API.Data
{
    public class ApiDBContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<FacturaGeneral> FacturaGeneral { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalle { get; set; }

        public ApiDBContext(DbContextOptions<ApiDBContext> options): base(options)
        {

        }


    }
}
