using HRMS.DAL.Database;
using HRMS.Domain;
using HRMS.Service;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace HRMS.DAL
{
    public class MySqlReportRepository : IReportRepository
    {
        private readonly string _connectionString;

        public MySqlReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Departments> GetDepartments()
        {
            var list = new List<Departments>();

            var con = Db.OpenConnection();
            var cmd = new MySqlCommand("SELECT dId, dName FROM Departments",con);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Departments
                {
                    dId = Convert.ToInt32(rd["dId"]),
                    dName = rd["dName"].ToString() ?? ""
                });
            }

            return list;
        }

        public List<Employees> GetEmployees()
        {
            var list = new List<Employees>();
            var con = Db.OpenConnection();
            var cmd = new MySqlCommand("SELECT eId, eFullName, eDepartmentId, eSalary, eIsActive FROM Employees", con);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Employees
                {
                    eId = (int)rd["eId"],
                    eFullName = rd["eFullName"].ToString() ?? "",
                    eDepartmentId = (int)rd["eDepartmentId"],
                    eSalary = rd.IsDBNull(rd.GetOrdinal("eSalary")) 
                    ? 0m: 
                    Convert.ToDecimal(rd["eSalary"])

                });
            }
            return list;
        }

        public List<LeaveTypes> GetLeaveTypes()
        {
            var list = new List<LeaveTypes>();
            var con = Db.OpenConnection();
            var cmd = new MySqlCommand("SELECT ltId, ltName FROM LeaveTypes", con);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new LeaveTypes
                {
                    ltId = (int)rd["ltId"],
                    ltName = rd["ltName"].ToString() ?? ""
                });
            }
            return list;
        }

        public List<LeaveRequests> GetLeaveRequests(DateTime from, DateTime to)
        {
            var list = new List<LeaveRequests>();
            var con = Db.OpenConnection();
            var cmd = new MySqlCommand(@"SELECT lrEmployeeId, lrLeaveTypeId, lrStartDate, lrEndDate FROM LeaveRequests WHERE lrStartDate >= @from AND lrStartDate < @to ", con);

            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new LeaveRequests
                {
                    lrEmployeeId = (int)rd["lrEmployeeId"],
                    lrLeaveTypeId = (int)rd["lrLeaveTypeId"],
                    lrStartDate = (DateTime)rd["lrStartDate"],
                    lrEndDate = (DateTime)rd["lrEndDate"]
                });
            }
            return list;
        }

        public decimal GetAverageSalary(bool onlyActive)
        {
            var con = Db.OpenConnection();

            var sql = onlyActive
                ? "SELECT AVG(eSalary) FROM Employees WHERE eIsActive = 1;"
                : "SELECT AVG(eSalary) FROM Employees;";

            var cmd = new MySqlCommand(sql, con);
            var result = cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value) return 0m;
            return Convert.ToDecimal(result);
        }
        public int GetEmployeeCount(bool onlyActive)
        {
            var con = Db.OpenConnection();
            var sql = onlyActive
                ? "SELECT COUNT(*) FROM Employees WHERE eIsActive = 1;"
                : "SELECT COUNT(*) FROM Employees;";
            var cmd = new MySqlCommand(sql, con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetDepartmentCount()
        {
            var con = Db.OpenConnection();
            var cmd = new MySqlCommand("SELECT COUNT(*) FROM Departments;", con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetOnLeaveCount(DateTime from, DateTime to)
        {
            var con = Db.OpenConnection();
            var cmd = new MySqlCommand(@"
            SELECT COUNT(*)
            FROM LeaveRequests
            WHERE lrStartDate >= @from AND lrStartDate < @to;", con);

            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public List<PerformanceRowDto> GetPerformanceRows(DateTime? onDate, int? departmentId, int? employeeId)
        {
            var list = new List<PerformanceRowDto>();

            var sql = @"
            SELECT
                e.eId                AS EmployeeId,
                e.eFullName          AS EmployeeName,
                d.dId                AS DepartmentId,
                d.dName              AS DepartmentName,
                IFNULL(e.eTitle, '') AS Title,
                IFNULL(e.eSalary, 0) AS Salary,

                ep.epScore           AS Score,
                ep.epTargetCompletion AS TargetCompletion,
                ep.epReviewedAt      AS ReviewedAt
            FROM EmployeePerformance ep
            JOIN Employees e ON e.eId = ep.epEmployeeId
            JOIN Departments d ON d.dId = e.eDepartmentId
            WHERE
                (@onDate IS NULL OR DATE(ep.epReviewedAt) = DATE(@onDate))
                AND (@depId IS NULL OR e.eDepartmentId = @depId)
                AND (@empId IS NULL OR e.eId = @empId)
            ORDER BY ep.epReviewedAt DESC;";

            using (var conn = Db.OpenConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 60; // ✅ 60 saniye (istersen 120 yap)
                
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
                            Salary = Convert.ToDecimal(rd["Salary"]),

                            Score = Convert.ToInt32(rd["Score"]),
                            TargetCompletion = Convert.ToInt32(rd["TargetCompletion"]),
                            Evaluation = GetEvaluation(Convert.ToInt32(rd["Score"])),
                            ReviewedAt = Convert.ToDateTime(rd["ReviewedAt"])
                        });
                    }
                }
            }

            return list;
        }
        private string GetEvaluation(int score)
        {
            if (score >= 85) return "Mükemmel";
            if (score >= 70) return "İyi";
            if (score >= 50) return "Orta";
            return "Geliştirilmeli";
        }

        public List<EmployeeRowDto> GetEmployeeDistribution(int? departmentId)
        {
            var list = new List<EmployeeRowDto>();

            var sql = @"
            SELECT 
                d.dName AS DepartmentName,
                COUNT(*) AS EmployeeCount
            FROM Employees e
            JOIN Departments d ON d.dId = e.eDepartmentId
            WHERE (@depId IS NULL OR e.eDepartmentId = @depId)
            GROUP BY d.dName
            ORDER BY d.dName;";

            var con = Db.OpenConnection();
            var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@depId", (object)departmentId ?? DBNull.Value);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new EmployeeRowDto
                {
                    DepartmentName = rd["DepartmentName"].ToString() ?? "",
                    EmployeeCount = Convert.ToInt32(rd["EmployeeCount"])
                });
            }

            return list;
        }


        public List<SalaryRowDto> GetSalaryDistribution(bool onlyActive)
        {
            var list = new List<SalaryRowDto>();

            var sql = @"
            SELECT
              CASE
                WHEN e.eSalary <= 10000 THEN '0-10K'
                WHEN e.eSalary <= 20000 THEN '10K-20K'
                WHEN e.eSalary <= 30000 THEN '20K-30K'
                ELSE '30K+'
              END AS RangeLabel,
              COUNT(*) AS Count
            FROM Employees e
            WHERE (@onlyActive = 0 OR e.eIsActive = 1)
            GROUP BY RangeLabel
            ORDER BY
              CASE RangeLabel
                WHEN '0-10K' THEN 1
                WHEN '10K-20K' THEN 2
                WHEN '20K-30K' THEN 3
                ELSE 4
              END;";

            var con = Db.OpenConnection();
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@onlyActive", onlyActive ? 1 : 0);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new SalaryRowDto
                {
                    RangeLabel = rd["RangeLabel"].ToString() ?? "",
                    Count = Convert.ToInt32(rd["Count"])
                });
            }

            return list;
        }



        public List<LeaveBalanceRowDto> GetLeaveBalances(int year, int? departmentId, int? employeeId)
        {
            var list = new List<LeaveBalanceRowDto>();

            const string sql = @"
            SELECT
                e.eId                 AS EmployeeId,
                e.eFullName           AS EmployeeName,
                d.dId                 AS DepartmentId,
                d.dName               AS DepartmentName,
                le.leTotalDays        AS TotalDays,
                IFNULL(u.UsedDays, 0) AS UsedDays,
                (le.leTotalDays - IFNULL(u.UsedDays, 0)) AS RemainingDays,
                u.LastUsedEnd         AS LastUsedEnd
            FROM LeaveEntitlements le
            JOIN Employees e   ON e.eId = le.leEmployeeId
            JOIN Departments d ON d.dId = e.eDepartmentId
            LEFT JOIN (
                SELECT
                    lr.lrEmployeeId AS EmpId,
                    SUM(
                        DATEDIFF(
                            LEAST(lr.lrEndDate, CONCAT(@year, '-12-31')),
                            GREATEST(lr.lrStartDate, CONCAT(@year, '-01-01'))
                        ) + 1
                    ) AS UsedDays,
                    MAX(lr.lrEndDate) AS LastUsedEnd
                FROM LeaveRequests lr
                WHERE
                    -- yıl kesişimi olan tüm izinler
                    lr.lrEndDate >= CONCAT(@year, '-01-01')
                    AND lr.lrStartDate <= CONCAT(@year, '-12-31')
                GROUP BY lr.lrEmployeeId
            ) u ON u.EmpId = e.eId
            WHERE le.leYear = @year
                AND (@depId IS NULL OR e.eDepartmentId = @depId)
                AND (@empId IS NULL OR e.eId = @empId)
            ORDER BY d.dName, e.eFullName;";

            using (var conn = Db.OpenConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
              
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@depId", (object)departmentId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@empId", (object)employeeId ?? DBNull.Value);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var dto = new LeaveBalanceRowDto
                        {
                            EmployeeId = Convert.ToInt32(rd["EmployeeId"]),
                            EmployeeName = rd["EmployeeName"].ToString(),
                            DepartmentId = Convert.ToInt32(rd["DepartmentId"]),
                            DepartmentName = rd["DepartmentName"].ToString(),
                            TotalDays = Convert.ToInt32(rd["TotalDays"]),
                            UsedDays = Convert.ToInt32(rd["UsedDays"]),
                            RemainingDays = Convert.ToInt32(rd["RemainingDays"]),
                            LastUsedEnd = rd.IsDBNull(rd.GetOrdinal("LastUsedEnd"))
                                ? (DateTime?)null
                                : Convert.ToDateTime(rd["LastUsedEnd"])
                        };

                        list.Add(dto);
                    }
                }
            }

            // Negatif kalan gün varsa 0'a çek (güvenlik)
            foreach (var x in list)
                if (x.RemainingDays < 0) x.RemainingDays = 0;

            return list;
        }
        public List<EmployeeCompRowDto> GetEmployeeCompRows(bool onlyActive)
        {
            var list = new List<EmployeeCompRowDto>();

            var sql = @"
            SELECT
                e.eId AS EmployeeId,
                e.eFullName AS EmployeeName,
                d.dName AS DepartmentName,
                e.eTitle AS Title,
                IFNULL(p.Score, 0) AS PerformanceScore,
                IFNULL(e.eSalary, 0) AS Salary
            FROM Employees e
            JOIN Departments d ON d.dId = e.eDepartmentId
            LEFT JOIN (
                SELECT ep.epEmployeeId AS EmpId, ep.epScore AS Score
                FROM EmployeePerformance ep
                INNER JOIN (
                    SELECT epEmployeeId, MAX(epReviewedAt) AS MaxDate
                    FROM EmployeePerformance
                    GROUP BY epEmployeeId
                ) lastp ON lastp.epEmployeeId = ep.epEmployeeId AND lastp.MaxDate = ep.epReviewedAt
            ) p ON p.EmpId = e.eId
            WHERE (@onlyActive = 0 OR e.eIsActive = 1)
            ORDER BY d.dName, e.eFullName;";

            using (var conn = Db.OpenConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@onlyActive", onlyActive ? 1 : 0);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new EmployeeCompRowDto
                        {
                            EmployeeId = Convert.ToInt32(rd["EmployeeId"]),
                            EmployeeName = rd["EmployeeName"].ToString() ?? "",
                            DepartmentName = rd["DepartmentName"].ToString() ?? "",
                            Title = rd["Title"].ToString() ?? "",
                            PerformanceScore = Convert.ToInt32(rd["PerformanceScore"]),
                            Salary = Convert.ToDecimal(rd["Salary"])
                        });
                    }
                }
            }

            return list;
        }
        public int GetMaxEntitlementYear()
        {
            const string sql = "SELECT IFNULL(MAX(leYear), YEAR(CURDATE())) FROM LeaveEntitlements;";
            using (var conn = Db.OpenConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                var obj = cmd.ExecuteScalar();
                return Convert.ToInt32(obj);
            }
        }

    }

}
