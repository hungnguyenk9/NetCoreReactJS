using System;

namespace NetCoreReactJS.DTO
{
    public class VoteDTO
    {
        public int ClientId { get; set; }
        public string Email { get; set; }
    }
    public class VoteItemDTO
    {
        public string Name { get; set; }
        public string VoteContent { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
    }
}
