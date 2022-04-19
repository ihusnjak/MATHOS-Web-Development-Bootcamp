using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public class Paging : IPaging
    {
        public int PageNumber { get; set; } = 1;
        public int RecordsPerPAge { get; set; } = 20;


    }

}
