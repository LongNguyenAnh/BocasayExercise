using System.Collections.Generic;
using System.Linq;

namespace Services.Common
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source != null && source.Any())
                return false;
            else
                return true;
        }
    }
}
