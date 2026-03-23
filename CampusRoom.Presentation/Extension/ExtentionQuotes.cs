using CampusRoom.Presentation.ServiceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.Extension
{
    public static class ExtentionQuotes
    {
        public static (string text, string author) GetSafeQuote(this List<QuoteModel> quotes)
        {
            if (quotes != null && quotes.Count > 0)
            {
                return (quotes[0].Quote, quotes[0].Author);
            }

            return ("Stay motivated!", "");
        }
    }
}
