using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Common;
using EmployeeManagement.Model;

namespace EmployeeManagement.Service.Common
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync(Paging paging);
        Task<Employee> GetByIdAsync(int id);
        Task PostAsync(Employee employee);
        Task EditAsync(int id, Employee employeeToEdit);
        Task DeleteAsync(int id);

    }
}
