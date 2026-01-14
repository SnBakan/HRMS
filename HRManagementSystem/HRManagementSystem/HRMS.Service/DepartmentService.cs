using System;
using System.Collections.Generic;
using HRMS.DAL;
using HRMS.Domain;

namespace HRMS.Service
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentService(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public List<Departments> GetAll(bool onlyActive = true)
            => _repo.GetAll(onlyActive);

        public int Add(string name)
        {
            name = (name ?? "").Trim();
            if (name.Length < 2) throw new Exception("Departman adı en az 2 karakter olmalı.");
            return _repo.Add(name);
        }

        public bool Update(int id, string name)
        {
            if (id <= 0) throw new Exception("Departman seçilmedi.");
            name = (name ?? "").Trim();
            if (name.Length < 2) throw new Exception("Departman adı en az 2 karakter olmalı.");
            return _repo.Update(id, name);
        }

        public bool Delete(int id)
        {
            if (id <= 0) throw new Exception("Departman seçilmedi.");
            return _repo.SoftDelete(id);
        }
        public bool Deactivate(int id)
        {
            if (id <= 0) throw new Exception("Departman seçilmedi.");
            return _repo.SetActive(id, false);
        }

        public bool Activate(int id)
        {
            if (id <= 0) throw new Exception("Departman seçilmedi.");
            return _repo.SetActive(id, true);
        }

    }
}

