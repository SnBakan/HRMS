using System;

namespace HRMS.Domain
{
    public class LeaveEntitlements
    {
        public int leId { get; set; }
        public int leEmployeeId { get; set; }
        public int leYear { get; set; }
        public int leTotalDays { get; set; }
        public DateTime leCreatedAt { get; set; }
    }
}
