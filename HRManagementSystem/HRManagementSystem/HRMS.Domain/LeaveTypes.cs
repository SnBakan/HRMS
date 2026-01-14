using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain
{
    public class LeaveTypes
    {
        public int ltId { get; set; }
        public string ltName { get; set; } = "";
        public string ltColorHex { get; set; } = "#000000";
        public bool ltIsActive { get; set; }


    }
}
