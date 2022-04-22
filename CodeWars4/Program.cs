//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace CodeWars4
//{
//    public class WeightSort
//    {
//        public static void Main()
//        {

//        }

//        public static string orderWeight(string strng)
//        {
//            List<Weight> orderedWeights = new List<Weight>();
//            List<String> weights = strng.Split(' ').ToList();
//            for (int i = 0; i < weights.Count; i++)
//            {
//                orderedWeights.Add(new Weight(weights[i]));
//            }

//            //insert sort practice!!!
//            for (int i = 1; i < orderedWeights.Count; i++)
//            {
//                int j = 0;
//                Weight value = orderedWeights[i];
//                for (j = i - 1; j >= 0; j--)
//                {
//                    if (value.FakeWeight < orderedWeights[j].FakeWeight)
//                    {
//                        orderedWeights[j + 1] = orderedWeights[j];
//                    }
//                    else if (value.FakeWeight == orderedWeights[j].FakeWeight)
//                    {
//                        for()
//                    }
//                    else
//                    {
//                        break;
//                    }
//                }
//                orderedWeights[j + 1] = value;

//            }


//            // Create String from sorted values
//            string Sorted = "" + orderedWeights[0].weight;
//            for (int i = 1; i < orderedWeights.Count; i++)
//            {
//                Sorted += (" "+ orderedWeights[i].weight);
//            }
//            return Sorted;
//        }
//    }

//    public class Weight
//    {
//       public string weight;
//       public int FakeWeight;

//        public Weight(string weight)
//        {
//            this.weight = weight;
//            this.FakeWeight = GetFakeWeight(weight);
//        }
        

//        private static int GetFakeWeight(string weight)
//        {
//            List<char> weightNumbers = (weight.ToArray()).ToList();
//            int fake = 0;
//            for(int i = 0; i < weightNumbers.Count; i++)
//            {
//                fake += int.Parse(weightNumbers[i].ToString());
//            }
//            return fake;
//        }
//    }
//}