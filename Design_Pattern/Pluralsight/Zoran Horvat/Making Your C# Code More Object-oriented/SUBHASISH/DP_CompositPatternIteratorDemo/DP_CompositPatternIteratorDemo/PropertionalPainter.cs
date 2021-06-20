using System;
namespace DP_CompositPatternIteratorDemo
{
    public class PropertionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter {get;set; }

        public double DollarPerSqMeter { get; set; }

        public PropertionalPainter()
        {
        }

        public bool IsAvaiable => true;

        public double EstimateCompensation(double sqMeters) => EstimateTimeToPaint(sqMeters).TotalHours * DollarPerSqMeter;
        

        public TimeSpan EstimateTimeToPaint(double sqMeters) => TimeSpan.FromDays(TimePerSqMeter.TotalHours * sqMeters);

    }
}
