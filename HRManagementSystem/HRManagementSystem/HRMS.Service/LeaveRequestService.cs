using HRMS.DAL;
using HRMS.Domain;
using System;
using System.Collections.Generic;

namespace HRMS.Service
{
    public class LeaveRequestService
    {
        private readonly ILeaveRequestRepository _repo;

        public LeaveRequestService(ILeaveRequestRepository repo)
        {
            _repo = repo;
        }

        public List<LeaveRequestGridRowDto> GetMyLeaveHistory(int employeeId, bool onlyApproved)
        {
            if (employeeId <= 0) throw new Exception("EmployeeId bulunamadı.");
            return _repo.GetMyLeaveHistory(employeeId, onlyApproved);
        }
        public List<LeaveRequestApproveRowDto> GetRequestsForApproval(int? departmentId, int? excludeEmployeeId)
    => _repo.GetRequestsForApproval(departmentId, excludeEmployeeId);

        public void Approve(int lrId)
        {
            if (lrId <= 0) throw new Exception("Talep seçilmedi.");
            _repo.SetStatus(lrId, "Approved");
        }

        public void Reject(int lrId)
        {
            if (lrId <= 0) throw new Exception("Talep seçilmedi.");
            _repo.SetStatus(lrId, "Rejected");
        }
        public List<LeaveRequestHistoryRowDto> GetLeaveHistoryForEmployees(int? departmentId, int? employeeId = null)
     => _repo.GetLeaveHistoryForEmployees(departmentId, employeeId);


    }
}

