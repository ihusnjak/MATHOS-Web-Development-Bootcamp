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
    public class TaskService : ITaskService
    {
        protected ITaskRepository TaskRepository { get;private set; }
        public TaskService(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }
        public async Task<List<TaskModelEntity>> GetAllAsync(Paging paging, FilterTask filter, Sorting sort)
        {
            //var taskRepository = new TaskRepository();
            List<TaskModelEntity> tasks = await TaskRepository.GetAllTasksAsync(paging, filter, sort);
            return tasks;

        }

        public async Task<TaskModelEntity> GetByIdAsync(int id)
        {
            //var taskRepository = new TaskRepository();
            TaskModelEntity task = await TaskRepository.GetTaskByIdAsync(id);
            return task;
        }

        public async Task PostAsync(TaskModelEntity task)
        {
            //var taskRepository = new TaskRepository();
            await TaskRepository.PostTaskAsync(task);
        }

        public async Task EditAsnyc(int id, TaskModelEntity task)
        {
            //var taskRepository = new TaskRepository();
            await TaskRepository.EditTaskAsync(id, task);
        }

        public async Task DeleteAsync(int id)
        {
            //var taskRepository = new TaskRepository();
            await TaskRepository.DeleteTaskAsync(id);
        }
    }
}
