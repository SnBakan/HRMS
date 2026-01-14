using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service
{
    public class SalaryRowDto
    {
        public string RangeLabel { get; set; } = ""; // "0-10000", "10001-20000"...
        public int Count { get; set; }
    }
}

