using System;
using System.Collections.Generic;

namespace ProbabilityAndStatistics
{
    internal class PermutationAndCombination
    {
        public Dictionary<string, double> PermutationCombinationMeasurement(int n, int r)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            result.Add("Permutation", Permutation(n, r));
            result.Add("Combination", Combination(n, r));
            return result;
        }

        public void GetPermutationAndCombination(Dictionary<string, double> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        private double Permutation(int n, int r)
        {
            return Factorial(n) / Factorial(n - r);
        }

        private double Combination(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        private double Factorial(int k)
        {
            if (k == 0 || k == 1) return 1; // 0! = 1! = 1
            double factorial = 1;
            for (int i = 2; i <= k; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
