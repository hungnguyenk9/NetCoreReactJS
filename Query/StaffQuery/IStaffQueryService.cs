using NetCoreReactJS.DTO;
using System.Collections.Generic;

namespace NetCoreReactJS.Query.StaffQuery
{
    public interface IStaffQueryService
    {
        StaffDTO GetOneById(int Id);
        List<StaffDTO> GetList(string Name);
        List<StaffDTO> GetListMan(int id);
    }
}
