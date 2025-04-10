using System;
using System.Collections.Generic;

namespace ProbabilityAndStatistics
{
    internal class SystematicRandomSampling
    {
        public List<float> SystematicRandom(int listCount, int sampleCount)
        {
            List<float> systematicRandom = new List<float>();
            Random rn = new Random();

            float k = (float)listCount / (float)sampleCount; // Örnekleme aralığı
            float r = 1 + (float)rn.NextDouble() * k; // Rastgele başlangıç noktası (1 ile k arasında)

            for (int i = 0; i < sampleCount; i++)
            {
                float index = r + (i * k);
                if (index <= listCount)
                {
                    systematicRandom.Add(index);
                }
                else
                {
                    break; // Seçilen index listCount'u geçerse döngüyü kır
                }
            }

            return systematicRandom;
        }

        public void GetSRSList(List<float> SRSList)
        {
            Console.WriteLine(string.Join(" & ", SRSList));
        }
    }
}

