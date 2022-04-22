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
                    if (value.FakeWeight < orderedWeights[j].FakeWeight)
                    {
                        orderedWeights[j + 1] = orderedWeights[j];
                    }
                    else if (value.FakeWeight == orderedWeights[j].FakeWeight)
                    {
                        if (value.weight == orderedWeights[j].weight)
                        {
                            break;
                        }



                        //if something like 123 and 1234000
                        else if (value.weight.Length != orderedWeights[j].weight.Length)
                        {
                            int count = 0;
                            bool swap = false;
                            //Check to see if there's in char differences between the digits to the length of lowest number
                            while(count < value.weight.Length && count < orderedWeights[j].weight.Length && swap ==false)
                            {
                                if (value.weight[count] < orderedWeights[j].weight[count])
                                {
                                    orderedWeights[j + 1] = orderedWeights[j];
                                    swap = true;
                                }
                                else
                                {
                                    count++;
                                }
                            }
                            //if theres no difference the make sure larger digit is in front of value
                            if (!swap)
                            {
                                if (int.Parse(value.weight) < int.Parse(orderedWeights[j].weight))
                                {
                                    orderedWeights[j + 1] = orderedWeights[j];
                                }
                            }

                            //Lengths are equal and string are NOT the same and we need to check out place values indivdually
                            else
                            {
                                //we pick one of the lengths, doensn't matter because they're the same
                                for(int k = 0; i < value.weight.Length; k++)
                                {
                                    if(value.weight[k] < orderedWeights[j].weight[k])
                                    {
                                        orderedWeights[j + 1] = orderedWeights[j];
                                        break;
                                    }
                                    
                                }
                            }

                        }
                    }
                    else
                    {
                        break;
                    }
                }
                orderedWeights[j + 1] = value;

            }


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