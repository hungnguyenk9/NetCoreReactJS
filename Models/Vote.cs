using System;

namespace NetCoreReactJS.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VoteItemId { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class VoteItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VoteContent { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
        public DateTime CreateTime { get; set; }
        public int TotalVote { get; set; }
    }
}
