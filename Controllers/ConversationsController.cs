using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using InfintyHibotPlt.Datos.Models;
using InfintyHibotPlt.Negocio.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InfintyHibotPlt.Controllers
{
    [ApiController]
    [Route("api/hibot")]
    public class ConversationsController : Controller
    {
        private readonly HibotManager hibotManager;
        public ConversationsController() 
        {
            hibotManager = new HibotManager();
        }
        
        [HttpPost]
        public async Task<IActionResult> Recibir(Request request)
        {
            try
            {
                if(request != null)
                {
                    Conversation conversation = new Conversation 
                    {
                        contactName = request.Conversations[0].Contacts[0].Fields.Name,
                        contactPhoneWA = request.Conversations[0].Contacts[0].Account,
                        agente = request.Conversations[0].Agent.Name,
                        agenteEmail = request.Conversations[0].Agent.Email,
                        typing = request.Conversations[0].Typing,
                        estado = request.Conversations[0].Type,
                        idHibotConversation = request.Conversations[0].Id,
                        closed = request.Conversations[0].Closed,
                        create = request.Conversations[0].Created,
                        assigend = request.Conversations[0].Assigned

                    };

                    long idConvesartion = hibotManager.createConversation(conversation);


                    foreach (InMessage temp in request.Conversations[0].Messages)
                    {
                        Messages messages = new Messages
                        {
                            

                        };
                        
                    }
       
                    return Ok("Recibido");
                }
                else
                {
                    return Ok("Recibido");
                }
            }
            catch (Exception)
            {

                return Ok("NO Recibido");
            }
            
        }
    }
}
