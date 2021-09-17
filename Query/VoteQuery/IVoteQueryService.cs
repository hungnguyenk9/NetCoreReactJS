using NetCoreReactJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Query.VoteQuery
{
    public interface IVoteQueryService
    {
        List<VoteItem> GetListByDate(DateTime date, int pageNum, int pageSize);
        int CountVoteItem(int voteItemId, string email);
    }
}
