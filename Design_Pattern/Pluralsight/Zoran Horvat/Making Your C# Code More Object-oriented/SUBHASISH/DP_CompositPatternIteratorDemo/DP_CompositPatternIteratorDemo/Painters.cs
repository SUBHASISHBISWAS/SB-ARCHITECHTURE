using System;
using System.Linq;
using System.Collections.Generic;

namespace DP_CompositPatternIteratorDemo
{
    public class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }
        public Painters(IEnumerable<IPainter> painters)
        {
            ContainedPainters = painters;
        }

        public Painters GetAvailable()=> new Painters(ContainedPainters.Where(Painter => Painter.IsAvaiable));

        public IPainter GetCheapestOne(double sqMeters) =>
            ContainedPainters.WithMinimum(painter => painter.EstimateCompensation(sqMeters));

         public IPainter GetFastestOne(double sqMeters) =>
            ContainedPainters.WithMinimum(painter => painter.EstimateCompensation(sqMeters));

    }
}
