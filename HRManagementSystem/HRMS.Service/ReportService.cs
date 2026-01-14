using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.DAL;
using HRMS.Domain;

namespace HRMS.Service
{
    public class ReportService
    {
        private readonly IReportRepository _repo;

        public ReportService(IReportRepository repo)
        {
            _repo = repo;
        }

        public List<DailyLeaveItemDto> GetDailyLeaves(DateTime from, DateTime to, DateTime today)
        {
            var departments = _repo.GetDepartments().ToDictionary(d => d.Id, d => d.Name);
            var employees = _repo.GetEmployees().ToDictionary(e => e.Id);

            var leaves = _repo.GetLeaves(from, to);

            return leaves.Select(l =>
            {
                var emp = employees[l.EmployeeId];
                var deptName = departments[emp.DepartmentId];

                int remaining = (l.EndDate.Date - today.Date).Days;
                if (remaining < 0) remaining = 0;

                return new DailyLeaveItemDto
                {
                    EmployeeName = emp.FullName,
                    DepartmentName = deptName,
                    LeaveTypeText = LeaveTypeToText(l.Type),
                    StartDate = l.StartDate.Date,
                    EndDate = l.EndDate.Date,
                    RemainingDays = remaining
                };
            }).ToList();
        }

        private static string LeaveTypeToText(LeaveType type)
        {
            switch (type)
            {
                case LeaveType.YillikIzin:
                    return "Yıllık İzin";
                case LeaveType.OzelIzin:
                    return "Özel İzin";
                case LeaveType.Raporlu:
                    return "Raporlu";
                case LeaveType.UcretsizIzin:
                    return "Ücretsiz İzin";
                default:
                    return "İzin";
            }
        }
    }
}
