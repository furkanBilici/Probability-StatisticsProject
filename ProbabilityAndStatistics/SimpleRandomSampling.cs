using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class SimpleRandomSampling
    {
        public List<int> simpleRandom = new List<int>();
        Random rnd = new Random();
        int value;
        public List<int> RandomSampling(int down,int up, int count) 
        {
            while (simpleRandom.Count() <= count)
            {
                value=rnd.Next(down,up);
                if (simpleRandom.Contains(value) && count>(up-down))
                {
                    continue;
                }
                simpleRandom.Add(value);
            }
            GetList();
            return simpleRandom;
        }
        void GetList()
        {
            Console.WriteLine("Simple Series: " + string.Join(" & ", simpleRandom));
        }
    }
}
