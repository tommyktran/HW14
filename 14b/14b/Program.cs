using System;
using System.Collections.Generic;

namespace _14b
{
    class Program
    {
        static void Main(string[] args)
        {

            double[,] coords =
            {
                { 11, 10 },
                { 16, 16 },
                { 3, 15 },
                { 6, 17 },
                { 10, 5 },
                { 14, 11 },
                { 5, 19 },
                { 15, 18 },
                { 17, 20 },
                { 18, 22 }
            };
            double d = 6.0;


            Frequencies(coords, d);

        }

        static void Frequencies(double[,] coords, double d)
        {
            var results = new List<string>();
            int numberOfFrequencies = 1;
            var frequencies = new List<int>();
            Frequencies(coords, d, results, numberOfFrequencies, frequencies, 0);
        }
        
        static bool Frequencies(double[,] coords, double d, List<string> results, int numberOfFrequencies, List<int> frequencies, int index)
        {
            if (coords.Length / 2 == frequencies.Count)
            {
                foreach(string thing in results)
                {
                    Console.WriteLine(thing);
                }
                return true;
            }
            var newCoords = coords;
            var possibleFrequencies = new List<int> { };
            for (int x = 1; x <= numberOfFrequencies; x++)
            {
                possibleFrequencies.Add(x);
            }
            // assign a frequency
            //double distance = Math.Sqrt()
            
            

            for (int k = index - 1; k >= 0; k--)
            {
                double distance = Math.Sqrt(Math.Pow((newCoords[k, 0] - newCoords[index, 0]), 2) + Math.Pow((newCoords[k, 1] - newCoords[index, 1]), 2));
                if (distance <= d && possibleFrequencies.Contains(frequencies[k]))
                {
                    possibleFrequencies.Remove(frequencies[k]);
                }
            }

            if (possibleFrequencies.Count == 0)
            {
                return false;
            }
            for (int j = 0; j <= possibleFrequencies.Count-1; j++)
            {
                frequencies.Add(possibleFrequencies[j]);
                results.Add("Tower " + (index+1) + " gets Frequency " + possibleFrequencies[j]);
                if (!Frequencies(newCoords, d, results, numberOfFrequencies, frequencies, index + 1))
                {
                    if (Frequencies(newCoords, d, new List<string>(), numberOfFrequencies + 1, new List<int>(), 0))
                    {
                        return true;
                    }
                } else
                {
                    return true;
                }
                frequencies.RemoveAt(frequencies.Count - 1);
                results.RemoveAt(frequencies.Count - 1);
            }
            return false;

        }
        

    }
}
