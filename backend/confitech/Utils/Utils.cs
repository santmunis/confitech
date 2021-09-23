using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Students.Enumerations;

namespace Api.Utils
{
    public static class Utils
    {
        public static bool BornDateValidator(DateTimeOffset bornDate)
        {
            return bornDate < DateTimeOffset.Now;
        }

        public static bool ScholarityValidator(EUserScholarity scholarity)
        {
            return Enum.IsDefined(typeof(EUserScholarity), scholarity);
        }
    }
}
