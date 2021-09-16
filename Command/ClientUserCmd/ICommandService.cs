using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreReactJS.Models.AuthResponse;
using NetCoreReactJS.Models.ClientUser;

namespace NetCoreReactJS.Command.ClientUserCmd
{
    interface ICommandService
    {
        ClientUser Authenticate(string email, string password);
        AuthRes GetToken(ClientUser users);
        ClientUser AddUser(string email, string password);
        ClientUser GetOneByEmail(string email);
    }
}
