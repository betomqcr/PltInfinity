using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using Microsoft.AspNetCore.Mvc;

namespace InfintyHibotPlt.Controllers
{
    [ApiController]
    [Route("api/hibot")]
    public class ConversationsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Recibir(Request request)
        {
            try
            {
                return Ok("Recibido");
            }
            catch (Exception)
            {

                return Ok("NO Recibido");
            }
            
        }
    }
}
