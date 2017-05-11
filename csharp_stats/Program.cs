﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_stats
{
    class Program
    {
        static void Main(string[] args)
        {
            //meanMedianMode();

            //weightedMean();
            //stdDeviation();
            Quartiles();

            Console.ReadKey();
        }


        private static void Quartiles()
        {
            int numOfElements;
            int.TryParse(Console.ReadLine(), out numOfElements);

            var scores = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            scores.Sort();

            var take = numOfElements / 2;


            Console.WriteLine($"{Median(scores.Take(take).ToList()):0}");
            Console.WriteLine($"{Median(scores):0}");
            Console.WriteLine(numOfElements % 2 == 0
                ? $"{Median(scores.Skip(take).Take(take).ToList()):0}"
                : $"{Median(scores.Skip(take + 1).Take(take).ToList()):0}");
        }


        private static double Median(List<int> nums)
        {
            if (nums.Count % 2 != 0) return nums[nums.Count / 2];
            var av1 = nums[nums.Count / 2];
            var av2 = nums[(nums.Count / 2) - 1];
            return (av1 + av2) / 2.0;
        }


        static void stdDeviation()
        {
            int numOfElements;
            int.TryParse(Console.ReadLine(), out numOfElements);

            var scores = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var avg = scores.Average();
            var innner_numer = scores.Select(i => (i - avg) * (i - avg)).Aggregate((start, next) => start += next);
            var stdDev = Math.Sqrt((innner_numer / (double)numOfElements));
            Console.WriteLine($"{stdDev:0.0}");
        }

        static void weightedMean()
        {
            int numOfElements;
            int.TryParse(Console.ReadLine(), out numOfElements);


            var scores = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var weights = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var numer = scores.Zip(weights, (scr, weight) => scr * weight)
                .Aggregate((strt, nxt) => strt += nxt);

            var denom = (double)weights.Aggregate((strt, nxt) => strt += nxt);

            Console.WriteLine($"{numer / denom:0.0}");
        }

        static void meanMedianMode()
        {
            // Get number of elements
            int numOfElements;
            int.TryParse(Console.ReadLine(), out numOfElements);

            // Get list of numbers
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            // Sort
            nums.Sort();


            // MEAN
            Console.WriteLine(nums.Average());


            // MEDIAN
            Console.WriteLine(Median(nums));


            // MODE
            var groups = nums.GroupBy(x => x);
            var maxCount = groups.Max(g => g.Count());
            var mode = groups.First(g => g.Count() == maxCount).Key;
            Console.WriteLine(mode);
        }
    }
}