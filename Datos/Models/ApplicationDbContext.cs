using Microsoft.EntityFrameworkCore;

namespace InfintyHibotPlt.Datos.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

    }
}
