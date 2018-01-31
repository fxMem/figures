using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Cirle : Figure
    {
        private double _radius;

        public double Radius
        {
            get
            {
                return _radius;
            }
        }

        public Cirle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException("Circle radius cannot be negative!");
            }

            _radius = radius;
        }

        protected override double ComputeAreaInternal()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}
