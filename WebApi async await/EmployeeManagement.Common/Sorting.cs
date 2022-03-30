using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public class Sorting : ISorting
    {
        public string SortByProp { get; set; } = "Id";
        public string SortOrder { get; set; } = "ASC";
    }
}
