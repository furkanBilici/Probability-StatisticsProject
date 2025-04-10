using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class SimpleSerialization
    { 
        
        public List<float> SimpleSerializer(List<float> NonSerializedOrigin)
        {
            float tinniest ;
            List<float> NonSerialized = new List<float>(NonSerializedOrigin);

            List<float> Serialized = new List<float>();
            while (NonSerialized.Count()>0)
            {
                tinniest = NonSerialized.Min();
                Serialized.Add(tinniest);
                NonSerialized.Remove(tinniest);   
            }
            return Serialized;
        } 
        public void GetSerializedList(List<float> Serialized)
        {
            Console.WriteLine("Basit Seri: " + string.Join(" & ", Serialized));
        }
    }
}
