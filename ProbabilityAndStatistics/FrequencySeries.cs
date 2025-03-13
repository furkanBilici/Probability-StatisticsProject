using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class FrequencySeries
    {
        Dictionary<float,int> frequencyDict = new Dictionary<float,int>();
        public Dictionary<float, int> Frequency(List<float> nonFrequencyList)
        {
            foreach (var item in nonFrequencyList)
            {
                if (frequencyDict.ContainsKey(item))
                {
                    frequencyDict[item] += 1;
                }
                else
                {
                    frequencyDict[item] = 1;
                }  
            }
            GetFrequency();
            return frequencyDict;
        }
        public void GetFrequency() 
        {
            foreach (var pair in frequencyDict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} times");
            }
        }
    }
}
