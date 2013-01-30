using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public static class Randomizations
    {
        private static readonly Random Rand = new Random();

        public static double BoxMuller(this Random rand, double mean, double stdDev)
        {
            double u1 = rand.NextDouble();
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2);
            double randNormal =
                         mean + stdDev * randStdNormal;
            return randNormal;
        }

        public static void Knuth<T>(this List<T> list)
        {
            for (var i = list.Count - 1; i > 0; --i)
            {
                var j = Rand.Next(0, i);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        public static void OverhandShuffle<T>(this List<T> list)
        {
            List<T> results = list.Select(t => t).ToList();
            var copied = 0; 
            while (copied != list.Count)
            {
                var toCopy = (int)Rand.BoxMuller(10, 3);
                if (copied + toCopy > list.Count)
                {
                    toCopy = list.Count - copied;
                }
                foreach (var i in Enumerable.Range(0, toCopy))
                {
                    list[list.Count - copied - toCopy + i] = results[copied + i];
                }
                copied += toCopy;
            }
        }

        public static void Riffle<T>(this List<T> list)
        {
            var half = (int)Rand.BoxMuller(26, 2);
            var top = new Queue<T>(Enumerable.Range(0, half).Select(i => list[i]).ToList());
            var bottom = new Queue<T>(Enumerable.Range(half, list.Count - half).Select(i => list[i]).ToList());

            list.Clear();

            while (top.Count != 0 || bottom.Count != 0)
            {
                int take;
                take = Math.Abs((int) Rand.BoxMuller(0, 1)) + 1;
                if (take > top.Count)
                    take = top.Count;
                list.AddRange(Enumerable.Range(0, take).Select(i => top.Dequeue()));
                take = Math.Abs((int)Rand.BoxMuller(0, 1)) + 1;
                if (take > bottom.Count)
                    take = bottom.Count;
                list.AddRange(Enumerable.Range(0, take).Select(i => bottom.Dequeue()));
            }
        }
    }
}
