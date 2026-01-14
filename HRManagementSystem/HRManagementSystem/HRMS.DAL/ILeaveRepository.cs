using System;
using System.Collections.Generic;
using HRMS.Domain;

namespace HRMS.DAL
{
    public interface ILeaveRepository
    {
        List<LeaveTypes> GetLeaveTypes();
        int CreateLeaveRequest(int employeeId, int leaveTypeId, DateTime start, DateTime end);
    }
}

