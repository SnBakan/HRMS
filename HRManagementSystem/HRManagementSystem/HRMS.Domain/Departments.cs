using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain
{
    public class Departments
    {
        public int dId { get; set; }
        public string dName { get; set; } = "";
        public bool dIsActive { get; set; }
        public DateTime dCreatedAt { get; set; }
    }
}