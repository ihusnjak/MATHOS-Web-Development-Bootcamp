using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_task_management.Models
{
    public class EmployeeREST
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public EmployeeREST(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public EmployeeREST()
        {
        }
    }
}