using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStuff
{
    class Help
    {
        public static class ExtensionMethods
        {
            public static string PrintLetterWords(this LetterWords lw)
            {
                return lw.Letter + ": Words = " + String.Join(", ", lw.Words);
            }
        }

        public class LetterWords
        {
            public string Letter { get; set; }

            public List<string> Words { get; set; } = new List<string>();

        }

        public class HelperStuff
        {

            public static void Go()
            {
                //DebugMe();
                Helpers();


                string path = \\input.txt;
                string[] words = File.ReadAllLines(path);
                string rootPath = path.Substring(0, path.LastIndexOf('\\'));

                List<string> myLines = new List<string>();
                string[] result = myLines.ToArray();
                string[] lines = new string[10];
                lines[0] = "some content \r\n";
                lines[1] += "next line content";

                File.WriteAllLines(rootPath + "/output.txt", lines);
            }


            public static void Helpers()
            {
                LetterWords lw1 = new LetterWords();
                lw1.Letter = "A";
                lw1.Words.Add("Apple");
                lw1.Words.Add("Algorithm");

                LetterWords lw2 = new LetterWords();
                lw2.Letter = "G";
                lw2.Words.Add("Grandma");
                lw2.Words.Add("Gas");

                List<LetterWords> myLetters = new List<LetterWords>();
                myLetters.Add(lw2);
                myLetters.Add(lw1);


                LetterWords lw3 = new LetterWords();
                lw3.Letter = "J";
                lw3.Words.Add("Jam");

                List<LetterWords> myLetters2 = new List<LetterWords>();
                myLetters2.Add(lw3);

                myLetters.AddRange(myLetters2);

                //myLetters.Sort();

                myLetters = myLetters.OrderBy(l => l.Letter).ToList();
                myLetters = myLetters.OrderByDescending(l => l.Letter).ToList();

                myLetters.Add(new LetterWords() { Letter = "D", Words = new List<string>() { "Dog" } });
                myLetters.Add(new LetterWords() { Letter = "D", Words = new List<string>() { "Dog" } });

                myLetters = myLetters.Distinct().OrderBy(l => l.Letter).ThenBy(l => l.Letter).ToList();

                LetterWords found = myLetters.FirstOrDefault(word => word.Letter == "E");
                //if not found
                if (found == null) { }

                //ObjectArray with property and combines them across all objects into an array
                List<string> myLett = myLetters.Select(word => word.Letter).ToList();

                //ObjectArray with list /collection and combines them across all objects into one
                List<string> allWords = myLetters.SelectMany(word => word.Words).ToList();

                Console.WriteLine(lw2.PrintLetterWords());

                int i = 0;


                for (int p = 0, j = 20; p < allWords.Count && j > 0; p++, j--)
                {

                }

                Dictionary<string, int> myLetterss = new Dictionary<string, int>();

                myLetterss.Add("A", 1);

                KeyValuePair<string, int> letter = myLetterss.FirstOrDefault(l => l.Key == "A");
                myLetterss["A"] = 2;

                if (myLetterss.ContainsKey("A"))
                {
                    myLetterss["A"] = myLetterss["A"] + 1;
                }

                foreach (KeyValuePair<string, int> kvp in myLetterss)
                {
                    //kvp.Value
                    //kvp.Key
                }

                myLetterss.Where(s => s.Key == "A")
                    .ToDictionary(k => k.Key, v => v.Value);

            }

            public static void DebugMe()
            {
                int glueCrewCount = 0;

                List<int> myNumbers = new List<int> { 1, 2, 4, 6 };

                for (int i = 0; i < myNumbers.Count; i++)
                {
                    Console.WriteLine(myNumbers[i]);
                }

                int result = SubMethod(glueCrewCount);
                Console.WriteLine("Result: " + result);
            }

            private static int SubMethod(int value)
            {
                return value * 2;
            }
        }
    }
}
