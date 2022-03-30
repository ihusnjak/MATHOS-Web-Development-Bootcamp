using EmployeeManagement.Common;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync(Paging paging, FilterEmployee filter, Sorting sort);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task PostEmployeeAsync(Employee employeeToPost);
        Task EditEmployeeAsync(int id, Employee employeeToEdit);
        Task DeleteEmployeeAsync(int id);


    }
}
