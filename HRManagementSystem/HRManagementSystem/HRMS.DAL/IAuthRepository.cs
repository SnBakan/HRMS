using HRMS.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public interface IAuthRepository
    {
        UserDto GetUserByUsername(string username);
        bool ValidatePassword(int userId, string plainPassword);
        List<RoleDto> GetRolesByUserId(int userId);
    }
}
