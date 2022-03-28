using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Common
{
    public interface ITaskRepository
    {
        Task<List<TaskModelEntity>> GetAllTasksAsync();
        Task<TaskModelEntity> GetTaskByIdAsync(int id);
        Task PostTaskAsync(TaskModelEntity taskToPut);
        Task EditTaskAsync(int id, TaskModelEntity taskToEdit);
        Task DeleteTaskAsync(int id);

    }
}
