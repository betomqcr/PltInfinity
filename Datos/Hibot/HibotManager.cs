using InfintyHibotPlt.Datos.Models;
using System;

namespace InfintyHibotPlt.Datos.Hibot
{
    public class HibotManager
    {
        
        public HibotManager() 
        {
            
        }

        

        public async Task<string> ProcessImage(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var fileBytes = await response.Content.ReadAsByteArrayAsync();
                        return Convert.ToBase64String(fileBytes);
                    }
                    else
                    {
                        
                        return null;
                    }
                }
                catch (Exception ex)
                {

                    return ex.ToString();  
                }
            }

        }

       
    }
}
