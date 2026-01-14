using HRMS.DAL.Database;
using HRMS.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HRMS.DAL
{
    public class MySqlEmployeeRepository : IEmployeeRepository
    {
        public List<EmployeeGridRowDto> GetAll(int? departmentId, bool onlyActive)
        {
            var list = new List<EmployeeGridRowDto>();
            var con = Db.OpenConnection();

            var sql = @"
SELECT
    e.eId,
    e.eNo,
    e.eFullName,
    e.eDepartmentId,
    d.dName AS DepartmentName,
    IFNULL(e.eTitle, '') AS eTitle,
    IFNULL(e.eMail, '') AS eMail,
    IFNULL(e.ePhone, '') AS ePhone,
    IFNULL(e.eSalary, 0) AS eSalary,
    e.eIsActive,
    IFNULL(p.Score, 0) AS PerformanceScore
FROM Employees e
JOIN Departments d ON d.dId = e.eDepartmentId
LEFT JOIN (
    SELECT
        ep.epEmployeeId AS EmpId,
        ep.epScore AS Score
    FROM EmployeePerformance ep
    INNER JOIN (
        SELECT epEmployeeId, MAX(epReviewedAt) AS MaxDate
        FROM EmployeePerformance
        GROUP BY epEmployeeId
    ) lastp
        ON lastp.epEmployeeId = ep.epEmployeeId
       AND lastp.MaxDate = ep.epReviewedAt
) p ON p.EmpId = e.eId
WHERE
    (@depId IS NULL OR e.eDepartmentId = @depId)
    AND (@onlyActive = 0 OR e.eIsActive = 1)
ORDER BY e.eId ASC;";


            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@depId", (object)departmentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@onlyActive", onlyActive ? 1 : 0);

            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int perf = 0;
                try { perf = Convert.ToInt32(rd["PerformanceScore"]); } catch { perf = 0; }

                list.Add(new EmployeeGridRowDto
                {
                    eId = Convert.ToInt32(rd["eId"]),
                    eNo = rd["eNo"].ToString() ?? "",
                    eFullName = rd["eFullName"].ToString() ?? "",
                    eDepartmentId = Convert.ToInt32(rd["eDepartmentId"]),
                    DepartmentName = rd["DepartmentName"].ToString() ?? "",
                    eTitle = rd["eTitle"].ToString() ?? "",
                    eMail = rd["eMail"].ToString() ?? "",
                    ePhone = rd["ePhone"].ToString() ?? "",
                    eSalary = Convert.ToDecimal(rd["eSalary"]),
                    eIsActive = Convert.ToInt32(rd["eIsActive"]) == 1,
                    PerformanceScore = perf
                });
            }

            return list;
        }
       
        public int Add(Employees emp)
        {   
            var con = Db.OpenConnection();
            const string sql = @"
INSERT INTO Employees
(eNo, eFullName, eDepartmentId, eTitle, eMail, ePhone, eSalary, eIsActive)
VALUES
(@no, @name, @dep, @title, @mail, @phone, @salary, @active);
SELECT LAST_INSERT_ID();";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@no", emp.eNo);
            cmd.Parameters.AddWithValue("@name", emp.eFullName);
            cmd.Parameters.AddWithValue("@dep", emp.eDepartmentId);
            cmd.Parameters.AddWithValue("@title", emp.eTitle);
            cmd.Parameters.AddWithValue("@mail", emp.eMail);
            cmd.Parameters.AddWithValue("@phone", emp.ePhone);
            cmd.Parameters.AddWithValue("@salary", emp.eSalary);
            cmd.Parameters.AddWithValue("@active", emp.eIsActive ? 1 : 0);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Update(Employees emp, bool canEditSalary)
        {
            var con = Db.OpenConnection();
            var sql = canEditSalary
            ? @"UPDATE Employees SET
                eFullName=@name, eDepartmentId=@dep, eTitle=@title,
                eMail=@mail, ePhone=@phone, eSalary=@salary
               WHERE eId=@id;"
            : @"UPDATE Employees SET
                eFullName=@name, eDepartmentId=@dep, eTitle=@title,
                eMail=@mail, ePhone=@phone
               WHERE eId=@id;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", emp.eId);
            cmd.Parameters.AddWithValue("@name", emp.eFullName);
            cmd.Parameters.AddWithValue("@dep", emp.eDepartmentId);
            cmd.Parameters.AddWithValue("@title", emp.eTitle);
            cmd.Parameters.AddWithValue("@mail", emp.eMail);
            cmd.Parameters.AddWithValue("@phone", emp.ePhone);
            if (canEditSalary)
                cmd.Parameters.AddWithValue("@salary", emp.eSalary);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool SetActive(int eId, bool isActive)
        {
             var con = Db.OpenConnection();
            const string sql = @"UPDATE Employees SET eIsActive=@a WHERE eId=@id;";
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", isActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", eId);
            return cmd.ExecuteNonQuery() > 0;
        }
        public int GetDepartmentIdByEmployeeId(int employeeId)
        {
            var con = Db.OpenConnection();

            const string sql = @"SELECT eDepartmentId FROM Employees WHERE eId = @employeeId LIMIT 1;";
            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@employeeId", employeeId);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                throw new Exception("Çalışanın departmanı bulunamadı.");

            return Convert.ToInt32(result);
        }
        public Employees GetById(int eId)
        {
            using (var con = Db.OpenConnection())
            {
                const string sql = @"
SELECT 
    e.eId, e.eNo, e.eFullName, e.eDepartmentId,
    IFNULL(e.eTitle,'') eTitle,
    IFNULL(e.eMail,'') eMail,
    IFNULL(e.ePhone,'') ePhone,
    IFNULL(e.eSalary,0) eSalary,
    e.eIsActive
FROM Employees e
WHERE e.eId = @id
LIMIT 1;";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", eId);

                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;

                    return new Employees
                    {
                        eId = Convert.ToInt32(rd["eId"]),
                        eNo = rd["eNo"].ToString() ?? "",
                        eFullName = rd["eFullName"].ToString() ?? "",
                        eDepartmentId = Convert.ToInt32(rd["eDepartmentId"]),
                        eTitle = rd["eTitle"].ToString() ?? "",
                        eMail = rd["eMail"].ToString() ?? "",
                        ePhone = rd["ePhone"].ToString() ?? "",
                        eSalary = Convert.ToDecimal(rd["eSalary"]),
                        eIsActive = Convert.ToInt32(rd["eIsActive"]) == 1
                    };
                }
            }
        }

        public bool UpdateContact(int eId, string mail, string phone)
        {
            using (var con = Db.OpenConnection())
            {
                const string sql = @"
UPDATE Employees
SET eMail = @mail, ePhone = @phone
WHERE eId = @id;";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", eId);
                cmd.Parameters.AddWithValue("@mail", mail ?? "");
                cmd.Parameters.AddWithValue("@phone", phone ?? "");
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}

