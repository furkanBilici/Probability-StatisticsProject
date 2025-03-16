using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class SystematicRandomSampling
    {
        public List<int> SystematicRandom(int listCount, int sampleCount)
        {
            List<int> systematicRandom = new List<int>();
            Random rn = new Random();

            int k = listCount / sampleCount;
            int r = rn.Next(1, k + 1); 

            for (int i = 0; i < sampleCount; i++)
            {
                int index = r + (i * k);
                if (index <= listCount)
                {
                    systematicRandom.Add(index);
                }
            }

            return systematicRandom;
        }
        public void GetSRSList(List<int> SRSList)
        {
            Console.WriteLine(string.Join(" & ", SRSList));
        }
    }
}
