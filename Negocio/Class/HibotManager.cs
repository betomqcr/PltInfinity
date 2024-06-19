using InfintyHibotPlt.Datos.Models;

namespace InfintyHibotPlt.Negocio.Class
{
    public class HibotManager
    {
        private readonly ApplicationDbContext context;
        
        public HibotManager() 
        {
            context = new ApplicationDbContext();
        }

        public long createConversation(Conversation conversation)
        {
            try
            {
                context.Conversations.Add(conversation);
                if(context.SaveChanges()==1)
                {
                    return context.Conversations.Where(x=> x.idHibotConversation.Equals(conversation.idHibotConversation)).First().idConversation;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
    }
}
