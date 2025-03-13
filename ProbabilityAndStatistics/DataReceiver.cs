﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProbabilityAndStatistics
{
    internal class DataReceiver
    {
        SimpleSerialization simpleSerializer=new SimpleSerialization();
        FrequencySeries frequencySeries=new FrequencySeries();
         
        public List<float> floatList = new List<float>();
        public void SetData()
        {
            List<string> Data=new List<string>();
            Console.WriteLine("Verileri girin(çıkış için q'yazın)");
            while (true)
            {  
                string data = Console.ReadLine();
                if (data == "q")
                    break;
                Data.Add(data);
            }
           
            ConvertToFloatList(Data);
        }
        public void GetData()
        {
            Console.WriteLine("Dönüştürülen float listesi: " + string.Join(" & ", floatList));
        }
   
        void ConvertToFloatList(List<string> Data)
        {
            foreach (var item in Data)
            {
                if (float.TryParse(item, out float number))
                {
                    floatList.Add(number);
                }
                else
                {
                    Console.WriteLine($"Geçersiz giriş atlandı: {item}");
                }
            }
            floatList=simpleSerializer.SimpleSerializer(floatList);
        }

        public void SimpleSerialize()
        {
            simpleSerializer.SimpleSerializer(floatList);
        }
        public void FrequencySeries()
        {
            frequencySeries.Frequency(floatList);
        }
    }
}
