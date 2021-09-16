using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreReactJS.Models.AuthResponse;
using NetCoreReactJS.Models.ClientUser;

namespace NetCoreReactJS.Command.ClientUserCmd
{
    public interface IClientUserCmdService
    {
        int AddUser(string email, string password);
    }
}
