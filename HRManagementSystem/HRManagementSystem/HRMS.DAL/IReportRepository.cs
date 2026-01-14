using HRMS.Domain;
using HRMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public interface IReportRepository
    {
        List<Departments> GetDepartments();
        List<Employees> GetEmployees();
        List<LeaveTypes> GetLeaveTypes();
        List<LeaveRequests> GetLeaveRequests(DateTime from, DateTime to);
        List<LeaveBalanceRowDto> GetLeaveBalances(int year, int? departmentId, int? employeeId);
        List<PerformanceRowDto> GetPerformanceRows(DateTime? onDate, int? departmentId, int? employeeId);
        List<EmployeeRowDto> GetEmployeeDistribution(int? departmentId);
        List<SalaryRowDto> GetSalaryDistribution(bool onlyActive);
        List<EmployeeCompRowDto> GetEmployeeCompRows(bool onlyActive);
        decimal GetAverageSalary(bool onlyActive);
        int GetEmployeeCount(bool onlyActive);
        int GetDepartmentCount();
        int GetOnLeaveCount(DateTime from, DateTime to);
        int GetMaxEntitlementYear();



    }
}