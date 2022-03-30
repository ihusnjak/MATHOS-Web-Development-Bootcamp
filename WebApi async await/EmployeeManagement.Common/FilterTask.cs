using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public class FilterTask : IFilterTask
    {
        public string Status { get; set; }
        public string Type { get; set; }
        public int Complexity { get; set; }
    }
}
