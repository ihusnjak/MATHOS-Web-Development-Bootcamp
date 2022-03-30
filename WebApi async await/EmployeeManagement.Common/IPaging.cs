namespace EmployeeManagement.Common
{
    public interface IPaging
    {
        int PageNumber { get; set; }
        int RecordsPerPAge { get; set; }
    }
}