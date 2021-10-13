using NetCoreReactJS.Models;

namespace NetCoreReactJS.Command.StaffCmd
{
    public interface IStaffCmdService
    {
        int Add(Staff staff);
        int Update(Staff staff);
        int Delete(int Id);
    }
}
