using Dapper;
using NetCoreReactJS.Models;
using NetCoreReactJS.Services;
using System.Data;

namespace NetCoreReactJS.Command.VoteCmd
{
    public class VoteCmdService : IVoteCmdService
    {
        private readonly IConnectionService _connection;
        public VoteCmdService(IConnectionService connection)
        {
            _connection = connection;
        }
        public int Add(VoteItem voteItem)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    
                    string sql = @"
                    INSERT INTO VOTE_ITEM
                            ([Name]
                            ,[VoteContent]
                            ,[Sdate]
                            ,[Edate]
                            ,[CreateTime])
                     VALUES
                            (@Name
                            ,@VoteContent
                            ,@Sdate
                            ,@Edate
                            ,GETDATE())
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Name", voteItem.Name, DbType.String);
                    param.Add("@VoteContent", voteItem.VoteContent, DbType.String);
                    param.Add("@Sdate", voteItem.Sdate, DbType.Date);
                    param.Add("@Edate", voteItem.Edate, DbType.Date);
                    int result = conn.Execute(sql, param, commandType: CommandType.Text);
                    return result;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public int SubmitVote(int voteItemId, string email)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {

                    string sql = @"
                    INSERT INTO [VOTE]
                               ([ClientId]
                               ,[VoteItemId]
                               ,[CreateTime])
                         VALUES
                               ((select top(1) Id from CLIENT_USER where Email = @Email)
                               ,@VoteItemId
                               ,GETDATE())
                    ";
                    var param = new DynamicParameters();
                    param.Add("@VoteItemId", voteItemId, DbType.Int32);
                    param.Add("@Email", email, DbType.String);
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
