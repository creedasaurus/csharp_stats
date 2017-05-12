using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace csharp_stats
{
    class StatsFuncs
    {
        public List<int> Nums { get; }

        public StatsFuncs(List<int> n)
        {
            Nums = n.Select(s => s).ToList();
        }

        public double Median()
        {
            if (Nums.Count % 2 != 0) return Nums[Nums.Count / 2];
            var av1 = Nums[Nums.Count / 2];
            var av2 = Nums[Nums.Count / 2 - 1];
            return (av1 + av2) / 2.0;
        }

        private double Median(List<int> nms)
        {
            if (nms.Count % 2 != 0) return nms[nms.Count / 2];
            var av1 = nms[nms.Count / 2];
            var av2 = nms[nms.Count / 2 - 1];
            return (av1 + av2) / 2.0;
        }

        public double Quartile(int q)
        {
            var take = Nums.Count / 2;

            switch (q)
            {
                case 1:
                    return Median(Nums.Take(take).ToList());
                case 2:
                    return Median();
                case 3:
                    return Nums.Count % 2 == 0
                        ? Median(Nums.Skip(take).Take(take).ToList())
                        : Median(Nums.Skip(take + 1).Take(take).ToList());
                default:
                    Console.WriteLine("invalid quartile. Only 1, 2, or 3");
                    return -1.0;
            }
        }

        public double StdDeviation()
        {
            var avg = Nums.Average();
            var innnerNumer = Nums.Select(i => (i - avg) * (i - avg)).Aggregate((start, next) => start += next);
            var stdDev = Math.Sqrt(innnerNumer / Nums.Count);
            return stdDev;
        }

        public double WeightedMean(List<int> weights)
        {
            if (weights.Count != Nums.Count) return -1.0;

            var numer = Nums.Zip(weights, (scr, weight) => scr * weight)
                .Aggregate((strt, nxt) => strt += nxt);

            var denom = (double)weights.Aggregate((strt, nxt) => strt += nxt);

            return numer / denom;
        }

    }
}
