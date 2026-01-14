using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service
{
    public class DailyLeaveItemDto
    {
        public string EmployeeName { get; set; } = "";
        public string DepartmentName { get; set; } = "";
        public string LeaveTypeText { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingDays { get; set; }
    }
}
