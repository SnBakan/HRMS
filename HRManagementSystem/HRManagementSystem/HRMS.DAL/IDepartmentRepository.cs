using System.Collections.Generic;
using HRMS.Domain;

namespace HRMS.DAL
{
    public interface IDepartmentRepository
    {
        List<Departments> GetAll(bool onlyActive);
        int Add(string name);
        bool Update(int id, string name);
        bool SoftDelete(int id);
        bool SetActive(int id, bool isActive);

    }
}

