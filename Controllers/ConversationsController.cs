using InfintyHibotPlt.Datos.Hibot;
using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using InfintyHibotPlt.Datos.Infinity;
using InfintyHibotPlt.Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
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
        public async Task<IActionResult> RecibirConversacion([FromBody] dynamic payload)
        {
            try
            {
                Request request = InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder.Request.FromJson(Convert.ToString(payload));
                Entrada Entrada = new Entrada
                {
                    fechaEntrada = DateTimeOffset.Now,
                    idChat = request.Conversations[0].Id
                };
                Entrada.JsonEntrada = Serialize.ToJson(request);
                context.Entrada.Add(Entrada);
                context.SaveChanges();
                List<Conversation> existe = context.Conversations.Where(x => x.idHibotConversation.Equals(request.Conversations[0].Id)).ToList();
                if (existe.Count == 0)
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
                            assigend = request.Conversations[0].Assigned,
                            clinica = request.Conversations[0].Contacts[0].Fields.Clinica
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
                        Bitacora bitacora2 = new Bitacora
                        {
                            idConversation = idConvesartion,
                            Estado = request.Conversations[0].Typing,
                        };
                        bitacora2.jsonEntrada = Serialize.ToJson(request);
                        context.Bitacora.Add(bitacora2);
                        context.SaveChanges();
                        //InfinityManager infinity = new InfinityManager(configuration, context);
                        infinity.CreateItemInfinity(idConvesartion);

                        return Ok();
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    Bitacora bitacora4 = new Bitacora
                    {
                        idConversation = 0,
                        Estado = "Conversacion existente",
                    };
                    bitacora4.jsonEntrada = Serialize.ToJson(request);
                    context.Bitacora.Add(bitacora4);
                    context.SaveChanges();
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
        [Route("recibir2")]
        public async Task<IActionResult> HandleWebhook2(long id)
        {
            try
            {
                if (id != null && id>0)
                {
                    infinity.CreateItemInfinity(id);

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
        [Route("TestLocal")]
        public async Task<IActionResult> RecibirConversacion([FromBody] Request request)
        {
            try
            {
                //Request request = InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder.Request.FromJson(Convert.ToString(payload));
                Entrada Entrada = new Entrada
                {
                    fechaEntrada = DateTimeOffset.Now,
                    idChat = request.Conversations[0].Id
                };
                Entrada.JsonEntrada = Serialize.ToJson(request);
                context.Entrada.Add(Entrada);
                context.SaveChanges();
                List<Conversation> existe = context.Conversations.Where(x => x.idHibotConversation.Equals(request.Conversations[0].Id)).ToList();
                if (existe.Count == 0)
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
                            assigend = request.Conversations[0].Assigned,
                            clinica = request.Conversations[0].Contacts[0].Fields.Clinica
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
                        Bitacora bitacora2 = new Bitacora
                        {
                            idConversation = idConvesartion,
                            Estado = request.Conversations[0].Typing,
                        };
                        bitacora2.jsonEntrada = Serialize.ToJson(request);
                        context.Bitacora.Add(bitacora2);
                        context.SaveChanges();
                        //InfinityManager infinity = new InfinityManager(configuration, context);
                        infinity.CreateItemInfinity(idConvesartion);

                        return Ok();
                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    Bitacora bitacora4 = new Bitacora
                    {
                        idConversation =0,
                        Estado = "Conversacion existente",
                    };
                    bitacora4.jsonEntrada = Serialize.ToJson(request);
                    context.Bitacora.Add(bitacora4);
                    context.SaveChanges();
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
