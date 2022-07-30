using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProLINQ.Chapter2
{
    static class Ext
    {
        public static int ExtMethod1(this string s, int i)
        {
            return int.Parse(s) + i;
        }

        public static void ExtMethod2() { }
    }

    public partial class MyWidget
    {
        partial void MyWidgetStart(int count);
        partial void MyWidgetEnd(int count);

        public MyWidget()
        {
            int count = 0;
            MyWidgetStart(++count);
            Console.WriteLine("In the constructor of MyWidget.");
            MyWidgetEnd(++count);
            Console.WriteLine(" count == " + count);
        }
    }

    public partial class MyWidget
    {
        partial void MyWidgetStart(int count)
        {
            Console.WriteLine("In MyWidgetStart(count is {0})", count);
        }

        partial void MyWidgetEnd(int count)
        {
            Console.WriteLine("In MyWidgetEnd(count is {0})", count);
        }
    }



    internal class Chapter2Sample1
    {

        public static void Run3()
        {
            MyWidget myW = new MyWidget();
        }
        public static void Run1()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] oddNums = Common.FilterArrayOfInts(nums, Application.IsOdd);

            foreach(int i in oddNums)
                Console.WriteLine(i);

            int[] oddNums2 = Common.FilterArrayOfInts(nums, delegate (int i) { return ((i & 1) == 1); });
            int[] oddNums3 = Common.FilterArrayOfInts(nums, i => ((i & 1) == 1));
        }

        public static void Run2()
        {
            var mySpouse = new { FirstName = "Vickey", LastName = "Rattz" };
            //var miau = i => i;
            IEnumerable<Common> addresses = new List<Common>() { new Common(), new Common() }.Where(x => x != null).Select(c => new Common());//lol
            var a = new Common();
            var b = new { address = "105 Elm Street", city = "Atlanta", state = "GA"};
            Console.WriteLine(b.GetType());
        }
    }

    public class Common
    {
        public delegate bool IntFilter(int i);

        public static int[] FilterArrayOfInts(int[] ints, IntFilter filter)
        {
            ArrayList aList = new ArrayList();
            foreach (int i in ints)
            {
                if (filter(i))
                {
                    aList.Add(i);
                }
            }
            return ((int[])aList.ToArray(typeof(int)));
        }
    }

    public class Application
    {
        public static bool IsOdd(int i)
        {
            return ((i & 1) == 1);
        }
    }
}

