using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 TODO
• Exact Matches
    - Come up with Way to merge matching pairs from multiple keys into one key pair to get Exact Matchesj

• Loose Matches
    -Find count for repeating indexs/for each time a letter re-appears 
    ex. egg -> 0 1 1 | 1 2: e appears once, g appears twice - we skip over any characters that already have been picked. 
then need to output in Numeric Order
ex. 
    Index:  look : 0 1 1 2 
    Count: 1 2 1 : look
    Order Count: 1 1 2: look = our Loose Mapping

• Output
    - FileName: Output.txt
    - Print Results to Console
    - Get List of Exact Matchs, Loose Matches, and nonmatches and Convert Them all to Strings and Concatnate Appropriately
    for (i = 0; i<list.Count; i++{
    
 */

namespace IsomorphicStrings
{
    class Controller
    {
        //List of Word Class which contains the Word, it's Indexes, boolean values for Isomorphic 
        //List<string> allWords = myLetters.SelectMany(Word => Word, Letter).ToList();
        public void Run()
        {
            List<string> words = GetFile();
            Dictionary<string, int[]> indexedWords = IndexWords(words);
            for (int i = 0; i < indexedWords.Count; i++)
            {
                Console.WriteLine(indexedWords.ElementAt(i).Key + " " + /*converts int array to string - */String.Join(" ", indexedWords.ElementAt(i).Value));
            }
            //FindIsomorphs(indexedWords);



        }

        //Asks for File Path and returns String List of all words from list
        private List<string> GetFile()
        {
            string path;
            while (true)
            {
                Console.WriteLine("Please Input The File Path");
                //path = Console.ReadLine();
                path = "C:\\Classes\\Q3\\CSC250\\IsomorphInput1.txt";
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
            string[] file = File.ReadAllLines(path);
            List<string> words = file.ToList();
            return words;
        }

        //Iterates over all words and their characters and indexs them by trying to add each letter to a dictionary and if it already exists it increases the key pair int by 1.
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
                IndexedWords.Add(words[i], characterIndexs);
            }
            return IndexedWords;
        }


        //CTRL + K + C to Multiline Comment
        //CTRL + K + U to Multiline Uncomment
        private /*List<Word>*/ void FindIsomorphs(Dictionary<string, int[]> indexedDictionary)
        {
            if (indexedDictionary.Count < 1)
            {
                Console.WriteLine("Can't Find isomorphics with under 2 words, Please import a text list with 2 or more words");

            }
            else
            {
                Dictionary<string, int[]> matchingKeys = new();
                for (int i = 0; i < indexedDictionary.Count ; i++)
                {

                }
            }
        }
    }
}


public class Word
{
    public Word(string word, int[] index, bool loose, bool exact)
    {
        this.wordStr = word;
        this.index = index;
        this.loose = loose;
        this.exact = exact;
        if (loose || exact)
        {
            nonIsomorhic = false;
        }
        else
        {
            nonIsomorhic = true;
        }
    }
    public int[] index;
    public string wordStr;
    public bool loose = false;
    public bool exact = false;
    public bool nonIsomorhic;
}
