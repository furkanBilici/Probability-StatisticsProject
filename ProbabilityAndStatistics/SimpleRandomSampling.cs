using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class SimpleRandomSampling
    {
        public List<int> RandomSampling(int down,int up, int count) 
        {
            List<int> simpleRandom = new List<int>();

            Random rnd = new Random();
            int value;
            while (simpleRandom.Count() < count)
            {
                value=rnd.Next(down,up);
                if (simpleRandom.Contains(value) && count<=(up-down))
                {
                    continue;
                }
                simpleRandom.Add(value);
            }
            return simpleRandom;
        }
        public void GetList(List<int> simpleRandom)
        {
            Console.WriteLine(string.Join(" & ", simpleRandom));
        }
    }
}
