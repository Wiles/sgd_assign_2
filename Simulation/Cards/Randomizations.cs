//File:     Randomizations.cs
//Name:     Samuel Lewis (5821103)
//Date:     02/01/2013
//Class:    Simulation and Game Development
//Ass:      2
//
//Desc:     Randomization and shuffling extension methods 
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    /// <summary>
    /// Contains extension methods for randomization and shuffling
    /// </summary>
    public static class Randomizations
    {
        /// <summary>
        /// The instance of random to use
        /// </summary>
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Returns a random number using the box muller algorithm.
        /// 
        /// This allows a random number to be generated to following a standard deviation around the mean
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="stdDev">The standard deviation</param>
        /// <returns>random number</returns>
        public static double BoxMuller(this Random rand, double mean, double stdDev)
        {
            double u1 = rand.NextDouble();
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal =
                         mean + stdDev * randStdNormal;
            return randNormal;
        }

        /// <summary>
        /// Shuffles the deck using the knuth shuffle algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
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

        /// <summary>
        /// Overhand shuffles the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        public static void OverhandShuffle<T>(this List<T> list)
        {
            var results = list.Select(t => t).ToList();
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

        /// <summary>
        /// Riffle shuffles the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        public static void Riffle<T>(this List<T> list)
        {
            var half = (int)Rand.BoxMuller(26, 3);
            var top = new Queue<T>(Enumerable.Range(0, half).Select(i => list[i]).ToList());
            var bottom = new Queue<T>(Enumerable.Range(half, list.Count - half).Select(i => list[i]).ToList());

            list.Clear();

            while (top.Count != 0 || bottom.Count != 0)
            {
                var take = Math.Abs((int) Rand.BoxMuller(0, 1)) + 1;
                if (take > top.Count)
                    take = top.Count;
                list.AddRange(Enumerable.Range(0, take).Select(i => top.Dequeue()));
                take = Math.Abs((int)Rand.BoxMuller(0, 1.5)) + 1;
                if (take > bottom.Count)
                    take = bottom.Count;
                list.AddRange(Enumerable.Range(0, take).Select(i => bottom.Dequeue()));
            }
        }
    }
}
