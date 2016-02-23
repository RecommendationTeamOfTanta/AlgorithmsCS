using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLibiraryCS
{
    public class Utilities
    {
        //Returns a distance-based similarity score for person1 and person2
        public double Sim_distance(Dictionary<string, Dictionary<string, double>> data, string person1, string person2)
        {
            double sum_of_squares = 0;

            //loop through person1's films
            foreach (var item in data[person1])
            {
                //the list of common items between person1 and person2
                Dictionary<string, int> si = new Dictionary<string, int>();

                if (data[person2].ContainsKey(item.Key))
                {
                    si.Add(item.Key, 1); // if found set it's value to 1

                    //Add up the squares of all the differences
                    sum_of_squares += Math.Pow(item.Value - (data[person2].Where(x => x.Key == item.Key).FirstOrDefault().Value), 2);
                }

                // if they have no ratings in common, return 0
                if (si.Count() == 0)
                    return 0;

            }
            return 1 / (1 + sum_of_squares);
        }
    }
}
