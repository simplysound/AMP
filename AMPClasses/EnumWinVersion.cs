using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AMPClasses
{
    public enum EnumWinVersion : int
    {
        [Display(Name = "UNKNOWN")]
        UNKNOWN = 0,
        [Display(Name = "WIN95")]
        WIN95 = 1,
        [Display(Name = "WIN98")]
        WIN98 = 2,
        [Display(Name = "WINME")]
        WINME = 3,
        [Display(Name = "WINNT")]
        WINNT = 4,
        [Display(Name = "WIN2000")]
        WIN2000 = 5,
        [Display(Name = "WINXP")]
        WINXP = 6,
        [Display(Name = "WIN2003")]
        WIN2003 = 7,
        [Display(Name = "WINVISTA")]
        WINVISTA = 8,
        [Display(Name = "WIN2008")]
        WIN2008 = 9,
        [Display(Name = "WIN7")]
        WIN7 = 10,
        [Display(Name = "WIN2008R2")]
        WIN2008R2 = 11,
        [Display(Name = "WIN8")]
        WIN8 = 12,
        [Display(Name = "WIN81")]
        WIN81 = 13,
        [Display(Name = "WIN10")]
        WIN10 = 14
    }
}
