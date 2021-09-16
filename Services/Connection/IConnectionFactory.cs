using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Services.Connection
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
        void CloseConnection();
    }
}
