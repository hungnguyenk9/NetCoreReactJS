using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.DTO
{
    public class DeptDTO
    {
        public string DeptName { get; set; }
        public int? ManId { get; set; }
        public int? DeptId { get; set; }
    }
    public class DeptUpdateDTO : DeptDTO
    {
        public int Id { get; set; }
    }
}
