using System;

namespace HRMS.Domain
{
    public class LeaveRequestApproveRowDto
    {
        public int lrId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public string Status { get; set; }
    }
}

