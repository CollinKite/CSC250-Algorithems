using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 TODO
• Exact Matches
    - Use method to find matching values for keys and sort them into a exact matches dictionary and return it, we don't have to deal with non-isomorphs because we already find those from finding the Loose Isomorphs.

• Loose Matches
    -F̶i̶n̶d̶ ̶c̶o̶u̶n̶t̶ ̶f̶o̶r̶ ̶r̶e̶p̶e̶a̶t̶i̶n̶g̶ ̶i̶n̶d̶e̶x̶s̶/̶f̶o̶r̶ ̶e̶a̶c̶h̶ ̶t̶i̶m̶e̶ ̶a̶ ̶l̶e̶t̶t̶e̶r̶ ̶r̶e̶-̶a̶p̶p̶e̶a̶rs -> FindCountInArraySorted();
    ex. egg -> 0 1 1 | 1 2: e appears once, g appears twice - we skip over any characters that already have been picked. 
    - t̶h̶e̶n̶ ̶n̶e̶e̶d̶ ̶t̶o̶ ̶o̶u̶t̶p̶u̶t̶ ̶i̶n̶ ̶N̶u̶m̶e̶r̶i̶c̶ ̶O̶r̶d̶e̶r -> FindCountInArraySorted();
    ex. 
    Index:  look : 0 1 1 2 
    Count: 1 2 1 : look - Solution is we loop through the list and compare the current number to all number and return a count, if the letter has been counted we don't count it again. -> FindCountInArray()
    Order Count: 1 1 2: look = our Loose Mapping - Solution is to take the list we get from the FindCountInArray and then use the .sort method to put it in Numeric Order which gets returned.

    then use method  to find all matching key pairs and put that into a Loose dictionary or Non-isomorphic Dictionary and return both Dictionaries as a Tuple -  https://stackoverflow.com/questions/748062/return-multiple-values-to-a-method-caller

• Output
    - FileName: Output.txt
    - Get List of Exact Matchs, Loose Matches, and nonmatches and Convert Them all to Strings and Concatnate Appropriately and output to console and output file
    
 */

namespace IsomorphicStrings
{
    class Controller
    {
        private string path;
        public void Run()
        {
            List<string> words = GetFile();
            Dictionary<string, int[]> indexedWords = IndexWords(words);
            Output(indexedWords);
        }

        //Prints Results and outputs it to Text File in Input file's directory
        private void Output(Dictionary<string, int[]> indexedWords)
        {
            Dictionary<string, int[]> ExactIso = FindExactIsomorphs(indexedWords);
            (Dictionary<string, int[]>, List<string>) looseAndNonIso = FindLooseIsomorphs(indexedWords);
            string output = "Exact Isomorphs\n" + StrDictionary(ExactIso) + "Loose Isomorphs\n" + StrDictionary(looseAndNonIso.Item1) + "Non-Isomorphs\n";
            for (int i = 0; i < looseAndNonIso.Item2.Count; i++)
            {
                output += looseAndNonIso.Item2[i] + "\n";
            }
            Console.WriteLine(output);
            string rootPath = path.Substring(0, path.LastIndexOf('\\'));
            try
            {
                File.WriteAllText(rootPath + "/output.txt", output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't Write Output.txt to the Directory of your input file. Error: " + ex);
            }

        }

        //Asks for File Path and returns String List of all words from list
        private List<string> GetFile()
        {
            while (true)
            {
                Console.WriteLine("Please Input The File Path");
                this.path = Console.ReadLine();
                //path = "C:\\Classes\\Q3\\CSC250\\IsomorphInput1.txt";
                if (path.Length > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Path Cannot Be Empty");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    string[] file = File.ReadAllLines(path);
                    List<string> words = file.ToList();
                    if (words.Count < 1)
                    {
                        Console.WriteLine("Can't Find isomorphics with 1 word, Please import a text list with 2 or more words");
                        Environment.Exit(0); //Exit Program
                    }
                    return words;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Couldn't Read File From Directory, Please Check your Directory and Try Again.\n Error: " + ex);
                    Console.WriteLine("\nPlease Input The File Path");
                    this.path = Console.ReadLine();
                    continue;
                }

            }


        }

        //Pass through list of Words, Iterates over all words and their characters and indexs them by trying to add each letter to a dictionary and if it already exists it increases the key pair int by 1.
        private Dictionary<string, int[]> IndexWords(List<string> words)
        {
            Dictionary<string, int[]> IndexedWords = new();

            for (int i = 0; i < words.Count; i++)
            {
                List<char> index = new(); //Used to store letters for each word temporily to keep track of letters already used. Gets overwritten on for each word.
                int[] characterIndexs = new int[words[i].Length];
                int count = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    char letter = words[i][j];
                    if (!index.Contains(letter))
                    {
                        index.Add(letter);
                        characterIndexs[j] = count;
                        count++;
                    }
                    else
                    {
                        characterIndexs[j] = index.IndexOf(letter);
                        index.Append(letter);
                    }
                }
                IndexedWords.Add(words[i], characterIndexs); //Once Done With Indexed Word add it to the Dictionary with index
            }
            return IndexedWords;
        }

        private string StrDictionary(Dictionary<string, int[]> dictionary)
        {
            string output = "";
            for (int i = 0; i < dictionary.Count; i++)
            {
                output += /*converts int array to string - */String.Join(" ", (dictionary.ElementAt(i).Value)) + ": " + dictionary.ElementAt(i).Key + " " + "\n";
            }
            return output;
        }

        //CTRL + K + C to Multiline Comment
        //CTRL + K + U to Multiline Uncomment
        private Dictionary<string, int[]> FindExactIsomorphs(Dictionary<string, int[]> indexedDictionary)
        {
            List<int> IndexsMatched = new();
            Dictionary<string, int[]> MatchingArrays = new();
            for (int source = 0; source < indexedDictionary.Count; source++)
            {
                bool matched = false;
                string output = indexedDictionary.ElementAt(source).Key;
                for (int target = 0; target < indexedDictionary.Count; target++)
                {
                    if (indexedDictionary.ElementAt(source).Value.SequenceEqual(indexedDictionary.ElementAt(target).Value) && indexedDictionary.ElementAt(source).Key != indexedDictionary.ElementAt(target).Key && IndexsMatched.Contains(target) == false)
                    {
                        matched = true;
                        output += " " + indexedDictionary.ElementAt(target).Key;
                        IndexsMatched.Add(target);
                    }
                }
                if (matched)
                {
                    IndexsMatched.Add(source);
                    MatchingArrays.Add(output, indexedDictionary.ElementAt(source).Value);
                }
            }
            return MatchingArrays;
        }

        //passes through Dictionary and Find Loose Isomorphs and pairs them together
        private (Dictionary<string, int[]>, List<string>) FindLooseIsomorphs(Dictionary<string, int[]> indexedDictionary)
        {
            Dictionary<string, int[]> MatchingArrays = new();
            List<string> nonIsomorphs = new();
            List<int> IndexsMatched = new();
            for (int source = 0; source < indexedDictionary.Count; source++)
            {
                bool matched = false;
                string output = indexedDictionary.ElementAt(source).Key;
                for (int target = 0; target < indexedDictionary.Count; target++)
                {
                    if (FindCountInArraySorted(indexedDictionary.ElementAt(source).Value).SequenceEqual(FindCountInArraySorted(indexedDictionary.ElementAt(target).Value)) && indexedDictionary.ElementAt(source).Key != indexedDictionary.ElementAt(target).Key && IndexsMatched.Contains(target) == false)
                    {
                        matched = true;
                        output += " " + indexedDictionary.ElementAt(target).Key;
                        IndexsMatched.Add(target);
                    }
                }
                if (matched)
                {
                    IndexsMatched.Add(source);
                    MatchingArrays.Add(output, FindCountInArraySorted(indexedDictionary.ElementAt(source).Value));
                }
                else if (!IndexsMatched.Contains(source))
                {
                    IndexsMatched.Add(source);
                    nonIsomorphs.Add(indexedDictionary.ElementAt(source).Key);
                }
            }
            return (MatchingArrays, nonIsomorphs);
        }

        //I could speed up this method by removing the matching indexs after we have used them so the array we compare against a smaller array everytime we get matches. No time implement this right now though.
        private int[] FindCountInArraySorted(int[] IndexForString)
        {
            List<int> wordCounts = new();
            List<int> alreadyUsed = new();
            for (int source = 0; source < IndexForString.Length; source++)
            {
                int count = 0;
                for (int target = 0; target < IndexForString.Length; target++)
                {
                    if (IndexForString[source] == IndexForString[target] && !alreadyUsed.Contains(IndexForString[source]))
                    {
                        count++;
                    }
                }
                alreadyUsed.Add(IndexForString[source]);
                if (count > 0) //don't wanna return chracters we've already compared
                {
                    wordCounts.Add(count);
                }
            }
            wordCounts.Sort(); //Sorts List in Numeric Order
            return wordCounts.ToArray(); //Converts List to Array to keep our formatting Redundant for our Dictionary's.
        }
    }
}