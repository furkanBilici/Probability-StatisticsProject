using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class MeasuresOfCentralTendencedy
    {
        Dictionary<string,float> centralTendencedy=new Dictionary<string,float>();  
        public Dictionary<string,float> MeasuresCentralT(List<float> listOg)
        {
            List<float> list = new List<float>(listOg);
            centralTendencedy.Add("ArithmeticMean", ArithmeticMean(list));
            centralTendencedy.Add("Median",Median(list));

            List<float> modes = Mode(list);
            for (int i = 0; i < modes.Count; i++)
            {
                if (modes[i] > 1) 
                { 
                    centralTendencedy.Add($"Mode{i + 1}", modes[i]);
                }
            }

            return centralTendencedy;
        }
        float ArithmeticMean(List<float>list)
        {
            float arithmetic;
            float sum=0;
            foreach (var item in list) 
            {
                sum+= item; 
            }
            arithmetic=sum/list.Count;
            return arithmetic;
        }
        public float Median(List<float> list)
        {
            float median;
            int index;
            if (list.Count%2==0)
            {
                index=list.Count/2;
                median = (list[index] + list[index+1])/2;
            }
            else
            {
                index = (list.Count + 1) / 2;
                median = list[index];
            }
            return median;
        }

        List<float> Mode(List<float> list)
        {
            Dictionary<float, int> modeTimes = new Dictionary<float, int>();

            foreach (var item in list)
            {
                if (modeTimes.ContainsKey(item))
                    modeTimes[item]++;
                else
                    modeTimes[item] = 1;
            }

            int maxCount = modeTimes.Values.Max();
            List<float> modes = modeTimes.Where(x => x.Value == maxCount)
                                         .Select(x => x.Key)
                                         .ToList();

            return modes;
        }

        public void GetCentralTendencedy(Dictionary<string,float> centralTendency)
        {
            foreach(var pair in centralTendency)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }

}
