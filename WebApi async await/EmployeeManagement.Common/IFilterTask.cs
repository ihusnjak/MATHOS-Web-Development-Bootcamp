namespace EmployeeManagement.Common
{
    public interface IFilterTask
    {
        int Complexity { get; set; }
        string Status { get; set; }
        string Type { get; set; }
    }
}