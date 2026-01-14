using System;

namespace HRMS.Domain
{
    public class LeaveRequestGridRowDto
    {
        public int lrId { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}

