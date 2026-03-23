using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ServiceApi
{
    public class QuoteDataManager
    {
        public static async Task<List<QuoteModel>> GetQuotesAsync(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");

            client.DefaultRequestHeaders.Add("X-Api-Key","5xpzcZeFrEnZAKIoa8YiLELPGnCePFbusAdQGSao");

            List<QuoteModel> quotes = null;

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                quotes = JsonSerializer.Deserialize<List<QuoteModel>>(responseString);
            }

            return quotes;
        }
    }
}
