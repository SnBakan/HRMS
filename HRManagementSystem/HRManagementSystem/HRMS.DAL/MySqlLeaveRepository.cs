using HRMS.DAL.Database;
using HRMS.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace HRMS.DAL
{
    public class MySqlLeaveRepository : ILeaveRepository
    {
        public List<LeaveTypes> GetLeaveTypes()
        {
            var list = new List<LeaveTypes>();
            var con = Db.OpenConnection();

            const string sql = @"SELECT ltId, ltName FROM LeaveTypes ORDER BY ltName;";
            var cmd = new MySqlCommand(sql, con);
            var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new LeaveTypes
                {
                    ltId = Convert.ToInt32(rd["ltId"]),
                    ltName = rd["ltName"].ToString() ?? ""
                });
            }
            return list;
        }

        public int CreateLeaveRequest(int employeeId, int leaveTypeId, DateTime start, DateTime end)
        {
            var con = Db.OpenConnection();

            const string sql = @"
INSERT INTO LeaveRequests
(lrEmployeeId, lrLeaveTypeId, lrStartDate, lrEndDate, lrStatus)
VALUES
(@empId, @ltId, @start, @end, 'Pending');
SELECT LAST_INSERT_ID();";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@empId", employeeId);
            cmd.Parameters.AddWithValue("@ltId", leaveTypeId);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}

