using System;
using System.Collections.Generic;
using System.Globalization;
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
        MeasuresOfCentralTendencedy centralTendencedy=new MeasuresOfCentralTendencedy();
        MeasuresOfVariability measuresOfVariability=new MeasuresOfVariability();
        PermutationAndCombination permutationAndCombination=new PermutationAndCombination();

        public List<float> floatList;
        public void SetData()
        {
            List<float> Data = new List<float>(); 
            Console.WriteLine("Please enter the values separated by commas (e.g., 1.5, 5.2, 2.6) and press Enter when done.");

            string data = Console.ReadLine();

            string[] dataArray = data.Split(',');

            foreach (string item in dataArray)
            {
                // Her öğeyi temizle (Trim) ve float'a çevir.
                if (float.TryParse(item.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
                {
                    Data.Add(value);
                }
                else
                {
                    Console.WriteLine($"Invalid input: {item} is not a valid number.");
                }
            }
            floatList = new List<float>(Data);
            floatList = simpleSerializer.SimpleSerializer(floatList);
        }
        public void GetData()
        {
            Console.WriteLine("Float list: " + string.Join(" & ", floatList));
        }
        public void SimpleSerialize()
        {
            List<float> data = new List<float>(floatList);
            simpleSerializer.GetSerializedList(simpleSerializer.SimpleSerializer(data));
        }
        public void FrequencySeries()
        {
            List<float> data = new List<float>(floatList);
            frequencySeries.GetFrequency(frequencySeries.Frequency(data));
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
            List<float> data = new List<float>(floatList);
            Console.WriteLine("Please enter the sample count: ");
            int sampleCount=int.Parse(Console.ReadLine());
            systematicRandomSampling.GetSRSList(systematicRandomSampling.SystematicRandom(data.Count(), sampleCount));
        }
        public void FrequencyTable()
        {
            List<float> data = new List<float>(floatList);
            frequencyTable.GetFrequencyTable(frequencyTable.FrequencyTableMaker(data));
        }
        public void MeasuresOfCentralTendencedy()
        {
            List<float> data = new List<float>(floatList);
            centralTendencedy.GetCentralTendencedy(centralTendencedy.MeasuresCentralT(data));
        }
        public void MeasuresOfVariability()
        {
            List<float> data = new List<float>(floatList);
            measuresOfVariability.GetMofv(measuresOfVariability.MeasureVarialibty(data));
        }
        public void PermutationAndCombination()
        {
            Console.WriteLine("Please give the n");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Please give the r");
            int r = int.Parse(Console.ReadLine());
            permutationAndCombination.GetPermutationAndCombination(permutationAndCombination.PermutationCombinationMeasurement(n,r));
        }

    }
}
