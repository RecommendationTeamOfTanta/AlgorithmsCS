using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLibiraryCS
{
    public class Utilities
    {
        // a distance-based similarity to measure similarity between person1 and person2 (euclidean distance)
        public double Sim_distance(Dictionary<string, Dictionary<string, double>> data, string person1, string person2)
        {
            double sum_of_squares = 0;

            //the list of common items between person1 and person2
            Dictionary<string, int> si = new Dictionary<string, int>();

            //loop through person1's films
            foreach (var item in data[person1])
            {
                if (data[person2].ContainsKey(item.Key))
                {
                    si.Add(item.Key, 1); // if found set it's value to 1

                    //Add up the squares of all the differences
                    sum_of_squares += Math.Pow(item.Value - (data[person2].Where(x => x.Key == item.Key).FirstOrDefault().Value), 2);
                }
            }

            // if they have no ratings in common, return 0
            if (si.Count() == 0)
                return 0;

            return 1 / (1 + sum_of_squares);
        }


        //Pearson correlation to measure similarity between person1 and person2
        public double Sim_Pearson(Dictionary<string, Dictionary<string, double>> data, string person1, string person2)
        {
            double sum1 = 0, sum2 = 0, sum1Sq = 0, sum2Sq = 0, pSum = 0, num = 0, den = 0,result=0;
            //the list of common items between person1 and person2
            Dictionary<string, int> si = new Dictionary<string, int>();

            //store the number of common films between person1 and person2
            int n = 0;

            double sum_of_squares = 0;

            //loop through person1's films
            foreach (var item in data[person1])
            {
                if (data[person2].ContainsKey(item.Key))
                {
                    si.Add(item.Key, 1); // if found set it's value to 1
                }
            }

            n = si.Count;
            // if they have no ratings in common, return 0
            if (n == 0)
                return 0;

            foreach (var item in si)
            {
                //Add up all the rates for person1 and person2
                sum1 += data[person1].Where(x => x.Key == item.Key).FirstOrDefault().Value;
                sum2 += data[person2].Where(x => x.Key == item.Key).FirstOrDefault().Value;

                //Sum up the squares
                sum1Sq += Math.Pow(data[person1].Where(x => x.Key == item.Key).FirstOrDefault().Value, 2);
                sum2Sq += Math.Pow(data[person2].Where(x => x.Key == item.Key).FirstOrDefault().Value, 2);

                // Sum up the products
                pSum += (data[person1].Where(x => x.Key == item.Key).FirstOrDefault().Value) *
                    (data[person2].Where(x => x.Key == item.Key).FirstOrDefault().Value);
            }

            //Calculate Pearson score
            num = pSum - (sum1 * sum2 / n);
            den = Math.Sqrt((sum1Sq - Math.Pow(sum1, 2) / n) * (sum2Sq - Math.Pow(sum2, 2) / n));

            // to avoid devide by zero error
            if (den == 0) return 0;

            result = num / den; 
            return result;
        }

    }
}
