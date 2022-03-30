using EmployeeManagement.Common;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Common
{
    public interface ITaskService
    {
        Task<List<TaskModelEntity>> GetAllAsync(Paging paging, FilterTask filter, Sorting sort);
        Task<TaskModelEntity> GetByIdAsync(int id);
        Task PostAsync(TaskModelEntity task);
        Task EditAsnyc(int id, TaskModelEntity task);
        Task DeleteAsync(int id);
    }
}
