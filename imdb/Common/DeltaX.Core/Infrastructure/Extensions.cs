using System;
using System.Collections.Generic;
using System.Text;

namespace DeltaX.Core.Infrastructure
{
    public static class Extensions
    {
        public static bool IsNullOrDefault<T>(this T type)
        {
            return (type == null || type.Equals(default(T)));
        }
    }
}
