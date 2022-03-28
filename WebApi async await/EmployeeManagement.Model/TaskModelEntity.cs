using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class TaskModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Complexity { get; set; }

        public TaskModelEntity(int id, string name, string status, string type, int complexity)
        {
            Id = id;
            Name = name;
            Status = status;
            Type = type;
            Complexity = complexity;
        }

        public TaskModelEntity()
        {
        }
    }
}
