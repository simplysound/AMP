using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AMPClasses
{
    public class ServiceStartStopProtocolItem
    {
        public DateTime DT { get; set; }        
        public String Name { get; set; }
        public String StatusBefore { get; set; }
        public String StatusAfter { get; set; }
        public String Result { get; set; }

        public ServiceStartStopProtocolItem()
        {
            DT = DateTime.Now;
            Name = String.Empty;
            StatusBefore = String.Empty;
            StatusAfter = String.Empty;
            Result = String.Empty;
        }
    }
}
