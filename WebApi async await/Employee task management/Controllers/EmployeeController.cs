using Employee_task_management.Models;
using EmployeeManagement.Common;
using EmployeeManagement.Model;
using EmployeeManagement.Service;
using EmployeeManagement.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employee_task_management.Controllers
{
    public class EmployeeController : ApiController
    {
        protected IEmployeeService EmployeeService { get;private set; }
        public EmployeeController(IEmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
        }

        public async Task <HttpResponseMessage> GetAsync([FromUri] Paging paging)
        {
            //var employeeService = new EmployeeService();
            List<Employee> employees = await EmployeeService.GetAllAsync(paging);
            List<EmployeeREST> employeesREST = new List<EmployeeREST>();
            foreach (Employee employee in employees)
            {
                employeesREST.Add(new EmployeeREST(employee.Id, employee.FirstName, employee.LastName));
            }
            if (employeesREST.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, employeesREST);
            }
        }

        
        public async Task<HttpResponseMessage> GetByIdAsync(int id)
        {
            //var employeeService = new EmployeeService();
            var employee = await EmployeeService.GetByIdAsync(id);
            if (employee.Id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,$"No such ID, ID = {id}");
            } else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new EmployeeREST(employee.Id, employee.FirstName, employee.LastName));
            }
        }

        
        public async Task<HttpResponseMessage> PostAsync([FromBody] EmployeeREST employeeToPost)
        {
            //var employeeService = new EmployeeService();
            if(employeeToPost == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty!");
            } else if(employeeToPost.FirstName == null || employeeToPost.LastName == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty first name or last name");
            } else
            {
                Employee employee = new Employee();
                employee.FirstName = employeeToPost.FirstName;
                employee.LastName = employeeToPost.LastName;
                await EmployeeService.PostAsync(employee);
                return Request.CreateResponse(HttpStatusCode.OK, employeeToPost);
            }
        }

        [Route("api/employee/edit/{id}")]
        public async Task<HttpResponseMessage> PutAsync([FromUri] int id, [FromBody] EmployeeREST employeeToEdit)
        {
            //var employeeService = new EmployeeService();
            var employee = await EmployeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty!");
            }
            else if (employee.FirstName == null || employee.LastName == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty first name or last name");
            }
            else
            {
                employee.FirstName = employeeToEdit.FirstName;
                employee.LastName = employeeToEdit.LastName;
                await EmployeeService.EditAsync(id, employee);
                return Request.CreateResponse(HttpStatusCode.OK, employeeToEdit);
            }
        }

        [Route("api/employee/del/{id}")]
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            //var employeeService = new EmployeeService();
            var employee = await EmployeeService.GetByIdAsync(id);
            if (employee.Id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"No such ID, ID = {id}");
            }
            else
            {
                await EmployeeService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, new EmployeeREST(employee.Id, employee.FirstName, employee.LastName));
            }
        }
    }


}

