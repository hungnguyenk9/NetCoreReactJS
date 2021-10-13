using Dapper;
using NetCoreReactJS.Services;
using System.Data;

namespace NetCoreReactJS.Command.DeptCmd
{
    public class DeptCmdService : IDeptCmdService
    {
        private readonly IConnectionService _connection;
        public DeptCmdService(IConnectionService connection)
        {
            _connection = connection;
        }
        public int Add(string DeptName, int? ManId, int? DeptId)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {

                    string sql = @"
                    INSERT INTO Dept
                           ([DeptName]
                           ,[ManId]
                           ,[DeptId])
                     VALUES
                           (@DeptName
                           ,@ManId
                           ,@DeptId)
                    ";
                    var param = new DynamicParameters();
                    param.Add("@DeptName", DeptName, DbType.String);
                    param.Add("@ManId", ManId, DbType.Int32);
                    param.Add("@DeptId", DeptId, DbType.Int32);
                    int result = conn.Execute(sql, param, commandType: CommandType.Text);
                    return result;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public int Update(int Id, string DeptName, int? ManId, int? DeptId)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {

                    string sql = @"
                        UPDATE [Dept]
                           SET [DeptName] = @DeptName
                              ,[ManId] = @ManId
                              ,[DeptId] = @DeptId
                         WHERE Id = @Id
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Id", Id, DbType.Int32);
                    param.Add("@DeptName", DeptName, DbType.String);
                    param.Add("@ManId", ManId, DbType.Int32);
                    param.Add("@DeptId", DeptId, DbType.Int32);
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
