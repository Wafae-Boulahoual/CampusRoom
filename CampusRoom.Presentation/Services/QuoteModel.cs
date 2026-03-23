using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.ServiceApi
{
    public class QuoteModel
    {
        [JsonPropertyName("quote")]
        public string Quote { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}
