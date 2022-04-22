using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class PhoneDir
    {

        public static void Main()
        {

        }
        public static string Phone(string strng, string num)
        {
            try
            {
                //Console.WriteLine(strng);
                List<Person> phonebook = findAllPeople(strng, num);
                List<int> matches = new List<int>();
                for (int i = 0; i < phonebook.Count; i++)
                {
                    if (phonebook[i].phoneNumber == num)
                    {
                        matches.Add(i);
                    }
                }
                if (matches.Count == 1)
                {
                    return phonebook[matches[0]].ToString();
                }
                else
                {
                    return "Error => Too many people: " + num;
                }
            }
            catch (Exception e)
            {
                return "Error => Not found: " + num;
            }
        }

        private static List<Person> findAllPeople(string phoneBook, string num)
        {
            //Get all the people that are in phoneBook and store them in a List of Strings
            string[] lines = phoneBook.Split('\n');
            List<Person> people = new List<Person>();
            for (int i = 0; i < lines.Length - 1; i++)
            {
                people.Add(new Person(lines[i]));

            }
            if (!people.Any(x => x.phoneNumber == num))
            {
                throw new Exception();
            }

            return people;
        }
    }


    public class Person
    {
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        override
            public string ToString()

        {
            //"Phone => 48-421-674-8974, Name => Anastasia, Address => Via Quirinal Roma"
            return "Phone => " + phoneNumber + ", " + "Name => " + name + ", " + "Address => " + address;
        }

        public Person(string Data)
        {
            (string, string, string) data = SetValues(Data);
            phoneNumber = data.Item1;
            name = data.Item2;
            address = data.Item3;
        }

        private static (string, string, string) SetValues(string Person)
        {
            // Regex for Phone Number
            Regex PhoneNumberPattern = new Regex(@"\d{1,2}-[0-9]{3}-[0-9]{3}-[0-9]{4}",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find Phone Number.
            MatchCollection PhoneMatches = PhoneNumberPattern.Matches(Person);
            string PhoneNumber = PhoneMatches[0].Value;
            //Remove Phone Number from Person
            Person = PhoneNumberPattern.Replace(Person, "");





            // Regex for Name
            Regex namePattern = new Regex(@"(?<=\<)(.*?)(?=\>)",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find Name.
            MatchCollection NameMatches = namePattern.Matches(Person);
            string name = NameMatches[0].Value;

            Person = namePattern.Replace(Person, "");

            string address = Regex.Replace(Person, "[/$!?*;:,+<>]+", "");
            address = Regex.Replace(address, "\\s{2,}|_", " ").Trim();



            return (PhoneNumber, name, address);
        }
    }
}

