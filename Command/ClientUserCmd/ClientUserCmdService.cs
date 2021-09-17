using Dapper;
using NetCoreReactJS.Services;
using System.Data;

namespace NetCoreReactJS.Command.ClientUserCmd
{
    public class ClientUserCmdService : IClientUserCmdService
    {
        private readonly IConnectionService _connection;
        public ClientUserCmdService(IConnectionService connection)
        {
            _connection = connection;
        }
        public int Add(string email, string password)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    
                    string sql = @"
                    INSERT INTO CLIENT_USER
                           ([Email]
                           ,[Password])
                     VALUES
                           (@Email
                           ,@Password)
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Email",email, DbType.String);
                    param.Add("@Password", password, DbType.String);
                    int result = conn.Execute(sql, param, commandType: CommandType.Text);
                    return result;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        
    }
}
