using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Models
{
    public class Dept
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public int ManId { get; set; }
        public int DeptId { get; set; }
    }
}
