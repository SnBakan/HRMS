using System;

namespace HRMS.Domain
{
    public class LeaveRequestHistoryRowDto
    {
        public int lrId { get; set; }              // istersen gizlersin
        public string EmployeeName { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DayCount { get; set; }
        public string Status { get; set; }
    }
}

