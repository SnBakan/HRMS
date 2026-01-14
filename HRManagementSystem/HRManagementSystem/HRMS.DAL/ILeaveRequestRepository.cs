using System.Collections.Generic;
using HRMS.Domain;

namespace HRMS.DAL
{
    public interface ILeaveRequestRepository
    {
        List<LeaveRequestGridRowDto> GetMyLeaveHistory(int employeeId, bool onlyApproved);
        bool SetStatus(int lrId, string status);
        List<LeaveRequestApproveRowDto> GetRequestsForApproval(int? depId, int? excludeEmpId);
        List<LeaveRequestHistoryRowDto> GetLeaveHistoryForEmployees(int? departmentId, int? employeeId);

    }
}

