using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AMPClasses
{
    public enum EnumLightState : int
    {
        YELLOW = 0,
        GREEN = 1,
        RED = 2,
        YELLOW_BLINK = 3
    }
}
