using HRMS.DAL;
using HRMS.Domain;
using HRMS.Presentation.Context;
using System;
using System.Collections.Generic;

namespace HRMS.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public List<EmployeeGridRowDto> GetAll(int? departmentId, bool onlyActive)
            => _repo.GetAll(departmentId, onlyActive);

        public int Add(Employees emp)
        {
            if (string.IsNullOrWhiteSpace(emp.eFullName))
                throw new Exception("Ad Soyad boş olamaz.");
            return _repo.Add(emp);
        }

        public bool Update(Employees emp, bool canEditSalary)
        {
            if (emp.eId <= 0) throw new Exception("Personel seçilmedi.");
            return _repo.Update(emp, canEditSalary);
        }

        public bool SetActive(int eId, bool isActive)
        {
            if (eId <= 0) throw new Exception("Personel seçilmedi.");
            return _repo.SetActive(eId, isActive);
        }
        
        public int GetDepartmentIdByEmployeeId(int employeeId)
        {
            return _repo.GetDepartmentIdByEmployeeId(employeeId);
        }
        public Employees GetById(int eId)
        {
            if (eId <= 0) throw new Exception("Geçersiz personel.");
            return _repo.GetById(eId);
        }

        public bool UpdateContact(int eId, string mail, string phone)
        {
            if (eId <= 0) throw new Exception("Geçersiz personel.");
            mail = (mail ?? "").Trim();
            phone = (phone ?? "").Trim();
            return _repo.UpdateContact(eId, mail, phone);
        }

    }
}

