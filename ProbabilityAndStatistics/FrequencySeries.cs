using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class FrequencySeries
    {
        public Dictionary<float, int> Frequency(List<float> nonFrequencyList)
        {
            Dictionary<float,int> frequencyDict = new Dictionary<float,int>();
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
            return frequencyDict;
        }
        public void GetFrequency(Dictionary<float,int> frequencyDict) 
        {
            foreach (var pair in frequencyDict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} times");
            }
        }
    }
}
