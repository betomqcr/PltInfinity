using InfintyHibotPlt.Datos.Hibot;
using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using InfintyHibotPlt.Datos.Infinity;
using InfintyHibotPlt.Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Dynamic;
using System.Net;

namespace InfintyHibotPlt.Controllers
{
    [ApiController]
    [Route("api/hibot")]
    public class ConversationsController : Controller
    {
        
        private readonly ApplicationDbContext context;
        public readonly IConfiguration configuration;
        public readonly InfinityManager infinity ;
        public ConversationsController(ApplicationDbContext _context, IConfiguration _configuration) 
        {
            this.context = _context;
            this.configuration = _configuration;
            this.infinity = new InfinityManager(configuration, context);
        }

        

        [HttpPost]
        [Route("recibir")]
        public async Task<IActionResult> HandleWebhook([FromBody] dynamic payload)
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
                            string media = temp.media.ToString() ?? "";
                            if (!temp.mediaType.Equals("STICKER"))
                            {
                                HibotManager hibot = new HibotManager();
                                long idMessage = context.Messages.Where(x => x.idHibotMessages.Equals(temp.Id) && !x.mediaType.Equals("STICKER")).FirstOrDefault().idMessages;
                                string file = await hibot.ProcessImage(media);
                                 Imagenes imagenes = new Imagenes
                                 {
                                     fecha = DateTimeOffset.Now,
                                     Archivo = file,
                                     messagesidMessages = idMessage
                                 };                                
                                context.Imagenes.Add(imagenes);
                                context.SaveChanges();
                            }                          

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
                    InfinityManager infinity = new InfinityManager(configuration, context);
                    infinity.CreateItemInfinity(idConvesartion);

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
        [Route("recibir1")]
        public async Task<IActionResult> HandleWebhook1([FromBody] Request request)
        {
            try
            {               
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
                            string media = temp.media.ToString() ?? "";
                            if (!temp.mediaType.Equals("STICKER"))
                            {
                                HibotManager hibot = new HibotManager();
                                long idMessage = context.Messages.Where(x => x.idHibotMessages.Equals(temp.Id) && !x.mediaType.Equals("STICKER")).FirstOrDefault().idMessages;
                                string file = await hibot.ProcessImage(media);
                                Imagenes imagenes = new Imagenes
                                {
                                    fecha = DateTimeOffset.Now,
                                    Archivo = file,
                                    messagesidMessages = idMessage
                                };
                                context.Imagenes.Add(imagenes);
                                context.SaveChanges();
                            }

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
                    infinity.CreateItemInfinity(idConvesartion);

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





    }
}
