using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain
{
    public class Roles
    {
        public int rId { get; set; }
        public string rRoleKey { get; set; } = "";
        public string rRoleName { get; set; } = "";
        
    }
}
