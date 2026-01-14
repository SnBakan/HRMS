using HRMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public interface IReportRepository
    {
        List<Department> GetDepartments();
        List<Employee> GetEmployees();
        List<Leave> GetLeaves(DateTime from, DateTime to);
    }
}