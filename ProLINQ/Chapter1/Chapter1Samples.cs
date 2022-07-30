using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Collections;

namespace ProLINQ.Chapter1
{
    public class Chapter1Samples
    {
        public static void RunSample1()
        {
            string[] greetings = { "hello world", "hello LINQ", "hello Apress" };

            var items =
                from s in greetings
                where s.EndsWith("LINQ")
                select s;

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void RunSample2()
        {
            XElement books = XElement.Parse(
                @"<books>
                    <book>
                        <title>Pro LINQ: Language Integrated Query in C# 2010</title>
                        <author>Joe Ratts</author>
                    </book>
                    <book>
                        <title>Pro .NET 4.0 Parallel Programming in C#</title>
                        <author>Adam Freeman</author>
                    </book>
                    <book>
                        <title>Pro VB 2010 and the .NET 4.0 Platform</title>
                        <author>Andrew Troelsen</author>
                    </book>
                    </books>");
            var titles =
                from book in books.Elements("book")
                where (string)book.Element("author") == "Joe Ratts"
                select book.Element("title");

            foreach (var title in titles)
                Console.WriteLine(title.Value);
        }

        public static void RunSample3()
        {
            string[] numbers = { "0042", "010", "9", "27" };
            int[] nums = numbers.Select(s => Convert.ToInt32(s)).OrderBy(s => s).ToArray();
            foreach (var n in nums) Console.WriteLine(n);
        }

        public static void RunSample4()
        {
            ArrayList alEmployees = Employee.GetEmployees();

            Contact[] contacts = alEmployees.Cast<Employee>().Select(e => new Contact()
            {
                Id = e.id,
                Name = string.Format("{0} {1}", e.firstName, e.lastName)
            }).ToArray();

            Contact.PublishContacts(contacts);
        }

        public static void RunSample5()
        {
            ArrayList al = new ArrayList();
            al.Add("asd");
            al.Add("bsd");
            al.Add("csd");
            al.Add(new object());

            var sample2 = al.OfType<string>().ToList();
            var sample = al.Cast<string>().ToList();
        }

        public static void RunSample6()
        {
            string[] strings = { "one", "two", null, "three" };
            Console.WriteLine("Before Where() is called.");
            IEnumerable<string> ieStrings = strings.Where(s => s.Length == 3);
            Console.WriteLine("Aftere Where() is called");

            foreach (string s in ieStrings)
            {
                Console.WriteLine("Processing " + s);
            }
        }

        class Employee
        {
            public int id;
            public string firstName;
            public string lastName;

            public static ArrayList GetEmployees()
            {
                ArrayList al = new ArrayList();
                al.Add(new Employee() { id = 1, firstName = "Joe", lastName = "Rattz" });
                al.Add(new Employee() { id = 2, firstName = "William", lastName = "Gates" });
                al.Add(new Employee() { id = 3, firstName = "Anders", lastName = "Heljsberg" });

                return al;
            }
        }

        class Contact
        {
            public int Id;
            public string Name;

            public static void PublishContacts(Contact[] contacts)
            {
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Contact Id: {0} Contact: {1}", c.Id, c.Name);
                }
            }
        }

    }
}

    
