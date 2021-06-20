using System;
using System.Linq;
using System.Collections.Generic;

namespace DP_CompositPatternIteratorDemo
{
    public static class EnumerableExtensions
    {
        /*
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> => sequence.Aggregate((T)null, (best, curr) => 
            best ==null || criterion(curr).CompareTo(criterion(best)) < 0 ? best : curr);
        */

        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> => 
            sequence.Select(obj=>Tuple.Create(obj, criterion(obj))).
            Aggregate((Tuple<T,TKey>)null,(best,curr)=> best==null || curr.Item2.CompareTo(best.Item2) < 0 ?best:curr).Item1;


    }
}
