using Dapper;
using Microsoft.Extensions.Options;
using NetCoreReactJS.Common;
using NetCoreReactJS.Models;
using NetCoreReactJS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetCoreReactJS.Query.VoteQuery
{
    public class VoteQueryService : IVoteQueryService
    {
        private readonly IConnectionService _connection;
        public VoteQueryService(IOptions<AppSettings> appSettings, IConnectionService connection)
        {
            _connection = connection;
        }

        public int CountVoteItem(int voteItemId, string email)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    string SqlQuery = @"
                    select count(*)
                    from 
	                    VOTE inner join CLIENT_USER 
		                    on VOTE.ClientId = CLIENT_USER.Id 
			                    and CLIENT_USER.Email = @Email
			                    and VOTE.VoteItemId = @VoteItemId
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Email", email, DbType.String);
                    param.Add("@VoteItemId", voteItemId, DbType.Int32);
                    int kq = conn.ExecuteScalar<int>(SqlQuery, param, commandType: CommandType.Text);
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public List<VoteItemInPaging> GetListByDate(DateTime date, int pageNum = 1, int pageSize = 2)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    int skip = (pageNum - 1) * pageSize;
                    int take = pageSize;
                    string SqlQuery = @"
                    select 
                            Id, [Name], VoteContent, Sdate, Edate, CreateTime, 
                            (select count(*) from VOTE v where v.VoteItemId = VOTE_ITEM.Id) TotalVote
                            ,COUNT(*) OVER() TotalRow
                    from VOTE_ITEM
                    where Sdate <= @Date and Edate >= @Date
                    order by CreateTime asc
                    offset     @Skip ROWS
                    fetch next @Take ROWS ONLY
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Date", date.ToString("yyyy-MM-dd"), DbType.Date);
                    param.Add("@Skip", skip, DbType.Int32);
                    param.Add("@Take", take, DbType.Int32);
                    List<VoteItemInPaging> kq = conn.Query<VoteItemInPaging>(SqlQuery, param, commandType: CommandType.Text).ToList();
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        
    }
}
