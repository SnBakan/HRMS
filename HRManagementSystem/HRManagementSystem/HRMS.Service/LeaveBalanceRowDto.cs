using System;
using System.Collections.Generic;

namespace HRMS.Service
{
   
    public class LeaveBalanceRowDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = "";
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "";
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays { get; set; }
        public DateTime? LastUsedEnd { get; set; }

        public int UsagePercent
        {
            get
            {
                if (TotalDays <= 0) return 0;
                return (int)Math.Round((UsedDays * 100.0) / TotalDays);
            }
        }
        
        public string UsagePercentText
        {
            get
            {
                if (TotalDays <= 0) return "%0";
                var p = (int)Math.Round((UsedDays * 100.0) / TotalDays);
                return "%" + p;
            }
        }

        public string LastUsedText
        {
            get
            {
                return LastUsedEnd.HasValue
                    ? LastUsedEnd.Value.ToString("dd.MM.yyyy")
                    : "-";
            }
        }

    }
}
