using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AMPClasses
{
    public enum EnumServiceAction : int
    {
        [Display(Name = "STOP")]
        STOP = 0,
        [Display(Name = "START")]
        START = 1,        
        [Display(Name = "STOP_AND_RESTART")]
        STOP_AND_RESTART = 2,
        [Display(Name = "UNDEFINED")]
        UNDEFINED = 3
    }
}
