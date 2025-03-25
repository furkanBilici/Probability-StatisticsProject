using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityAndStatistics
{
    internal class MeasuresOfVariability
    {
        MeasuresOfCentralTendencedy mofct=new MeasuresOfCentralTendencedy();    
        public Dictionary<string,double> MeasureVarialibty(List<float> listOg)
        {
            List<float> list = new List<float>(listOg);
            Dictionary<string, double> mofv = new Dictionary<string, double>();
            float variance = Variance(list);
            float standartDeviation = StandartDeviation(variance);
            float iqr = InterquartileRange(list);
            float cv=CoefficientOfVariation(list);
            float harmonical=HarmonicalMean(list);
            double geometrical=GeometricalMean(list);

            mofv.Add("Variance", variance);
            mofv.Add("Standart Deviation", standartDeviation);
            mofv.Add("Interquartile Range",iqr);
            mofv.Add("Coefficient of Variation", cv);
            mofv.Add("Harmonical Mean", harmonical);
            mofv.Add("Geometrical Mean", geometrical);
            return mofv;    
        }
        float Variance(List<float>list,bool isSample=false)
        {
            float mean = list.Sum() / list.Count;
            float variance = list.Sum(x => (x - mean) * (x - mean)) / (isSample ? list.Count - 1 : list.Count);
            return variance;
        }
        float StandartDeviation(float variance)
        {
            return MathF.Sqrt(variance);    
        }
        float InterquartileRange(List<float> list)
        {
            list.Sort();

            int mid = list.Count / 2;


            List<float> lowerHalf = list.Take(mid).ToList();
            List<float> upperHalf = list.Skip(mid + (list.Count % 2 == 0 ? 0 : 1)).ToList();

            float q1 = mofct.Median(lowerHalf);
            float q3 = mofct.Median(upperHalf);

 
            return q3 - q1;
        }


        float CoefficientOfVariation(List<float>list)
        {
            float mean = list.Sum() / list.Count;
            if (mean == 0) return float.NaN; 
            float stdDev = StandartDeviation(Variance(list));
            return (stdDev / mean) * 100;
        }
        double GeometricalMean(List<float>numbers)
        {
            double product = 1.0;
            foreach (var number in numbers)
            {
                product *= number;
            }

            return Math.Pow(product, 1.0 / numbers.Count);
        }
        float HarmonicalMean(List<float>numbers)
        {
            float sumOfInverses = 0.0f;

            foreach (var number in numbers)
            {
                sumOfInverses += 1.0f / number;
            }

            return numbers.Count / sumOfInverses;
        }
        

        public void GetMofv(Dictionary<string, double> dict) 
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
