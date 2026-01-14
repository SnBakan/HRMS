using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain
{
    public class Employees
    {
        public int eId { get; set; }
        public string eNo { get; set; } = "";
        public int eFullName { get; set; }

        public int eDepartmentId { get; set; }
        public string eTitle { get; set; } = "";

        public string eMail { get; set; } = "";

        public string ePhone { get; set; } = "";

        public DateTime eHireDate { get; set; }

        public int eIsActive { get; set; }
    }
}

