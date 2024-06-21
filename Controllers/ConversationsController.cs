using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using InfintyHibotPlt.Datos.Models;
using InfintyHibotPlt.Negocio.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Net;

namespace InfintyHibotPlt.Controllers
{
    [ApiController]
    [Route("api/hibot")]
    public class ConversationsController : Controller
    {
        
        private readonly ApplicationDbContext context;
        public IWebHostEnvironment Environment;
        public ConversationsController(ApplicationDbContext _context, IWebHostEnvironment environment) 
        {
            this.context = _context;
            this.Environment = environment;
        }

        [HttpPost]
        [Route("hibot")]
        public IActionResult HandleWebhook([FromBody] dynamic payload)
        {
            try
            {
                Request request = InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder.Request.FromJson(Convert.ToString(payload));
                if (request != null)
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
                    context.Conversations.Add(conversation);
                    context.SaveChanges();
                    long idConvesartion = context.Conversations.Where(x => x.idHibotConversation.Equals(conversation.idHibotConversation)).First().idConversation;
                    foreach (InMessage temp in request.Conversations[0].Messages)
                    {
                        Messages messages = new Messages
                        {
                            ConversationidConversation = idConvesartion,
                            content = temp.Content,
                            personContent = temp.From,
                            idHibotMessages = temp.Id
                        };

                        if (temp.media != null)
                        {
                            messages.media = temp.media.ToString();
                            messages.mediaType = temp.mediaType;
                        }
                        if (temp.Created != null)
                            messages.created = temp.Created;
                        if (temp.Createdpub != null && temp.Created == null)
                            messages.created = temp.Createdpub;

                        context.Messages.Add(messages);
                        context.SaveChanges();

                        if (temp.media != null)
                        {
                            long idMessage = context.Messages.Where(x => x.idHibotMessages.Equals(temp.Id)).FirstOrDefault().idMessages;

                        }
                    }
                    Bitacora bitacora = new Bitacora
                    {
                        idConversation = idConvesartion,
                        Estado = request.Conversations[0].Typing,
                    };
                    bitacora.jsonEntrada = Serialize.ToJson(request);
                    context.Bitacora.Add(bitacora);
                    context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex) 
            {
                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                context.ErroresBitacora.Add(errorBitacora);
                context.SaveChanges();

                return Ok();
            }
        }
     
         
        [HttpPost]
        [Route("ObtenerScript")]
        public async Task<IActionResult> ObtenerRutaDelProyecto()
        {
            try
            {
                WebClient webClient = new WebClient();
                Uri myUri = new Uri(@"https://assets.hibot.us/images/hbt-content-based/c0daaac0df65541a2d88cd667027dc49792f55eac9c8f5641f05a092542695b1@jpg", UriKind.Absolute);
                var filename = System.IO.Path.Combine(Environment.ContentRootPath, "Download");
                webClient.DownloadFile(myUri, filename);

                return Ok();
                
            }
            catch (Exception ex)
            {

                return Ok(ex);
            }
        }
    }
}
