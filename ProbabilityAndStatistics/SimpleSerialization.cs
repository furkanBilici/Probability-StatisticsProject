﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class SimpleSerialization
    { 
        float tinniest ;
        List<float> Serialized = new List<float>();
        public List<float> SimpleSerializer(List<float> NonSerialized)
        {
           
            while (NonSerialized.Count()>0)
            {
                tinniest = NonSerialized.Min();
                NonSerialized.Remove(tinniest);
                Serialized.Add(tinniest);
            }
            GetSerializedList();
            return Serialized;
        } 
        void GetSerializedList()
        {
            Console.WriteLine("Simple Series: " + string.Join(" & ", Serialized));
        }
    }
}
