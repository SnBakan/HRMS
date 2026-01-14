using System;

namespace HRMS.Domain
{
    public class EmployeePerformance
    {
        public int epId { get; set; }
        public int epEmployeeId { get; set; }
        public int epScore { get; set; }              // 0-100
        public int epTargetCompletion { get; set; }   // 0-100
        public DateTime epReviewedAt { get; set; }
        public int? epReviewerUserId { get; set; }
        public string epNote { get; set; } = "";
    }
}

