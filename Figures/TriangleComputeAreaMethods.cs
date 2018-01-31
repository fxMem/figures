using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{

    public class GeronMethod : AreaComputationMethod<Triangle>
    {
        public override string Name
        {
            get
            {
                return "Geron";
            }
        }

        protected override double ComputeInternal(Triangle figure)
        {
            var p = (figure.A + figure.B + figure.C) / 2d;
            return Math.Sqrt(p * (p - figure.A) * (p - figure.B) * (p - figure.C));
        }
    }

    public class SquareTriangleMethod : AreaComputationMethod<Triangle>
    {
        public override string Name
        {
            get
            {
                return "SquareTriangle";
            }
        }

        protected override bool CanUseInternal(Triangle figure)
        {
            // Checking for square triangle using Pifagor theorem (a^2 + b^2 = c^2)
            var sides = GetSides(figure);
            var r = sides.A * sides.A + sides.B * sides.B;

            return MathHelper.Equals(r, sides.Hypotenuse * sides.Hypotenuse);
        }

        struct TriangleSides
        {
            public double Hypotenuse;

            public double A;

            public double B;
        }

        // Defines which side of trianle is hypotenuse
        private TriangleSides GetSides(Triangle triangle)
        {
            var result = new TriangleSides()
            {
                Hypotenuse = triangle.C,
                A = triangle.A,
                B = triangle.B
            };

            var hypotenuse = Math.Max(Math.Max(triangle.A, triangle.B), triangle.C);
            if (result.A == hypotenuse)
            {
                result.Hypotenuse = result.A;
                result.A = triangle.C;
            }
            else if (result.B == hypotenuse)
            {
                result.Hypotenuse = result.B;
                result.B = triangle.C;
            }

            return result;
        }

        protected override double ComputeInternal(Triangle figure)
        {
            var sides = GetSides(figure);
            return (sides.A * sides.B) / 2;
        }
    }
}
