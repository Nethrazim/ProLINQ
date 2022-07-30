using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProLINQ.Chapter1
{
    internal class Chapter1Samples2
    {
        public static void RunSample1()
        {
            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };
            IEnumerable<char> methodSyntax = nameList.SelectMany(x => x);

            foreach (char c in methodSyntax)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();

            List<List<int>> intList = new List<List<int>>() { new List<int>() { 1, 2, 3 }, new List<int>() { 3, 4, 5 } };
            foreach (int i in intList.SelectMany(x => x)) Console.Write(i + " ");
        }
    }
}
