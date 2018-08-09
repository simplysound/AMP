using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPClasses
{
    public class ServiceItemComparer : IEqualityComparer<ServiceItem>
    {
        public bool Equals(ServiceItem item1, ServiceItem item2)
        {            
            if (Object.ReferenceEquals(item1, item2)) return true;            
            if (Object.ReferenceEquals(item1, null) || Object.ReferenceEquals(item2, null))
                return false;
            ///////////////////////////////////////////////////////////////////
            // Compares services by Display Names
            // return (item1.DisplayName.Trim().StartsWith(item2.DisplayName.Trim()));
            
            ///////////////////////////////////////////////////////////////////
            // Compares services by Service Names
            return (item1.ServiceName.Trim().StartsWith(item2.ServiceName.Trim()));
        }
        public int GetHashCode(ServiceItem item)
        {
            if (Object.ReferenceEquals(item, null)) return 0;            
            int hashDisplayName = item.DisplayName == null ? 0 : item.DisplayName.GetHashCode();            
            return hashDisplayName;
        }
    }
}
