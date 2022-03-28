using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_task_management.Models
{
    public class TaskREST
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Complexity { get; set; }

        public TaskREST(string name, string status, string type, int complexity)
        {
            Name = name;
            Status = status;
            Type = type;
            Complexity = complexity;
        }

        public TaskREST()
        {
        }
    }
}