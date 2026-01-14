using HRMS.DAL.Database;
using HRMS.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace HRMS.DAL
{
    public class MySqlDepartmentRepository : IDepartmentRepository
    {
        public List<Departments> GetAll(bool onlyActive)
        {
            var list = new List<Departments>();
            var con = Db.OpenConnection();

            var sql = @"
SELECT dId, dName, dIsActive, dCreatedAt
FROM Departments
WHERE (@onlyActive = 0 OR dIsActive = 1)
ORDER BY dId ASC;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@onlyActive", onlyActive ? 1 : 0);

             var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Departments
                {
                    dId = Convert.ToInt32(rd["dId"]),
                    dName = rd["dName"].ToString() ?? "",
                    dIsActive = Convert.ToInt32(rd["dIsActive"]) == 1,
                    dCreatedAt = Convert.ToDateTime(rd["dCreatedAt"])
                });
            }

            return list;
        }

        public int Add(string name)
        {
            var con = Db.OpenConnection();

            const string sql = @"
INSERT INTO Departments (dName, dIsActive)
VALUES (@name, 1);
SELECT LAST_INSERT_ID();";

           var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Update(int id, string name)
        {
            var con = Db.OpenConnection();

            const string sql = @"
UPDATE Departments
SET dName = @name
WHERE dId = @id;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool SoftDelete(int id)
        {
            var con = Db.OpenConnection();

            const string sql = @"
UPDATE Departments
SET dIsActive = 0
WHERE dId = @id;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }
        public bool SetActive(int id, bool isActive)
        {
            
            var con = Db.OpenConnection();

            const string sql = @"
UPDATE Departments
SET dIsActive = @a
WHERE dId = @id;";

            var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", isActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

    }
}

