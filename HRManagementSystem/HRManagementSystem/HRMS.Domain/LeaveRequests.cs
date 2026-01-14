using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain
{
    public class LeaveRequests
    {
        public int lrId { get; set; }
        public int lrEmployeeId { get; set; }
        public int lrLeaveTypeId { get; set; }
        public DateTime lrStartDate { get; set; }
        public DateTime lrEndDate { get; set; }
        public string lrStatus { get; set; } = "";
        public DateTime lrRequestedAt { get; set; }
        public int lrApprovedByUserId { get; set; }
        public DateTime lrApprovedAt { get; set; }

    }
}
