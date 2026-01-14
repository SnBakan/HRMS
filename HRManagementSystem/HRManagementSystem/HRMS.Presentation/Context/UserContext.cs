using HRMS.Domain.Auth;
using System.Collections.Generic;
using System.Linq;

namespace HRMS.Presentation.Context
{
    public static class UserContext
    {
        public static UserDto CurrentUser { get; private set; }
        public static List<UserRole> Roles { get; private set; }

        public static void SetUser(UserDto user, List<UserRole> roles)
        {
            CurrentUser = user;
            Roles = roles;
        }
        public static bool HasRole(UserRole role)
        {
            return Roles != null && Roles.Contains(role);
        }
    }
}

