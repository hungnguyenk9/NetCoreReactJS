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
    public class VoteItem : Vote
    {
        public string Name { get; set; }
        public string VoteContent { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
        
    }
    public class VoteItemInPaging : VoteItem
    {
        public int TotalVote { get; set; }
        public int TotalRow { get; set; }
    }
}
