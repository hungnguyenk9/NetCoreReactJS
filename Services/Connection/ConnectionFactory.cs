using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
//using NPWeb.Models;

namespace NetCoreReactJS.Services.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IDbConnection _connection;
        private readonly IOptions<DBConfiguration> _config;
        public ConnectionFactory(IOptions<DBConfiguration> configs)
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
