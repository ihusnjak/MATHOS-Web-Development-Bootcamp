using EmployeeManagement.Common;
using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Common;
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
        protected IEmployeeRepository EmployeeRepository { get;private set; }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }
        public async Task <List<Employee>> GetAllAsync(Paging paging)
        {
            //var employeeRepository = new EmployeeRepository();
            List<Employee> employees = await EmployeeRepository.GetAllEmployeesAsync(paging);
            return employees;

        }

        public async Task <Employee> GetByIdAsync(int id)
        {
            //var employeeRepository = new EmployeeRepository();
            Employee employee = await EmployeeRepository.GetEmployeeByIdAsync(id);
            return employee;

        }

        public async Task PostAsync(Employee employee)
        {
            //var employeeRepository = new EmployeeRepository();
            await EmployeeRepository.PostEmployeeAsync(employee);
        }

        public async Task EditAsync(int id, Employee employeeToEdit)
        {
            //var employeeRepository = new EmployeeRepository();
            await EmployeeRepository.EditEmployeeAsync(id, employeeToEdit);
        }

        public async Task DeleteAsync(int id)
        {
            //var employeeRepository = new EmployeeRepository();
            await EmployeeRepository.DeleteEmployeeAsync(id);
        }


    }
}
