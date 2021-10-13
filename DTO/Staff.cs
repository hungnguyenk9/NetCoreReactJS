using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.DTO
{
    public class StaffAddDTO
    {
        public string StfName { get; set; }
        public int DeptId { get; set; }
        public int PosId { get; set; }
        public int ManId { get; set; }
    }
    public class StaffDTO
    {
        public int Id { get; set; }
        public string StfName { get; set; }
        public string StfId { get; set; }
        public int IsDel { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int PosId { get; set; }
        public string PosName { get; set; }
        public int ManId { get; set; }
        public string ManName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
    public class StaffUpdateDTO : StaffAddDTO
    {
        public int Id { get; set; }
    }
}
