using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Floor
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FloorNumber { get; set; }
        public string Description { get; set; }
    }
}
