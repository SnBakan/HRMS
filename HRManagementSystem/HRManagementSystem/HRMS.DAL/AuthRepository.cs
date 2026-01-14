using HRMS.Domain.Auth;
using HRMS.DAL.Database;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace HRMS.DAL.Auth
{
    public class AuthRepository : IAuthRepository
    {
        public UserDto GetUserByUsername(string username)
        {
            const string sql = @"
SELECT uId, uName, uEmployeeId, uIsActive
FROM Users
WHERE uName = @uName
LIMIT 1;";

            using (var conn = new MySqlConnection(ConnectionStrings.Main))


            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@uName", username);
                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new UserDto
                    {
                        UserId = Convert.ToInt32(r["uId"]),
                        UserName = Convert.ToString(r["uName"]),
                        EmployeeId = r["uEmployeeId"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["uEmployeeId"]),
                        IsActive = Convert.ToInt32(r["uIsActive"]) == 1
                    };
                }
            }
        }

        public bool ValidatePassword(int userId, string plainPassword)
        {
            // Sprint-1: plain doğrulama (hash değil)
            const string sql = @"
SELECT COUNT(1)
FROM Users
WHERE uId = @uId AND uPasswordHash = @pwd
LIMIT 1;";

            using (var conn = new MySqlConnection(ConnectionStrings.Main)
)
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@uId", userId);
                cmd.Parameters.AddWithValue("@pwd", plainPassword);
                conn.Open();

                var result = Convert.ToInt32(cmd.ExecuteScalar());
                return result == 1;
            }
        }

        public List<RoleDto> GetRolesByUserId(int userId)
        {
            const string sql = @"
SELECT r.rId, r.rRoleKey, r.rRoleName
FROM UserRoles ur
JOIN Roles r ON r.rId = ur.urRoleId
WHERE ur.urUserId = @uId;";

            var list = new List<RoleDto>();

            using (var conn = new MySqlConnection(ConnectionStrings.Main))

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@uId", userId);
                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new RoleDto
                        {
                            RoleId = Convert.ToInt32(r["rId"]),
                            RoleKey = Convert.ToString(r["rRoleKey"]),
                            RoleName = Convert.ToString(r["rRoleName"])
                        });
                    }
                }
            }

            return list;
        }
    }
}

