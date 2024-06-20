using InfintyHibotPlt.Datos.Models;

namespace InfintyHibotPlt.Datos.Hibot
{
    public class HibotManager
    {
        public IWebHostEnvironment Environment { get; }
        public HibotManager(IWebHostEnvironment environment) 
        {
            Environment = environment;
        }

        

        public void ProcessImage(Messages messages)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
