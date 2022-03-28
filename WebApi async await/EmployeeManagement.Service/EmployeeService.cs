using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using EmployeeManagement.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public class EmployeeService : IEmployeeService
    {
        public async Task <List<Employee>> GetAllAsync()
        {
            var employeeRepository = new EmployeeRepository();
            List<Employee> employees = await employeeRepository.GetAllEmployeesAsync();
            return employees;

        }

        public async Task <Employee> GetByIdAsync(int id)
        {
            var employeeRepository = new EmployeeRepository();
            Employee employee = await  employeeRepository.GetEmployeeByIdAsync(id);
            return employee;

        }

        public async Task PostAsync(Employee employee)
        {
            var employeeRepository = new EmployeeRepository();
            await employeeRepository.PostEmployeeAsync(employee);
        }

        public async Task EditAsync(int id, Employee employeeToEdit)
        {
            var employeeRepository = new EmployeeRepository();
            await employeeRepository.EditEmployeeAsync(id, employeeToEdit);
        }

        public async Task DeleteAsync(int id)
        {
            var employeeRepository = new EmployeeRepository();
            await employeeRepository.DeleteEmployeeAsync(id);
        }


    }
}
