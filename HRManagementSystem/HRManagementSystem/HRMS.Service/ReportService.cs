using HRMS.DAL;
using HRMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Service
{
    public class ReportService
    {
        private readonly IReportRepository _repo;

        public ReportService(IReportRepository repo)
        {
            _repo = repo;
        }

        public decimal GetAverageSalary(bool onlyActive = true)
        {
            return _repo.GetAverageSalary(onlyActive);
        }
        public int GetEmployeeCount(bool onlyActive) => _repo.GetEmployeeCount(onlyActive);
        public int GetDepartmentCount() => _repo.GetDepartmentCount();
        public int GetOnLeaveCount(DateTime from, DateTime to) => _repo.GetOnLeaveCount(from, to);
        public List<LeaveBalanceRowDto> GetLeaveBalances(int year, int? departmentId, int? employeeId)
        {
            return _repo.GetLeaveBalances(year, departmentId, employeeId);
        }
        public List<EmployeeRowDto> GetEmployeeDistribution(int? departmentId = null)
             => _repo.GetEmployeeDistribution(departmentId);

        public List<SalaryRowDto> GetSalaryDistribution(bool onlyActive = true)
            => _repo.GetSalaryDistribution(onlyActive);

        public List<PerformanceRowDto> GetPerformanceRows(DateTime? onDate, int? departmentId, int? employeeId)
            => _repo.GetPerformanceRows(onDate, departmentId, employeeId);
        public List<EmployeeCompRowDto> GetEmployeeCompRows(bool onlyActive = true)
            => _repo.GetEmployeeCompRows(onlyActive);

        private void EnsureDailyLookupsCached()
        {
            // İlk kez ya da 5 dk geçtiyse yenile
            if (_depCache == null || _empCache == null || _ltCache == null
                || (DateTime.Now - _cacheAt).TotalMinutes > 5)
            {
                _depCache = _repo.GetDepartments().ToDictionary(d => d.dId, d => d.dName);
                _empCache = _repo.GetEmployees().ToDictionary(e => e.eId);
                _ltCache = _repo.GetLeaveTypes().ToDictionary(lt => lt.ltId, lt => lt.ltName);

                _cacheAt = DateTime.Now;
            }
        }

        public List<DailyLeaveItemDto> GetDailyLeaves(DateTime from, DateTime to, DateTime today)
        {
            EnsureDailyLookupsCached();
            var departments = _depCache;
            var employees = _empCache;
            var leaveTypes = _ltCache;

            // LeaveRequests: date range (bunu cache’lemiyoruz, çünkü tarih aralığı sürekli değişiyor)
            var leaves = _repo.GetLeaveRequests(from, to);

            var result = new List<DailyLeaveItemDto>(leaves.Count);

            foreach (var lr in leaves)
            {
                // employee
                Employees emp;
                if (!employees.TryGetValue(lr.lrEmployeeId, out emp))
                    continue;

                // department name
                string deptName;
                if (!departments.TryGetValue(emp.eDepartmentId, out deptName))
                    deptName = "-";

                // leave type name
                string ltName;
                if (!leaveTypes.TryGetValue(lr.lrLeaveTypeId, out ltName))
                    ltName = "İzin";

                // remaining days
                int remaining = (lr.lrEndDate.Date - today.Date).Days;
                if (remaining < 0) remaining = 0;

                result.Add(new DailyLeaveItemDto
                {
                    EmployeeId = emp.eId,
                    DepartmentId = emp.eDepartmentId,

                    EmployeeName = emp.eFullName,
                    DepartmentName = deptName,
                    LeaveTypeText = ltName,
                    StartDate = lr.lrStartDate.Date,
                    EndDate = lr.lrEndDate.Date,
                    RemainingDays = remaining
                });
            }

            return result;
        }

        public void InvalidateDailyCache()
        {
            _depCache = null;
            _empCache = null;
            _ltCache = null;
        }

        public int GetMaxEntitlementYear() => _repo.GetMaxEntitlementYear();
        private Dictionary<int, string> _depCache;
        private Dictionary<int, Employees> _empCache;
        private Dictionary<int, string> _ltCache;
        private DateTime _cacheAt;
        public List<Departments> GetDepartments()
        {
            return _repo.GetDepartments();
        }

    }
}