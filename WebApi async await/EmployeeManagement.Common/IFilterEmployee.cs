namespace EmployeeManagement.Common
{
    public interface IFilterEmployee
    {
        int Age { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}