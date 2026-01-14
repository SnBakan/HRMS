using System;

namespace HRMS.Service
{
    public class EmployeeCompRowDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = "";
        public string DepartmentName { get; set; } = "";
        public string Title { get; set; } = "";
        public int PerformanceScore { get; set; }
        public decimal Salary { get; set; }       
    }
}

