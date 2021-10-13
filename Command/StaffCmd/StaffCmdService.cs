using Dapper;
using NetCoreReactJS.Models;
using NetCoreReactJS.Services;
using System.Data;

namespace NetCoreReactJS.Command.StaffCmd
{
    public class StaffCmdService : IStaffCmdService
    {
        private readonly IConnectionService _connection;
        public StaffCmdService(IConnectionService connection)
        {
            _connection = connection;
        }
        public int Add(Staff staff)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {

                    string sql = @"
                    INSERT INTO [dbo].[Staff]
                           ([StfName]
                           ,[DeptId]
                           ,[PosId]
                           ,[ManId]
                           ,[CreateTime])
                     VALUES
                           (@StfName
                           ,@DeptId
                           ,@PosId
                           ,@ManId
                           ,GETDATE())
                    ";
                    var param = new DynamicParameters();
                    param.Add("@StfName", staff.StfName, DbType.String);
                    param.Add("@DeptId", staff.DeptId, DbType.Int32);
                    param.Add("@PosId", staff.PosId, DbType.Int32);
                    param.Add("@ManId", staff.ManId, DbType.Int32);
                    int result = conn.Execute(sql, param, commandType: CommandType.Text);
                    return result;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public int Delete(int Id)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {

                    string sql = @"
                        UPDATE [Staff]
                           SET [IsDel] = 1
                              ,[UpdateTime] = GETDATE()
                         WHERE Id = @Id
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Id", Id, DbType.Int32);
                    int result = conn.Execute(sql, param, commandType: CommandType.Text);
                    return result;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public int Update(Staff staff)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {

                    string sql = @"
                        UPDATE [Staff]
                           SET [StfName] = @StfName
                              ,[DeptId] = @DeptId
                              ,[PosId] = @PosId
                              ,[ManId] = @ManId
                              ,[UpdateTime] = GETDATE()
                         WHERE Id = @Id
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Id", staff.Id, DbType.Int32);
                    param.Add("@StfName", staff.StfName, DbType.String);
                    param.Add("@DeptId", staff.DeptId, DbType.Int32);
                    param.Add("@PosId", staff.PosId, DbType.Int32);
                    param.Add("@ManId", staff.ManId, DbType.Int32);
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
