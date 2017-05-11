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

            // TODO: get this part working
            switch (q)
            {
                case 1:
                    return Median();
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("invalid quartile. Only 1, 2, or 3");
                    break;
            }


            return 3.0;

            Console.WriteLine($"{Median(scores.Take(take).ToList()):0}");
            Console.WriteLine($"{Median(scores):0}");
            Console.WriteLine(numOfElements % 2 == 0
                ? $"{Median(scores.Skip(take).Take(take).ToList()):0}"
                : $"{Median(scores.Skip(take + 1).Take(take).ToList()):0}");
        }

    }
}
