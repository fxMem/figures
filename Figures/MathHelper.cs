using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public static class MathHelper
    {
        public static bool Equals(double a, double b, double presicion = 0.001 * 0.001 * 0.001)
        {
            return Math.Abs(a - b) < presicion;
        }
    }
}
