using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure
    {
        public double ComputeArea()
        {
            // May add additional setup, logging or exception handilng here (if needed)
            return ComputeAreaInternal();
        }

        public override string ToString()
        {
            return $"{GetType().FullName}, [{ToStringInternal()}]";
        }

        protected abstract double ComputeAreaInternal();

        protected virtual string ToStringInternal()
        {
            return string.Empty;
        }
    }

    
}
