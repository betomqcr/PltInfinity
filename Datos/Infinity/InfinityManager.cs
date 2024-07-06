using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using InfintyHibotPlt.Datos.Infinity.Comments;
using InfintyHibotPlt.Datos.Infinity.Items;
using InfintyHibotPlt.Datos.Infinity.Models;
using InfintyHibotPlt.Datos.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System;
using System.Text.RegularExpressions;
using InfintyHibotPlt.Datos.Infinity.Attachaments;
using InfintyHibotPlt.Datos.Infinity.Attachaments.Response;

namespace InfintyHibotPlt.Datos.Infinity
{
    public class InfinityManager
    {
        public IConfiguration Configuration;
        public ApplicationDbContext Context;
        public string Token {  get; set; }
        public string ApiUrl { get; set; }
        public string Agente1 { get; set; }
        public string Agente2 { get; set; }
        public string Agente3 { get; set; }
        public string Agente1Nom { get; set; }
        public string Agente2Nom { get; set; }
        public string Agente3Nom { get; set; }
        public string Status { get; set; }
        public string StatusTiketOpen { get; set; }
        public string Name { get; set; }
        public string AssignedPor { get; set; }
        public string NumWA { get; set; }
        public string Origen { get; set; }
        public string OrigenResp { get; set; }
        public string WorkSpace { get; set; }
        public string Board { get; set; }
        public string Folder { get; set; }
        public string TypeSupport { get; set; }
        public string TypeSupportRes { get; set; }
        public List<AgentConfig> Agents { get; set; }
        public string HibotStatus {  get; set; }            
        public string HibotStatusInactividad { get; set; }
        public string HibotStatusTerminado { get; set; }
        public string HibotStatusPendiente { get; set; }
        public string HibotStatusAdministrativa { get; set; }
        public string HibotStatusVentas { get; set; }
        public string HibotStatusProgramacion { get; set; }
        public string Clinica { get; set; }
        public Attachaments.Response.ResponseAttach ResponseAttach { get; set; }
        public InfinityManager(IConfiguration configuration, ApplicationDbContext _context)
        {
            this.Configuration = configuration;
            this.Context = _context;
            this.Board = Configuration["Infinity:Board"];
            this.WorkSpace = Configuration["Infinity:WorkSpace"];
            this.Folder = Configuration["Infinity:Folder"];
            this.Token = Configuration["Infinity:Token"];
            this.ApiUrl = Configuration["Infinity:UrlApi"];
            this.Status = Configuration["Infinity:Status"];
            this.StatusTiketOpen = Configuration["Infinity:StatusTiketOpen"];
            this.Agente1 = Configuration["Infinity:Agente1"];
            this.Agente1Nom = Configuration["Infinity:Agente1Nom"];
            this.Agente2 = Configuration["Infinity:Agente2"];
            this.Agente2Nom = Configuration["Infinity:Agente2Nom"];
            this.Agente3 = Configuration["Infinity:Agente3"];
            this.Agente3Nom = Configuration["Infinity:Agente3Nom"];
            this.Name = Configuration["Infinity:Name"];
            this.AssignedPor = Configuration["Infinity:AssignedPor"];
            this.NumWA = Configuration["Infinity:NumWA"];
            this.Origen = Configuration["Infinity:Origen"];
            this.OrigenResp = Configuration["Infinity:OrigenResp"];
            this.TypeSupport = Configuration["Infinity:TypeSupport"];
            this.TypeSupportRes = Configuration["Infinity:TypeSupportRes"];
            this.HibotStatus = Configuration["Infinity:HibotStatus"];
            this.HibotStatusAdministrativa = Configuration["Infinity:HibotStatusAdministrativa"];
            this.HibotStatusInactividad = Configuration["Infinity:HibotStatusInactividad"];
            this.HibotStatusPendiente = Configuration["Infinity:HibotStatusPendiente"];
            this.HibotStatusProgramacion = Configuration["Infinity:HibotStatusProgramacion"];
            this.HibotStatusTerminado = Configuration["Infinity:HibotStatusTerminado"];
            this.HibotStatusVentas = Configuration["Infinity:HibotStatusVentas"];
            this.Clinica = Configuration["Infinity:Clinica"];
            CargarAgents();
            this.ResponseAttach = new Attachaments.Response.ResponseAttach();

        }
        public void CargarAgents()
        {
            try
            {
                Agents = new List<AgentConfig>();

                AgentConfig agent1 = new AgentConfig
                {
                    AgenteCod = int.Parse(Agente1),
                    Nombre = Agente1Nom
                };
                AgentConfig agent2 = new AgentConfig
                {
                    AgenteCod = int.Parse(Agente2),
                    Nombre = Agente2Nom
                };
                AgentConfig agent3 = new AgentConfig
                {
                    AgenteCod = int.Parse(Agente3),
                    Nombre = Agente3Nom
                };

                Agents.Add(agent1);
                Agents.Add(agent2);
                Agents.Add(agent3);

            }
            catch (Exception ex)
            {

                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        public InfintyHibotPlt.Datos.Infinity.Items.Response.Response InsertItemAPI( Item item)// obtener las ventas del api
        {
            try
            {
                InfintyHibotPlt.Datos.Infinity.Items.Response.Response marca = new InfintyHibotPlt.Datos.Infinity.Items.Response.Response();
                string url = ApiUrl + "/api/v2/workspaces/" + WorkSpace + "/boards/" + Board + "/items";
                string contenido = item.ToJson();
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                           url , new StringContent(contenido, Encoding.UTF8, "application/json"));
                    });

                    HttpResponseMessage message = task.Result;

                    if (message.StatusCode == System.Net.HttpStatusCode.Created)
                    {

                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        var jsonstrig = task2.Result;
                        marca = JsonConvert.DeserializeObject<InfintyHibotPlt.Datos.Infinity.Items.Response.Response>(jsonstrig);

                        return marca;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return marca;
                    }

                }
                return marca;
            }
            catch (Exception ex)
            {
                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();

                return null;
            }
        }
        public void insertComment(string item,Comment coments)// obtener las ventas del api
        {
            try
            {
                InfintyHibotPlt.Datos.Infinity.Items.Response.Response marca = new InfintyHibotPlt.Datos.Infinity.Items.Response.Response();
                string url = ApiUrl + "/api/v2/workspaces/" + WorkSpace + "/boards/" + Board + "/items/"+item+"/comments";
                string contenido = coments.ToJson();
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                           url, new StringContent(contenido, Encoding.UTF8, "application/json"));
                    });

                    HttpResponseMessage message = task.Result;

                    if (message.StatusCode == System.Net.HttpStatusCode.Created)
                    {

                        //    var task2 = Task<string>.Run(async () =>
                        //    {
                        //        return await message.Content.ReadAsStringAsync();
                        //    });
                        //    var jsonstrig = task2.Result;
                        //    marca = JsonConvert.DeserializeObject<InfintyHibotPlt.Datos.Infinity.Items.Response.Response>(jsonstrig);


                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {

                    }

                }
                
            }
            catch (Exception ex)
            {
                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        public Value ValueItem(string pregunta, string respuesta)
        {
            try
            {
                Value Value = new Value
                {
                    AttributeId= Guid.Parse(pregunta),
                    
                };

                if(pregunta.Equals(Status) || pregunta.Equals(Origen)||pregunta.Equals(TypeSupport)||pregunta.Equals(HibotStatus))
                {
                    List<Datum> guids = new List<Datum>();
                    Datum guid = Guid.Parse(respuesta);
                    guids.Add(guid);

                    Value.Data = guids;
                }
                else
                {
                    if (pregunta.Equals(AssignedPor))
                    {
                        List<Datum> res = new List<Datum>();
                        long data = int.Parse(respuesta);
                        res.Add(data);

                        Value.Data = res;
                    }
                    else
                    {
                        Value.Data = respuesta;
                    }
                }
                return Value;
            }
            catch (Exception ex)
            {
                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();

                return null;
            }
        }
        public  Stream Stream(byte[] archivo)
        {
            try
            {
                return new MemoryStream(archivo)
                {
                    Position = 0
                };

            }
            catch (Exception ex)
            {
                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
                return null;
            }
        }
        public void CreateItemInfinity(long id)
        {
            try
            {
                Conversation conversation = Context.Conversations.Find(id);
                if(conversation!=null)
                {
                    string status = SelectResponseStatusHibot(conversation.typing);
                    List<Value> values = new List<Value>();
                    Value Value1 = ValueItem(Status, StatusTiketOpen);
                    Value Value2 = ValueItem(NumWA, conversation.contactPhoneWA);
                    Value Value3 = ValueItem(Name, conversation.contactName);
                    Value Value4 = ValueItem(Origen, OrigenResp);
                    Value Value5 = ValueItem(AssignedPor, Agents.Where(x=>x.Nombre.Equals(conversation.agente)).FirstOrDefault().AgenteCod.ToString());
                    Value Value6 = ValueItem(TypeSupport, TypeSupportRes);
                    Value Value7 = ValueItem(HibotStatus,status);
                    Value Value8 =ValueItem(Clinica,conversation.clinica);
                    values.Add(Value1);
                    values.Add(Value2);
                    values.Add(Value3);
                    values.Add(Value4);
                    values.Add(Value5);
                    values.Add(Value6);
                    values.Add(Value7);
                    values.Add(Value8);
                    Item item = new Item
                    {
                        FolderId = Folder,
                        Values = values
                    };
                    InfintyHibotPlt.Datos.Infinity.Items.Response.Response ItemResponse= InsertItemAPI(item);
                    conversation.idItemInfinity= ItemResponse.Id.ToString();
                    Context.Update(conversation);
                    Context.SaveChanges();
                    List<Messages> messages = Context.Messages.Where(x=>x.ConversationidConversation==conversation.idConversation).ToList();
                    foreach(Messages temp in messages)
                    {
                        if(temp.mediaType==null || temp.mediaType.Equals("RICHLINK"))
                        CreateComentsItem(conversation.idItemInfinity,temp);
                        else
                        {
                            Imagenes imagenes = Context.Imagenes.Where(x => x.messagesidMessages == temp.idMessages).FirstOrDefault();
                            if (imagenes!=null)
                            {
                                Uri uri = new Uri(temp.media);
                                Attachament attachament = new Attachament 
                                {
                                    Url= uri
                                }; 
                                CreateImageForComments(attachament);

                                CreateComentsItemFile(conversation.idItemInfinity, ResponseAttach, temp);

                            }
                            
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        public void CreateComentsItem(string id, Messages mensaje)
        {
            try
            {
                Comment coment = new Comment
                {
                    Text = "<p><h3>"+mensaje.personContent+"</h3><br>"+mensaje.content+"<p/>"
                };
                insertComment(id, coment);
            }
            catch (Exception ex)
            {

                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        public void CreateComentsItemFile(string id, Attachaments.Response.ResponseAttach attach, Messages mensagge )
        {
            try
            {
                string objetoAttach = attach.ToJson();

                string text1 = $@"<p><a href=\"+attach.Link;
                string text2 = $@"data-attachment=\"+objetoAttach;
                string text3 = $@"\"+ "target=\"_blank\" rel=\"noopener noreferrer nofollow\">"+attach.Basename+"."+attach.Extension+"</a></p>";                            

                Comment coment = new Comment
                {
                    Text = text1+text2+text3
                };
                insertComment(id, coment);
            }
            catch (Exception ex)
            {

                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        public async void  CreateImageForComments(Stream file,string Type)
        {
            try
            {             

                var form = new MultipartFormDataContent();
                form.Add(new StreamContent(file));
                string url = ApiUrl + "/api/v2/workspaces/" + WorkSpace +"/attachments/file";
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer " + Token);
                request.Content= form;
                var response = await client.SendAsync(request);
                if(response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Attachaments.Response.ResponseAttach responseAttach = new Attachaments.Response.ResponseAttach();
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await response.Content.ReadAsStringAsync();
                    });
                    var jsonstrig = task2.Result;
                    ResponseAttach = JsonConvert.DeserializeObject<Attachaments.Response.ResponseAttach>(jsonstrig);
                    
                }
                else
                {
                    ResponseAttach = null;
                }

                
            }
            catch (Exception ex)
            {

                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        public async void CreateImageForComments(Attachaments.Attachament attachaments)
        {
            try
            {
                string url = ApiUrl + "/api/v2/workspaces/" + WorkSpace + "/attachments/url";
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer " + Token);
                var content = new StringContent(attachaments.ToJson(), null, "application/json");
                request.Content = content;

                var response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Attachaments.Response.ResponseAttach responseAttach = new Attachaments.Response.ResponseAttach();
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await response.Content.ReadAsStringAsync();
                    });
                    var jsonstrig = task2.Result;
                    ResponseAttach = JsonConvert.DeserializeObject<Attachaments.Response.ResponseAttach>(jsonstrig);

                }
                else
                {
                    ResponseAttach = null;
                }
            }
            catch (Exception ex)
            {
                ErroresBitacora errorBitacora = new ErroresBitacora();
                errorBitacora.menssageError = ex.ToString();
                errorBitacora.Fecha = DateTime.Now;
                Context.ErroresBitacora.Add(errorBitacora);
                Context.SaveChanges();
            }
        }
        //public string SelectResponseStatusHibot(string request)
        //{
        //    try
        //    {
        //        if (HibotStatusInactividad.Equals(request))
        //            return HibotStatusInactividad;
        //        if (HibotStatusTerminado.Equals(request))
        //            return HibotStatusTerminado;
        //        if (HibotStatusPendiente.Equals(request))
        //            return HibotStatusPendiente;
        //        if(HibotStatusAdministrativa.Equals(request))
        //            return HibotStatusAdministrativa;
        //        if (HibotStatusVentas.Equals(request))
        //            return HibotStatusVentas;
        //        if (HibotStatusProgramacion.Equals(request))
        //            return HibotStatusProgramacion;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        return "";
        //    }
        //}
        public string SelectResponseStatusHibot(string request)
        {
            try
            {
                if (request.Equals("Inactividad"))
                    return HibotStatusInactividad;
                if (request.Equals("Soporte terminado"))
                    return HibotStatusTerminado;
                if (request.Equals("Soporte Pendiente"))
                    return HibotStatusPendiente;
                if (request.Equals("Consulta Administrativa"))
                    return HibotStatusAdministrativa;
                if (request.Equals("Traslado Ventas"))
                    return HibotStatusVentas;
                if (request.Equals("Programacion"))
                    return HibotStatusProgramacion;
                return "7f6abc58-8dcc-4b1e-b827-3fcfb76b190e";
            }
            catch (Exception ex)
            {

                return "7f6abc58-8dcc-4b1e-b827-3fcfb76b190e";
            }
        }

    }
}
