namespace NetCoreReactJS.Command.DeptCmd
{
    public interface IDeptCmdService
    {
        int Add(string DeptName, int? ManId, int? DeptId);
        int Update(int Id, string DeptName, int? ManId, int? DeptId);
    }
}
