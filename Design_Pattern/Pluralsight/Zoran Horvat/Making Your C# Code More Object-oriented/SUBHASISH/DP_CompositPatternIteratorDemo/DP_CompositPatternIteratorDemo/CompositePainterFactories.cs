using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DP_CompositPatternIteratorDemo
{
    public static class CompositePainterFactories
    {
        public static IPainter CreateGroup(IEnumerable<PropertionalPainter> painters) =>
            new CompositPainter<PropertionalPainter>(painters, (sqMeters, sequence) =>
            {

                TimeSpan time = TimeSpan.FromHours(1 / sequence.Where(painter => painter.IsAvaiable).
                           Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours).Sum());

                double cost = sequence.Where(painter => painter.IsAvaiable).
                                Select(painter => painter.EstimateCompensation(sqMeters) / painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours).Sum();


                return new PropertionalPainter()
                {
                    TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                    DollarPerSqMeter = cost / time.TotalHours
                };
            });


        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
            new CompositPainter<IPainter>(painters, (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
            new CompositPainter<IPainter>(painters, (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));
    }
}
