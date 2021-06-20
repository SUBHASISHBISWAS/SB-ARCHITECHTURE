using System;
namespace DP_CompositPatternIteratorDemo
{
    public interface IPainter
    {
        bool IsAvaiable { get;}
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }
}
