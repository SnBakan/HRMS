using HRMS.DAL.Database;
using HRMS.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace HRMS.DAL
{
    public class MySqlLeaveRequestRepository : ILeaveRequestRepository
    {
        public List<LeaveRequestGridRowDto> GetMyLeaveHistory(int employeeId, bool onlyApproved)
        {
            var list = new List<LeaveRequestGridRowDto>();
            var con = Db.OpenConnection();

            // ⚠️ Status kolonun string değilse (int vs) buna göre uyarlayacağız.
            const string sql = @"
SELECT 
    lr.lrId,
    lt.ltName AS LeaveTypeName,
    lr.lrStartDate AS StartDate,
    lr.lrEndDate   AS EndDate,
    lr.lrStatus    AS Status
FROM LeaveRequests lr
JOIN LeaveTypes lt ON lt.ltId = lr.lrLeaveTypeId
WHERE lr.lrEmployeeId = @empId
  AND (@onlyApproved = 0 OR lr.lrStatus = 'Approved')
ORDER BY lr.lrStartDate DESC;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@empId", employeeId);
            cmd.Parameters.AddWithValue("@onlyApproved", onlyApproved ? 1 : 0);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new LeaveRequestGridRowDto
                {
                    lrId = Convert.ToInt32(rd["lrId"]),
                    LeaveTypeName = rd["LeaveTypeName"].ToString() ?? "",
                    StartDate = Convert.ToDateTime(rd["StartDate"]),
                    EndDate = Convert.ToDateTime(rd["EndDate"]),
                    Status = rd["Status"].ToString() ?? ""
                });
            }

            return list;
        }
        public List<LeaveRequestApproveRowDto> GetRequestsForApproval(int? departmentId, int? excludeEmployeeId)
        {
            var list = new List<LeaveRequestApproveRowDto>();
            var con = Db.OpenConnection();

            const string sql = @"
SELECT
    lr.lrId,
    e.eFullName AS EmployeeName,
    d.dName     AS DepartmentName,
    lt.ltName   AS LeaveTypeName,
    lr.lrStartDate AS StartDate,
    lr.lrEndDate   AS EndDate,
    DATEDIFF(lr.lrEndDate, lr.lrStartDate) + 1 AS DayCount,
    lr.lrStatus    AS Status
FROM LeaveRequests lr
JOIN Employees e   ON e.eId = lr.lrEmployeeId
JOIN Departments d ON d.dId = e.eDepartmentId
JOIN LeaveTypes lt ON lt.ltId = lr.lrLeaveTypeId
WHERE
    lr.lrStatus = 'Pending'
    AND (@depId IS NULL OR e.eDepartmentId = @depId)
    AND (@excludeEmpId IS NULL OR lr.lrEmployeeId <> @excludeEmpId)
ORDER BY lr.lrStartDate DESC;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@depId", (object)departmentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@excludeEmpId", (object)excludeEmployeeId ?? DBNull.Value);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var start = Convert.ToDateTime(rd["StartDate"]);
                var end = Convert.ToDateTime(rd["EndDate"]);

                list.Add(new LeaveRequestApproveRowDto
                {
                    lrId = Convert.ToInt32(rd["lrId"]),
                    EmployeeName = rd["EmployeeName"].ToString() ?? "",
                    DepartmentName = rd["DepartmentName"].ToString() ?? "",
                    LeaveTypeName = rd["LeaveTypeName"].ToString() ?? "",
                    StartDate = start,
                    EndDate = end,
                    DayCount = (end.Date - start.Date).Days + 1,
                    Status = rd["Status"].ToString() ?? ""
                });
            }

            return list;
        }
        public bool SetStatus(int lrId, string status)
        {
            var con = Db.OpenConnection();
            const string sql = @"UPDATE LeaveRequests SET lrStatus=@s WHERE lrId=@id;";
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", lrId);
            return cmd.ExecuteNonQuery() > 0;
        }
        public List<LeaveRequestHistoryRowDto> GetLeaveHistoryForEmployees(int? departmentId, int? employeeId)
        {
            var list = new List<LeaveRequestHistoryRowDto>();
            var con = Db.OpenConnection();

            const string sql = @"
SELECT
    lr.lrId,
    e.eFullName AS EmployeeName,
    lt.ltName   AS LeaveTypeName,
    lr.lrStartDate AS StartDate,
    lr.lrEndDate   AS EndDate,
    DATEDIFF(lr.lrEndDate, lr.lrStartDate) + 1 AS DayCount,
    lr.lrStatus AS Status
FROM LeaveRequests lr
JOIN Employees e  ON e.eId = lr.lrEmployeeId
JOIN LeaveTypes lt ON lt.ltId = lr.lrLeaveTypeId
WHERE
    (@depId IS NULL OR e.eDepartmentId = @depId)
    AND (@empId IS NULL OR lr.lrEmployeeId = @empId)
ORDER BY lr.lrStartDate DESC;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@depId", (object)departmentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@empId", (object)employeeId ?? DBNull.Value);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var start = Convert.ToDateTime(rd["StartDate"]);
                var end = Convert.ToDateTime(rd["EndDate"]);

                list.Add(new LeaveRequestHistoryRowDto
                {
                    lrId = Convert.ToInt32(rd["lrId"]),
                    EmployeeName = rd["EmployeeName"].ToString() ?? "",
                    LeaveTypeName = rd["LeaveTypeName"].ToString() ?? "",
                    StartDate = start,
                    EndDate = end,
                    DayCount = (end.Date - start.Date).Days + 1,
                    Status = rd["Status"].ToString() ?? ""
                });
            }

            return list;
        }


    }
}

