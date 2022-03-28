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
    public class TaskService : ITaskService
    {
        public async Task<List<TaskModelEntity>> GetAllAsync()
        {
            var taskRepository = new TaskRepository();
            List<TaskModelEntity> tasks = await taskRepository.GetAllTasksAsync();
            return tasks;

        }

        public async Task<TaskModelEntity> GetByIdAsync(int id)
        {
            var taskRepository = new TaskRepository();
            TaskModelEntity task = await taskRepository.GetTaskByIdAsync(id);
            return task;
        }

        public async Task PostAsync(TaskModelEntity task)
        {
            var taskRepository = new TaskRepository();
            await taskRepository.PostTaskAsync(task);
        }

        public async Task EditAsnyc(int id, TaskModelEntity task)
        {
            var taskRepository = new TaskRepository();
            await taskRepository.EditTaskAsync(id, task);
        }

        public async Task DeleteAsync(int id)
        {
            var taskRepository = new TaskRepository();
            await taskRepository.DeleteTaskAsync(id);
        }
    }
}
