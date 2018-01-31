using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public interface IComputeAreaMethod
    {
        string Name { get; }

        bool CanUse(Figure figure);

        double Compute(Figure figure);
    }

    public class AreaComputationMethod<TFigure> : IComputeAreaMethod where TFigure : Figure
    {
        public virtual string Name
        {
            get
            {
                return "Unknown";
            }
        }

        public bool CanUse(Figure figure)
        {
            var genericFigure = figure as TFigure;
            if (genericFigure == null)
            {
                return false;
            }

            return CanUseInternal(genericFigure);
        }

        public double Compute(Figure figure)
        {
            if (!CanUse(figure))
            {
                throw new InvalidOperationException($"Method for computing area '{Name}' ({GetType().FullName}) cannot be used for figure {figure}");
            }

            var genericFigure = figure as TFigure;
            return ComputeInternal(genericFigure);
        }

        protected virtual bool CanUseInternal(TFigure figure)
        {
            return true;
        }

        protected virtual double ComputeInternal(TFigure figure)
        {
            throw new NotImplementedException();
        }
    }
}
