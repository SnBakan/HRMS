using System;
using System.Collections.Generic;
using MySqlConnector;
using HRMS.DAL.Database;

namespace HRMS.DAL.Reports
{
    public class DailyDashboardRepository
    {
        public List<DailyLeaveCardDto> GetDailyLeaves(DateTime day)
        {
            var start = day.Date;
            var end = day.Date.AddDays(1);

            // NOT: Tablo/kolon isimleri sende farklıysa burayı birlikte düzelteceğiz.
            const string sql = @"
                SELECT
                    lr.lrId        AS LeaveRequestId,
                    e.eFullName    AS EmployeeFullName,
                    d.dName        AS DepartmentName,
                    lt.ltName      AS LeaveTypeName,
                    lr.lrStartDate AS StartDate,
                    lr.lrEndDate   AS EndDate,
                    lr.lrStatus    AS Status
                FROM LeaveRequests lr
                JOIN Employees e   ON e.eId = lr.lrEmployeeId
                JOIN Departments d ON d.dId = e.eDepartmentId
                JOIN LeaveTypes lt ON lt.ltId = lr.lrLeaveTypeId
                WHERE lr.lrStartDate < @end AND lr.lrEndDate >= @start
                ORDER BY lr.lrStartDate ASC;";


            var list = new List<DailyLeaveCardDto>();

            var conn = Db.OpenConnection();
            var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);

            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                list.Add(new DailyLeaveCardDto
                {
                    LeaveRequestId = reader.GetInt32("LeaveRequestId"),
                    EmployeeFullName = reader.GetString("EmployeeFullName"),
                    DepartmentName = reader.GetString("DepartmentName"),
                    LeaveTypeName = reader.GetString("LeaveTypeName"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.GetDateTime("EndDate"),
                    Status = reader.GetString("Status"),
                });
            }

            return list;
        }
    }
}

