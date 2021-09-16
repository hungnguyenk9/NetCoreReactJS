using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Models.VoteItem
{
    public class VoteItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VoteContent { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
    }
}
