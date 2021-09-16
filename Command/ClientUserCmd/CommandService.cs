using NetCoreReactJS.Models.AuthResponse;
using NetCoreReactJS.Models.ClientUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Command.ClientUserCmd
{
    public class CommandService : ICommandService
    {
        CommandService()
        {

        }
        public ClientUser AddUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public ClientUser Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public ClientUser GetOneByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public AuthRes GetToken(ClientUser users)
        {
            throw new NotImplementedException();
        }
    }
}
