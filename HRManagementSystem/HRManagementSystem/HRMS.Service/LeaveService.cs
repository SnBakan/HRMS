using HRMS.DAL;
using HRMS.Domain;
using System;
using System.Collections.Generic;

namespace HRMS.Service
{
    public class LeaveService
    {
        private readonly ILeaveRepository _repo;

        public LeaveService(ILeaveRepository repo)
        {
            _repo = repo;
        }

        public List<LeaveTypes> GetLeaveTypes()
            => _repo.GetLeaveTypes();

        public int CreateLeaveRequest(int employeeId, int leaveTypeId, DateTime start, DateTime end)
        {
            if (employeeId <= 0) throw new Exception("EmployeeId bulunamadı.");
            if (leaveTypeId <= 0) throw new Exception("İzin türü seçin.");
            if (start.Date > end.Date) throw new Exception("Başlangıç tarihi bitişten büyük olamaz.");
            if (start.Date < DateTime.Today) throw new Exception("Geçmiş tarihe izin talebi oluşturamazsın.");

            return _repo.CreateLeaveRequest(employeeId, leaveTypeId, start.Date, end.Date);
        }
    }
}

