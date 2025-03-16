using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class SimpleSerialization
    { 
        
        public List<float> SimpleSerializer(List<float> NonSerialized)
        {
            float tinniest ;
            List<float> Serialized = new List<float>();
            while (NonSerialized.Count()>0)
            {
                tinniest = NonSerialized.Min();
                NonSerialized.Remove(tinniest);
                Serialized.Add(tinniest);
            }
            return Serialized;
        } 
        public void GetSerializedList(List<float> Serialized)
        {
            Console.WriteLine("Simple Series: " + string.Join(" & ", Serialized));
        }
    }
}
