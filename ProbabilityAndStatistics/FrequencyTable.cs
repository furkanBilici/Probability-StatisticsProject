using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProbabilityAndStatistics
{
    internal class FrequencyTable
    {
        public List<List<float>> FrequencyTableMaker(List<float> dataOrigin)
        {
            List<List<float>> frequencyList = new List<List<float>>();
            List<float> data = new List<float>(dataOrigin);
            int n=data.Count;
            var R=data.Max()-data.Min();
            int k=(int)Math.Ceiling(Math.Sqrt(n));
            int h = (int)Math.Ceiling(R / k);

            frequencyList.Add(ClassLowerLimitCalculator(data.Min(), k, h));//0
            frequencyList.Add(ClassUpperLimitCalculator(data.Min(), k, h));//1

            frequencyList.Add(ClassLowerBorderCalculator(data.Min(), k, h));//2
            frequencyList.Add(ClassUpperBorderCalculator(data.Min(), k, h));//3

            frequencyList.Add(ClassFrequencys(data, frequencyList));//4

            frequencyList.Add(ClassMidPointCalculator(frequencyList));//5

            frequencyList.Add(AdditiveFrequency(frequencyList));//6

            frequencyList.Add(ProportionalFrequency(frequencyList,n));//7

            return frequencyList;
        }
        List<float> ClassCalculator(float Data, int k, int h)
        {
            List<float> Limit = new List<float>();
            for (int i = 1; i < k; i++)
            {
                Data += h;
                Limit.Add(Data);
            }
            return Limit;
        }
        List<float> ClassLowerLimitCalculator(float lowerData, int k, int h)
        {
            List<float> lowerLimit = new List<float>();
            lowerLimit=ClassCalculator(lowerData, k, h);
            return lowerLimit;
        }
        List<float> ClassUpperLimitCalculator(float lowerData, int k,int h)
        {
            List<float> upperLimit = new List<float>();
            var upperData = lowerData + h;
            upperData--;
            upperLimit=ClassCalculator(upperData, k,h);
            return upperLimit;
        }
        List<float> ClassLowerBorderCalculator(float data, int k,int h)
        {
            List<float> lowerBorder = new List<float>();
            data = (data + data - 1) / 2;
            lowerBorder=ClassCalculator(data, k, h);    
            return lowerBorder;
        }
        List<float> ClassUpperBorderCalculator(float data, int k, int h)
        {
            List<float> upperBorder = new List<float>();
            data = data + h;
            data = (data + data - 1) / 2;
            upperBorder = ClassCalculator(data, k, h);
            return upperBorder;
        }
        List<float> ClassFrequencys(List<float> data,List<List<float>> frequency)
        {
            List<float> lower = new List<float>(frequency[0]);  
            List<float> upper = new List<float>(frequency[1]);
            List<float> classFrequency = new List<float>();
            int count=0;
            for(int i = 0; i < upper.Count(); i++)
            {
                foreach(float item in data)
                {
                    if (lower[i] <= item && item <= upper[i])
                    {
                        count++;
                    } 
                }
                if (count > 0)
                {
                    classFrequency.Add(count);
                }
                count = 0;
            }
            return classFrequency;
        }
        List<float> ClassMidPointCalculator(List<List<float>> frequency)
        {
            List<float> lower=new List<float>(frequency[0]);
            List<float> upper=new List<float>(frequency[1]);
            List<float> classMid = new List<float>();
            float data;

            for(int i = 0; i < upper.Count(); i++)
            {
                data = (upper[i] + lower[i])/2;
                classMid.Add(data); 
            }
            return classMid;
        }
        List<float> AdditiveFrequency(List<List<float>> frequency)
        {
            List<float> classFrequency= new List<float>(frequency[4]);
            List<float> additive =new List<float>();
            float count = 0;
            foreach(float frequencyItem in classFrequency)
            {
                count += frequencyItem;
                additive.Add(count);
            }   
            return additive;
        }
        List<float> ProportionalFrequency(List<List<float>> frequency, int n)
        {
            List<float> classFrequency = new List<float>(frequency[4]);
            List<float> proportional = new List<float>();
            float data;
            foreach(float frequencyItem in classFrequency)
            {
                data = frequencyItem/n;
                proportional.Add(data); 
            }
            return proportional;
        }

        public void GetFrequencyTable(List<List<float>> frequency)
        {
            
            string[] headers = {
                "Sınıf Alt Limiti", "Sınıf Üst Limiti", "Sınıf Alt Sınır", "Sınıf Üst Sınır",
                "Frekans", "Sınıf Ortası", "Birikimli Frekans", "Oransal Frekans"
            };

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");

            // Başlıkları yazdır
            foreach (string header in headers)
            {
                Console.Write($"{header,-18}");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");

            if (frequency == null || frequency.Count == 0)
            {
                Console.WriteLine("Frekans tablosu boş!");
                return;
            }

            int rowCount = frequency.Min(f => f.Count);  // En kısa listenin uzunluğu

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < frequency.Count; j++)
                {
                    Console.Write($"{frequency[j][i],-18:F2}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
        }

    }
}
