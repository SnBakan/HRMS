using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.Reports
{
    public class DailyLeaveCardDto
    {
        public int LeaveRequestId { get; set; }

        public string EmployeeFullName { get; set; } = "";
        public string DepartmentName { get; set; } = "";

        public string LeaveTypeName { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; } = ""; // Pending/Approved/Rejected vb.
    }
}
