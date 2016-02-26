using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLibiraryCS
{
    class Program
    {
        public static Dictionary<string, Dictionary<string, double>> Critics = new Dictionary<string, Dictionary<string, double>>
        {
            {
                "Eissa",
                new Dictionary<string,double>
                {
                    {"Lady in the Water",2.5},
                    {"Snakes on a Plane",3.5},
                    {"Just My Luck",3.0},
                    {"Superman Returns",3.5},
                    {"You, Me and Dupree",2.5},
                    {"The Night Listener",3.0}
                }
            },
            {
                "Atef",
                new Dictionary<string,double>
                {
                    {"Lady in the Water",3.0},
                    {"Snakes on a Plane",3.5},
                    {"Just My Luck",1.5},
                    {"Superman Returns",5.0},
                    {"The Night Listener",3.0},
                    {"You, Me and Dupree",3.5}
                }
            },
            {
                "Hassan",
                new Dictionary<string,double>
                {
                    {"Lady in the Water",2.5},
                    {"Snakes on a Plane",3.0},
                    {"Superman Returns",3.5},
                    {"The Night Listener",4.0}
                }
            },
            {
                "Abdo",
                new Dictionary<string,double>
                {
                    {"Snakes on a Plane",3.5},
                    {"Just My Luck",3.0},
                    {"The Night Listener",4.5},
                    {"Superman Returns",4.0},
                    {"You, Me and Dupree",2.5}                    
                }
            },
            {
                "Soly",
                new Dictionary<string,double>
                {
                    {"Lady in the Water",3.0},
                    {"Snakes on a Plane",4.0},
                    {"Just My Luck",2.0},
                    {"Superman Returns",3.0},
                    {"The Night Listener",3.0},
                    {"You, Me and Dupree",2.0}
                }
            },
            {
                "Sleem",
                new Dictionary<string,double>
                {
                    {"Lady in the Water",3.0},
                    {"Snakes on a Plane",4.0},
                    {"The Night Listener",3.0},
                    {"Superman Returns",5.0},
                    {"You, Me and Dupree",3.5}
                }
            },
            {
                "Gaber",
                new Dictionary<string,double>
                {
                    {"Snakes on a Plane",4.5},
                    {"You, Me and Dupree",1.0},
                    {"Superman Returns",4.0}
                }
            }
        };



        static void Main(string[] args)
        {
            Utilities u = new Utilities();

            //test the euqlidean distance
            double distanceSimilarity = u.Sim_distance(Critics, "Eissa", "Atef");
            Console.WriteLine("distance similarity:");
            Console.WriteLine(distanceSimilarity);

            //test the pearson correlation
            double personSimilarity = u.Sim_Pearson(Critics, "Eissa", "Atef");
            Console.WriteLine("Pearson:");
            Console.WriteLine(personSimilarity);

            //test the n topMatches function using eqlidan distance
            var topMatches1 = u.topMatches(Critics, "Gaber", u.Sim_distance, 5);
            Console.WriteLine("the top 5 mtches to Gaber and using eqlidean: ");
            foreach (var user in topMatches1)
            {
                Console.WriteLine(user.Key + " : " + user.Value);
            }

            //test the n topMatches function using pearson correlation
            var topMatches2 = u.topMatches(Critics, "Gaber", u.Sim_Pearson, 5);
            Console.WriteLine("the top 5 mtches to Gaber and using Pearson correlation: ");
            foreach (var user in topMatches2)
            {
                Console.WriteLine(user.Key + " : " + user.Value);
            }


            //dddddddddddddddd
            var getRecommendations1 = u.getRecommendations(Critics, "Gaber", u.Sim_Pearson);
            var gerRecommendations2 = u.getRecommendations(Critics, "Gaber", u.Sim_distance);

            Console.WriteLine("recommendations using weighted average and distance similarity(euqlidean)");
            foreach (var item in getRecommendations1)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            //Console.WriteLine("recommendations using weighted average and pearson correlation similarity");
            ////foreach (var item in gerRecommendations2)
            ////{
            //    Console.WriteLine(getRecommendations1);
            ////}

            var ttt = u.TransformData(Critics);
            Console.Read();
        }
    }
}
