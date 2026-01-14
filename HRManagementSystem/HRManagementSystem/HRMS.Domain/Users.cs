using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain
{
    public class Users
    {
        public int uId { get; set; }
        public string uName { get; set; } = "";
        public string uPasswordHash { get; set; } = "";
        public int uEmployeeId { get; set; }
        public bool uIsActive { get; set; }
        public DateTime uLastLoginAt { get; set; }

    }
}
