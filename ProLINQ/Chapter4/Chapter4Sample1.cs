using ProLINQ.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProLINQ.Chapter4
{
    //public static IEnumerable<T> Where<T>(this IEnumerable<T> source,Func<T, bool> predicate);
    //public static IEnumerable<S> Select<T,S>(this IEnumerable<T> source, Func<T,S> selector); 
    //public static IEnumerable<S> Select<T,S>(this IEnumerable<T> source, Func<T,int,S> selector);
    //public static IEnumerable<S> SelectMany<T,S>(this IEnumerable<T> source, Funct<T, IEnumerable<S>> selector);
    internal class Chapter4Sample1
    {
        string[] presidents = {
            "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
            "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
            "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
            "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
            "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
            "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"
        };

        Employee[] employees = Employee.GetEmployeesArray();
        EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

        public void Run1()
        {
            IEnumerable<string> q1 = presidents.Where(x => x.StartsWith('H'));
            IEnumerable<char> chars = presidents.SelectMany(p => p.ToArray());
            IEnumerable<string> items = presidents.OrderBy(s => s.Length);
            IEnumerable<char> q2 = presidents.Select(s => s.FirstOrDefault());
        }

        public void Run2()
        {
            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

            var employeeOptions = employees.SelectMany(e => empOptions.Where(eo => eo.id == e.id).Select(eo => new { id = eo.id, optionsCount = eo.optionsCount }));
            foreach (var item in employeeOptions) Console.WriteLine(item);
        }

        //public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count);
        //public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Funct<T,bool> predicate);
        //public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count);
        //public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, Func<T,int,bool> predicate);
        //public static IEnumerable<T> Concat<T>(this IEnumerable<T> first, IEnumerable<T> second);
        //public static IOrderedEnumerable<T> OrderBY<T,K>(this IEnumerable<T> source, Func<T,K> keySelector) where K : IComparable<K>;
        //public static IOrderedEnumerable<T> OrderBY<T,K>(this IEnumerable<T> source, Func<T,K> keySelector, IComparer<K> comparer);
        //public static IEnumerable<V> GroupJoin<T, U, K, V>(this IEnumerable<T> outer,IEnumerable<U> inner,Func<T, K> outerKeySelector,Func<U, K> innerKeySelector,Func<T, IEnumerable<U>, V> resultSelector);
        //public static IEnumerable<IGrouping<K,T>> GroupBy<T,K>(this IEnumerable<T> source, Func<T,K> keySelector);
        //public static IEnumerable<T> Cast<T>(this IEnumerable source);
        public void Run3()
        {
            IEnumerable<string> q = presidents.Take(5);
            IEnumerable<string> q1 = presidents.TakeWhile(x => x.Length > 6);
            IEnumerable<string> q2 = presidents.Skip(5);
            IEnumerable<string> q3 = presidents.Concat(presidents.Skip(5).Take(5));
            IEnumerable<string> q4 = presidents.OrderBy(x => x);
            var employeeOptions = employees.Join(empOptions, e => e.id, o => o.id, (e, o) => new { id = e.id, name = string.Format("{0} {1}", e.firstName, e.lastName), options = o.optionsCount });
            var employeeOptions2 = employees.GroupJoin(empOptions, e => e.id, o => o.id, (e, os) => new { options = os.Sum(o => o.optionsCount) });
        }
    }
}
