using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRMS.Domain
{
    public class EmployeeGridRowDto
    {
        public int eId { get; set; }
        public string eNo { get; set; } = "";
        public string eFullName { get; set; } = "";
        public int eDepartmentId { get; set; }
        public string DepartmentName { get; set; } = "";
        public string eTitle { get; set; } = "";
        public string eMail { get; set; } = "";
        public string ePhone { get; set; } = "";
        public decimal eSalary { get; set; }
        public bool eIsActive { get; set; }
        public int PerformanceScore { get; set; }


    }
}
