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
        public void Run1()
        {
            string[] presidents = {
                "Adams",
                "Arthur",
                "Buchanan",
                "Bush",
                "Carter",
                "Cleveland",
                "Clinton",
                "Coolidge",
                "Eisenhower",
                "Fillmore",
                "Ford",
                "Garfield",
                "Grant",
                "Harding",
                "Harrison",
                "Hayes",
                "Hoover",
                "Jackson",
            };

            IEnumerable<char> chars = presidents.SelectMany(p => p.ToArray());
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
        public void Run3()
        {
            
        }

        //am ramas la pagina 120
    }
}
