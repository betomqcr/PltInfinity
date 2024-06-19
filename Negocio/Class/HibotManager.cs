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

        public void createMessages(Messages messages) 
        {
            try
            {
                context.Messages.Add(messages);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void createBitacora(Bitacora bitacora)
        {
            try
            {
                context.Bitacora.Add(bitacora);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
