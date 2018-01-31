using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : Figure
    {
        // In case of trianlge, we can add support for different computational methods. It's not particularly useful
        // in this example, but shows the idea.
        private IComputeAreaMethod _computeAreaMethod;

        private double _a;
        private double _b;
        private double _c;

        public double A
        {
            get
            {
                return _a;
            }
        }

        public double B
        {
            get
            {
                return _b;
            }
        }

        public double C
        {
            get
            {
                return _c;
            }
        }

        public static Triangle Create(double a, double b, double c)
        {
            // "Default" method, works for all types of triangles, in case client doesn't want to think about it.
            return new Triangle(a, b, c, new GeronMethod());
        }

        // I'm not considering different types of defining triangle here (like, by side and 2 angles, etc)
        public Triangle(double a, double b, double c, IComputeAreaMethod computeAreaMethod)
        {
            _a = a;
            _b = b;
            _c = c;

            // For simplicity, there is no means to change method afterwards
            if (computeAreaMethod == null)
            {
                throw new ArgumentNullException("computeAreaMethod");
            }

            if (_a < 0 || _b < 0 || _c < 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides cannot be lesser than 0");
            }

            if (!TriangleExists())
            {
                throw new ArgumentException($"Triangle with sides {a}, {b}, {c} cannot exist");
            }

            _computeAreaMethod = computeAreaMethod;
        }

        private bool TriangleExists()
        {
            return _a + _b > _c && _a + _c > _b && _b + _c > _a;
        }

        protected override double ComputeAreaInternal()
        {
            return _computeAreaMethod.Compute(this);
        }

        protected override string ToStringInternal()
        {
            return $"Side lengths: {A},{B},{C}";
        }
    }
}
