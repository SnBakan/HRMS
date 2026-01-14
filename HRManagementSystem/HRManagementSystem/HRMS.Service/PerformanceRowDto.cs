using HRMS.DAL.Database;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace HRMS.Service
{   
    public class PerformanceRowDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = "";
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "";
        public string Title { get; set; } = "";
        public int Score { get; set; }               // 0-100
        public int TargetCompletion { get; set; }    // 0-100
        public string Evaluation { get; set; } = ""; // Mükemmel/İyi/Orta/Geliştirilmeli
        public DateTime ReviewedAt { get; set; }
        public decimal Salary { get; set; }

        public List<PerformanceRowDto> GetPerformanceRows(DateTime? onDate, int? departmentId, int? employeeId)
        {
            var list = new List<PerformanceRowDto>();

            var sql = @"
            SELECT
                e.eId AS EmployeeId,
                e.eFullName AS EmployeeName,
                d.dId AS DepartmentId,
                d.dName AS DepartmentName,
                IFNULL(e.eTitle, '') AS Title,
                ep.epScore AS Score,
                ep.epTargetCompletion AS TargetCompletion,
                ep.epEvaluation AS Evaluation,
                ep.epReviewedAt AS ReviewedAt
            FROM EmployeePerformance ep
            JOIN Employees e ON e.eId = ep.epEmployeeId
            JOIN Departments d ON d.dId = e.eDepartmentId
            WHERE (@onDate IS NULL OR DATE(ep.epReviewedAt) = DATE(@onDate))
              AND (@depId IS NULL OR e.eDepartmentId = @depId)
              AND (@empId IS NULL OR e.eId = @empId)
            ORDER BY ep.epReviewedAt DESC;";

            using (var conn = Db.OpenConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@onDate", (object)onDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@depId", (object)departmentId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@empId", (object)employeeId ?? DBNull.Value);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new PerformanceRowDto
                        {
                            EmployeeId = Convert.ToInt32(rd["EmployeeId"]),
                            EmployeeName = rd["EmployeeName"].ToString() ?? "",
                            DepartmentId = Convert.ToInt32(rd["DepartmentId"]),
                            DepartmentName = rd["DepartmentName"].ToString() ?? "",
                            Title = rd["Title"].ToString() ?? "",
                            Score = Convert.ToInt32(rd["Score"]),
                            TargetCompletion = Convert.ToInt32(rd["TargetCompletion"]),
                            Evaluation = rd["Evaluation"].ToString() ?? "",
                            ReviewedAt = Convert.ToDateTime(rd["ReviewedAt"]),
                        });
                    }
                }
            }

            return list;
        }

    }
}