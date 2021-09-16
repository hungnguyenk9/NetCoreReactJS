using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Controllers.UserController
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AuthDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
