using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _163311055_bm.Classes
{
    public static class Extensions
    {
        /// <summary>
        /// Ağırlık Merkezi hesaplaması method tanımlaması yer almaktadır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records"></param>
        /// <param name="value"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static double WeightedAverageCalculation<T>
                      (this IEnumerable<T> records, Func<T, double> value, Func<T, double> weight)
        {
            double weightedValueSum = records.Sum(x => value(x) * weight(x));
            double weightSum = records.Sum(x => value(x));

            if (weightSum != 0)
                return weightedValueSum / weightSum;
            return 0;
        }
    }
}
