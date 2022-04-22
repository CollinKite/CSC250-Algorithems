using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars4
{
    public class WeightSort
    {
        public static void Main()
        {

        }

        public static string orderWeight(string strng)
        {
            List<Weight> orderedWeights = new List<Weight>();
            List<String> weights = strng.Split(' ').ToList();
            for (int i = 0; i < weights.Count; i++)
            {
                orderedWeights.Add(new Weight(weights[i]));
            }

            //Order our objects by Fake weights unless they're equal we sort by string
            //Referenced by this - https://www.techiedelight.com/sort-list-of-objects-csharp/

            orderedWeights.Sort(delegate (Weight x, Weight y)
            {
                if (x.FakeWeight != y.FakeWeight)
                {
                    return x.FakeWeight.CompareTo(y.FakeWeight);
                }
                else
                {
                    return x.weight.CompareTo(y.weight);
                }
            });




            // Create String from sorted values
            string Sorted = "" + orderedWeights[0].weight;
            for (int i = 1; i < orderedWeights.Count; i++)
            {
                Sorted += (" " + orderedWeights[i].weight);
            }
            return Sorted;
        }
    }

    public class Weight
    {
        public string weight;
        public int FakeWeight; //Numbers added together

        //Constructor
        public Weight(string weight)
        {
            this.weight = weight;
            this.FakeWeight = GetFakeWeight(weight);
        }


        private static int GetFakeWeight(string weight)
        {
            //Converts String to list of chars
            List<char> weightNumbers = (weight.ToArray()).ToList();
            int fake = 0;
            for (int i = 0; i < weightNumbers.Count; i++)
            {
                //add the chars together
                fake += int.Parse(weightNumbers[i].ToString());
            }
            return fake;
        }
    }
}