using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string StfName { get; set; }
        public string StfId { get; set; }
        public int DeptId { get; set; }
        public int PosId { get; set; }
        public int ManId { get; set; }
        public int IsDel { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
