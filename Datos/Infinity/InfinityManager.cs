using InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder;
using InfintyHibotPlt.Datos.Infinity.Items;
using InfintyHibotPlt.Datos.Infinity.Models;
using InfintyHibotPlt.Datos.Models;
using Newtonsoft.Json;
using System.Text;

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
        public List<AgentConfig> Agents { get; set; }
        public InfinityManager(IConfiguration configuration, ApplicationDbContext _context)
        {
            this.Configuration = configuration;
            this.Context = _context;
            this.Board = Configuration["Infinity:Token"];
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
            CargarAgents();

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

                throw;
            }
        }
        public InfintyHibotPlt.Datos.Infinity.Items.Response.Response InsertItemAPI( Item item)// obtener las ventas del api
        {
            try
            {
                InfintyHibotPlt.Datos.Infinity.Items.Response.Response marca = new InfintyHibotPlt.Datos.Infinity.Items.Response.Response();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            ApiUrl, new StringContent(item.ToJson(), Encoding.UTF8, "application/json"));
                    });

                    HttpResponseMessage message = task.Result;

                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
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
                throw ex;
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

                if(pregunta.Equals(Status) || pregunta.Equals(Origen))
                {
                    List<Guid> guids = new List<Guid>();
                    Guid guid = Guid.Parse(respuesta);
                    guids.Add(guid);

                    Value.Data = guids;
                }
                else
                {
                    Value.Data = respuesta; 
                }
                return Value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void CreateItemInfinity(long id)
        {
            try
            {
                Conversation conversation = Context.Conversations.Find(id);
                if(conversation!=null)
                {


                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
