using System;
using System.Collections.Generic;
using System.Linq;

namespace DP_CompositPatternIteratorDemo
{
    public class Program
    {
        private static void FindChipestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            /* V1
            IPainter chipestpainter = null;
            double bestPrice = 0;
            foreach (var painter in painters)
            {
                if (painter.IsAvaiable())
                {
                    double price = painter.EstimateCompensation(sqMeters);
                    if (chipestpainter == null || price < bestPrice)
                    {
                        chipestpainter = painter; 
                    }
                }
            }
            return chipestpainter;
            */

            /* V2
            return
                   painters.
                        Where(painter => painter.IsAvaiable).
                        OrderBy(painter => painter.EstimateCompensation(sqMeters)).FirstOrDefault();  

            */

            /*V3
            return painters.Where(painter => painter.IsAvaiable).
                            Aggregate((best, curr) => best.EstimateCompensation(sqMeters) < curr.EstimateCompensation(sqMeters) ? best : curr);
                            */

            /*V3
            return painters.Where(painter => painter.IsAvaiable).
                            Aggregate((IPainter)null, (best, curr) => best.EstimateCompensation(sqMeters) < curr.EstimateCompensation(sqMeters) ? best : curr);
                            */

            /*v4
            return painters.Where(painter => painter.IsAvaiable).
                          WithMinimum(painter => painter.EstimateCompensation(sqMeters));
            */

        }



        /*V5
        private static IPainter FindFastesPainter(double sqMeters, IEnumerable<IPainter> painters)
        {

            return painters.Where(painter => painter.IsAvaiable).
                          WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }
        */

        /* V6
        private static IPainter FindChipestPainter(double sqMeters, Painters painters)
        {
            return painters.GetAvailable().GetCheapestOne(sqMeters);
        }
        */

        /* V6
        private static IPainter FindFastestPainter(double sqMeters, Painters painters)
        {
        return painters.GetAvailable().GetFastestOne(sqMeters);
        }
        */



        /*
        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time = TimeSpan.FromHours(1 / painters.Where(painter => painter.IsAvaiable).Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours).Sum());

            double cost = painters.Where(painter => painter.IsAvaiable).Select(painter => painter.EstimateCompensation(sqMeters) / painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours).Sum();


            return new PropertionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarPerSqMeter = cost / time.TotalHours
            };
        }
        */
    
        public static void Main(string [] args)
        {
            IEnumerable<PropertionalPainter> painters = new PropertionalPainter[10];

            IPainter painter1 = CompositePainterFactories.CreateGroup(painters);

            IPainter painter2 = CompositePainterFactories.CreateCheapestSelector(painters);

            IPainter painter3 = CompositePainterFactories.CreateFastestSelector(painters);
        }
    }
}
