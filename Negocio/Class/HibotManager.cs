using InfintyHibotPlt.Datos.Models;

namespace InfintyHibotPlt.Negocio.Class
{
    public class HibotManager
    {
        private readonly ApplicationDbContext context;
        
        public HibotManager(ApplicationDbContext _context) 
        {
            this.context = _context;
        }

        

    }
}
