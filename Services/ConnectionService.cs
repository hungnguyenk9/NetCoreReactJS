using Microsoft.Extensions.Options;
using NetCoreReactJS.Common;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreReactJS.Services
{
    public class ConnectionService : IConnectionService
    {
        private IDbConnection _connection;
        private readonly IOptions<DBConfiguration> _config;
        public ConnectionService(IOptions<DBConfiguration> configs)
        {
            _config = configs;
        }
        public IDbConnection GetConnection()
        {
            if (_connection == null || _connection.ConnectionString == "")
            {
                _connection = new SqlConnection(_config.Value.DbConnectionString);
            }
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
