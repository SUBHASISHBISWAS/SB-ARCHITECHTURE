using System;
using System.Linq;
using System.Collections.Generic;
namespace DP_CompositPatternIteratorDemo
{
    public class CompositPainter<TPainter> : IPainter where TPainter : IPainter
    {

        private IEnumerable<TPainter> Painters;
        public CompositPainter(IEnumerable<TPainter> painters, Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            Painters = painters.ToList();
            Reduce = reduce;
        }

        public bool IsAvaiable => Painters.Any(painter => painter.IsAvaiable);

        public double EstimateCompensation(double sqMeters) => Reduce(sqMeters,Painters).EstimateCompensation(sqMeters);


        public TimeSpan EstimateTimeToPaint(double sqMeters) => Reduce(sqMeters,Painters).EstimateTimeToPaint(sqMeters);

        private Func<double, IEnumerable<TPainter>, IPainter> Reduce {get;}

        /*
        private  IPainter Reduce(double sqMeters)
        {
            TimeSpan time = TimeSpan.FromHours(1 / Painters.Where(painter => painter.IsAvaiable).
                            Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours).Sum());

            double cost = Painters.Where(painter => painter.IsAvaiable).
                            Select(painter => painter.EstimateCompensation(sqMeters) / painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours).Sum();


            return new PropertionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarPerSqMeter = cost / time.TotalHours
            };
        }
        */
    }
}
