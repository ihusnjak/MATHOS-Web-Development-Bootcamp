using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Person.WebApi.Controllers
{
    public class TaskController : ApiController
    {

        public static List<Task> tasks = new List<Task>() {
            new Task(1, "Finish WEB API", "TASK", "OPEN"),
            new Task(2, "Find bug in DB", "BUG", "IN_PROGRESS")
        };


        public HttpResponseMessage GetAllTasks()
        {

            if (tasks == null || tasks.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty task list!");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            }
        }
        [Route("api/task/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var task = tasks.Where(t => t.Id == id).FirstOrDefault();

            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Cannot find task with  id: {id }");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, task);

            }
        }
        public HttpResponseMessage PostTask(Task task)
        {
            var tempTask = tasks.Where(t => t.Id == task.Id).FirstOrDefault();
            if (tempTask != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Task with id: {task.Id} allready exists!");
            }
            else
            {
                tasks.Add(task);
                return Request.CreateResponse(HttpStatusCode.OK, task);
            }
        }
        [Route("api/task/{id}")]
        public HttpResponseMessage PutByID([FromUri] int id, Task taskToPut)
        {
            var task = tasks.Where(t => t.Id == id).FirstOrDefault();
            if (task == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Cannot find task with id {id}");
            }
            else
            {
                task.Id = taskToPut.Id;
                task.TaskName = taskToPut.TaskName;
                task.Status = taskToPut.Status;
                task.Type = taskToPut.Type;
                return Request.CreateResponse(HttpStatusCode.OK, task.TaskName + " edited!");

            }
        }

        [Route("api/task/{id}")]
        public HttpResponseMessage DeleteByID(int id)
        {
            var task = tasks.Where(t => t.Id == id).FirstOrDefault();

            if (task != null)
            {
                tasks.Remove(task);
                return Request.CreateResponse(HttpStatusCode.OK, $"Task with name {task.TaskName} nad id {task.Id} removed!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no tasks with id {id} to be removed");
            }


        }


    }

    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public Task(int id, string taskName, string type, string status)
        {
            Id = id;
            TaskName = taskName;
            Type = type;
            Status = status;
        }

        public Task()
        {
        }
    }

}
