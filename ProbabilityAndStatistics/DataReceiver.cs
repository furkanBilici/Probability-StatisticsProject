using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProbabilityAndStatistics
{
    internal class DataReceiver
    {
        public bool can=true;

        SimpleSerialization simpleSerializer=new SimpleSerialization();
        FrequencySeries frequencySeries=new FrequencySeries();
        SimpleRandomSampling simpleRandomSampling=new SimpleRandomSampling();
        SystematicRandomSampling systematicRandomSampling=new SystematicRandomSampling();  
        FrequencyTable frequencyTable=new FrequencyTable(); 

        public List<float> floatList = new List<float>();
        public void SetData()
        {
            List<string> Data=new List<string>();
            Console.WriteLine("Please enter the values('q' for quit)");
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
            Console.WriteLine("Float list: " + string.Join(" & ", floatList));
        }
   
        void ConvertToFloatList(List<string> Data)
        {
            foreach (var item in Data)
            {
                if (float.TryParse(item, out float number))
                {
                    floatList.Add(number);
                }
            }
            if (floatList.Count <= 0) { can = false; }
            floatList=simpleSerializer.SimpleSerializer(floatList);
        }

        public void SimpleSerialize()
        {
           simpleSerializer.GetSerializedList(simpleSerializer.SimpleSerializer(floatList));
        }
        public void FrequencySeries()
        {
            frequencySeries.GetFrequency(frequencySeries.Frequency(floatList));
        }
        public void SetSimpleRandomSampling()
        {
            Console.WriteLine("\nPlease give the min value");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Please give the max value");
            int max = int.Parse(Console.ReadLine());

            Console.WriteLine("Please give the count of the random values");
            int count = int.Parse(Console.ReadLine());

            simpleRandomSampling.GetList(simpleRandomSampling.RandomSampling(min, max, count));
        }
        public void SystematicRandomSampling()
        {
            Console.WriteLine("Please enter the sample count: ");
            int sampleCount=int.Parse(Console.ReadLine());
            systematicRandomSampling.GetSRSList(systematicRandomSampling.SystematicRandom(floatList.Count(), sampleCount));
        }
        public void FrequencyTable()
        {
            frequencyTable.GetFrequencyTable(frequencyTable.FrequencyTableMaker(floatList));
        }

    }
}
