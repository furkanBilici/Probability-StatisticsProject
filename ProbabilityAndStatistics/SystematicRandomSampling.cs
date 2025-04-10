using System;
using System.Collections.Generic;

namespace ProbabilityAndStatistics
{
    internal class SystematicRandomSampling
    {
        public List<int> SystematicRandom(int listCount, int sampleCount)
        {
            List<int> systematicRandom = new List<int>();
            Random rn = new Random();

            int k = listCount / sampleCount;
            int r = rn.Next(0, k); 

            for (int i = 0; i < sampleCount; i++)
            {
                int index = r + (i * k);
                if (index >= listCount)
                    break;

                systematicRandom.Add(index);
            }

            return systematicRandom;
        }

        public void GetSRSList(List<int> SRSList)
        {
            Console.WriteLine(string.Join(" & ", SRSList));
        }
    }
}


