using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPClasses
{
    public class ServiceItem
    {
        public String ServiceName;
        public String DisplayName;
        public EnumServiceAction ServiceAction;

        public ServiceItem()
        {
            ServiceName = String.Empty;
            DisplayName = String.Empty;
            ServiceAction = EnumServiceAction.UNDEFINED;
        }
    }
}
