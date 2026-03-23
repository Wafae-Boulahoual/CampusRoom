using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusRoom.Presentation.Services
{
    public static class CurrentUserService
    {
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string Education { get; set; }
        public static bool IsLoggedIn // returnera true om UserId !=null
        {
            get // read only
            {
                return !string.IsNullOrEmpty(UserId);
            }
        }
    }
}
