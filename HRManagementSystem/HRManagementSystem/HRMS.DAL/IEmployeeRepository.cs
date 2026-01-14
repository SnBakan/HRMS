using System;
using System.Collections.Generic;
using HRMS.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public interface IEmployeeRepository
    {
        List<EmployeeGridRowDto> GetAll(int? departmentId, bool onlyActive);
        int Add(Employees emp);
        bool Update(Employees emp, bool canEditSalary);
        bool SetActive(int eId, bool isActive);
        int GetDepartmentIdByEmployeeId(int employeeId);
        Employees GetById(int eId);
        bool UpdateContact(int eId, string mail, string phone);

    }

}
