using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Auth
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsActive { get; set; }
    }
}
