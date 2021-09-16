using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Models.Vote
{
    public class Vote
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VoteItemId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
