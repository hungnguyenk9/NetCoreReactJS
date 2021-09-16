using NetCoreReactJS.Models.AuthResponse;
using NetCoreReactJS.Models.ClientUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Query.ClientUserQuery
{
    public interface IClientUserQueryService
    {
        ClientUser GetOneByEmail(string email);
        int Authenticate(string email, string password);
        AuthRes GetToken(string email, string password);

    }
}
