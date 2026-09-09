using ActividadAutoaprendizaje.Models;
using Microsoft.EntityFrameworkCore;
namespace ActividadAutoaprendizaje.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Contacto> Contactos { get; set; }
    }
}
