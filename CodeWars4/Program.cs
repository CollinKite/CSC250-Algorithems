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

            //insert sort practice!!!
            for (int i = 1; i < orderedWeights.Count; i++)
            {
                int j = 0;
                Weight value = orderedWeights[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (orderedWeights[i].FakeWeight < orderedWeights[j].FakeWeight)
                    {
                        orderedWeights[i] = orderedWeights[j];
                    }
                    else
                    {
                        break;
                    }
                }
                orderedWeights[j] = value;

            }


            // Create String from sorted values
            string Sorted = "";
            for (int i = 0; i < orderedWeights.Count; i++)
            {
                Sorted += (orderedWeights[i].weight + " ");
            }
            return Sorted;
        }
    }

    public class Weight
    {
       public int weight;
       public int FakeWeight;

        public Weight(string weight)
        {
            this.weight = int.Parse(weight);
            this.FakeWeight = GetFakeWeight(weight);
        }


        private static int GetFakeWeight(string weight)
        {
            List<char> weightNumbers = (weight.ToArray()).ToList();
            int fake = 0;
            for(int i = 0; i < weightNumbers.Count; i++)
            {
                fake += int.Parse(weightNumbers[i].ToString());
            }
            return fake;
        }
    }
}