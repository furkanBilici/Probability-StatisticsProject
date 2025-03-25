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
        public Dictionary<string,float> MeasureVarialibty(List<float> listOg)
        {
            List<float> list = new List<float>(listOg);
            Dictionary<string, float> mofv = new Dictionary<string, float>();
            float variance = Variance(list);
            float standartDeviation = StandartDeviation(variance);
            float iqr = InterquartileRange(list);
            float cv=CoefficientOfVariation(list);

            mofv.Add("Variance", variance);
            mofv.Add("Standart Deviation", standartDeviation);
            mofv.Add("Interquartile Range",iqr);
            mofv.Add("Coefficient of Variation", cv);
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
        float InterquartileRange(List<float>list)
        {
            float iqr;
            int mid = list.Count / 2; // Ortanca için index belirleme
            List<float> lowerHalf = list.Take(mid).ToList();
            List<float> upperHalf = list.Skip((list.Count % 2 == 0) ? mid : mid + 1).ToList();
            float q1 = mofct.Median(lowerHalf);
            float q3 = mofct.Median(upperHalf);
            iqr = q3 - q1;
            return iqr;
        }
        float CoefficientOfVariation(List<float>list)
        {
            float mean = list.Sum() / list.Count;
            if (mean == 0) return float.NaN; // Hata önleme
            float stdDev = StandartDeviation(Variance(list));
            return (stdDev / mean) * 100;
        }

        public void GetMofv(Dictionary<string, float> dict) 
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
