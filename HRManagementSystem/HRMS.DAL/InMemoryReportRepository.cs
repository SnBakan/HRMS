using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Domain;


namespace HRMS.DAL
{
    public class InMemoryReportRepository : IReportRepository
    {
        private readonly List<Department> _departments = new List<Department>
        {
            new Department { Id = 1, Name = "İnsan Kaynakları" },
            new Department { Id = 2, Name = "Bilgi Teknolojileri" },
            new Department { Id = 3, Name = "Muhasebe" },
        };

        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Ahmet Yılmaz", DepartmentId = 1 },
            new Employee { Id = 2, FullName = "Ayşe Demir", DepartmentId = 2 },
            new Employee { Id = 3, FullName = "Mehmet Kaya", DepartmentId = 3 },
        };

        private readonly List<Leave> _leaves = new List<Leave>
        {
            new Leave { Id = 1, EmployeeId = 1, Type = LeaveType.YillikIzin, StartDate = new DateTime(2025,12,8), EndDate = new DateTime(2025,12,15) },
            new Leave { Id = 2, EmployeeId = 2, Type = LeaveType.YillikIzin, StartDate = new DateTime(2025,12,9), EndDate = new DateTime(2025,12,13) },
            new Leave { Id = 3, EmployeeId = 3, Type = LeaveType.OzelIzin,  StartDate = new DateTime(2025,12,6), EndDate = new DateTime(2025,12,15) },
        };

        public List<Department> GetDepartments()
        {
            return _departments.ToList();
        }

        public List<Employee> GetEmployees()
        {
            return _employees.ToList();
        }

        public List<Leave> GetLeaves(DateTime from, DateTime to)
        {
            return _leaves
                .Where(l => l.StartDate.Date <= to.Date && l.EndDate.Date >= from.Date)
                .ToList();
        }
    }
}

