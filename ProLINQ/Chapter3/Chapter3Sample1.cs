using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProLINQ.Chapter3
{
    internal class Chapter3Sample1
    {
        public static void Run1()
        {
            int[] ints = new int[] { 1, 2, 3 };
            Func<int, bool> GreaterThanTwo = i => i > 2;
            IEnumerable<int> intsGreaterThanTwo = ints.Where(GreaterThanTwo);
            foreach(int i in intsGreaterThanTwo) Console.WriteLine(i);
        }

        public static void Run2()
        {
            int[] nums = new int[] { 1, 2, 3, 4 }; 
            IEnumerable<int> oddNumbers = (from n in nums
                                           where n % 2 == 1
                                           select n).Reverse();

            foreach(var i in oddNumbers) Console.WriteLine(i);  
        }
    }
}
