using Employee_task_management.Models;
using EmployeeManagement.Model;
using EmployeeManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Employee_task_management.Controllers
{
    public class TaskController : ApiController
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            var taskService = new TaskService();
            List<TaskModelEntity> tasks = await taskService.GetAllAsync();
            List<TaskREST> taskREST = new List<TaskREST>();
            foreach (TaskModelEntity task in tasks)
            {
                taskREST.Add(new TaskREST(task.Name, task.Status, task.Type, task.Complexity));
            }
            if (taskREST.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, taskREST);
            }
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var taskService = new TaskService();
            var task = await taskService.GetByIdAsync(id);
            if (task.Id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "NO ID");
            } else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new TaskREST(task.Name, task.Status, task.Type, task.Complexity));
            }
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody] TaskREST taskToPostREST)
        {
            var taskService = new TaskService();
            if (taskToPostREST == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty!");
            }
            else if (taskToPostREST.Name == null || taskToPostREST.Status == null || taskToPostREST.Type == null || taskToPostREST.Complexity <= 0 || taskToPostREST.Complexity > 10)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You have to provide name,status,type and 0 > complexity < 10");
            }
            else
            {
                TaskModelEntity task = new TaskModelEntity();
                task.Name = taskToPostREST.Name;
                task.Status = taskToPostREST.Status;
                task.Type = taskToPostREST.Type;
                task.Complexity = taskToPostREST.Complexity;
                await taskService.PostAsync(task);
                return Request.CreateResponse(HttpStatusCode.OK, taskToPostREST);
            }
        }
        [Route("api/task/edit/{id}")]
        public async Task<HttpResponseMessage> PutEditAsync([FromUri] int id, [FromBody] TaskREST taskToPostREST)
        {
            var taskService = new TaskService();
            var task = await taskService.GetByIdAsync(id);
            if (taskToPostREST == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty!");
            }
            else if (taskToPostREST.Name == null || taskToPostREST.Status == null || taskToPostREST.Type == null || taskToPostREST.Complexity <= 0 || taskToPostREST.Complexity > 10)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You have to provide name,status,type and 0 > complexity < 10");
            }
            else
            {
                task.Name = taskToPostREST.Name;
                task.Status = taskToPostREST.Status;
                task.Type = taskToPostREST.Type;
                task.Complexity = taskToPostREST.Complexity;
                await taskService.EditAsnyc(id, task);
                return Request.CreateResponse(HttpStatusCode.OK, taskToPostREST);
            }
        }

        [Route("api/task/del/{id}")]
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var taskService = new TaskService();
            var task = await taskService.GetByIdAsync(id);
            if (task.Id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"No such ID, ID = {id}");
            }
            else
            {
                await taskService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, new TaskREST(task.Name, task.Status, task.Type, task.Complexity));
            }
        }
    }
}