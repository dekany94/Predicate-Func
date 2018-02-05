using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate
{
    class Program
    {
		//Ref.: https://www.dotnetperls.com/predicate
		//https://msdn.microsoft.com/en-us/library/bfcke1bz(v=vs.110).aspx

		static void Main(string[] args)
        {
			Predicate<Int32> isOne = x => x == 1;
			Console.WriteLine(isOne.Invoke(1));

			Int32[] array = new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			Int32 valueToValidate = 3, lowerLimit = 1, upperLimit = 5;
			String format = "RangeValidator with Func.\nvalueToValidate: {0}\nlowerLimit: {1}\nupperLimit: {2}\nreturn: {3}";
			Console.WriteLine(format, valueToValidate, lowerLimit, upperLimit,
				predicate(valueToValidate, lowerLimit, upperLimit));



			Int32[] filtered = Array.FindAll(array, predicate2);
			Console.WriteLine("\n===================================\n");
			//Console.WriteLine("Syntax: T[] FindAll<T>(T[] array, Predicate<T> match");
			Console.WriteLine("Filtered with Array.FindAll: {0}", String.Join(',', filtered));
			Console.WriteLine("\n===================================\n");

			List<Int32> intList = new List<Int32>(array);
			var filteredWithLinqUsingPredicate = intList.Where(predicate3);
			//Console.WriteLine("Syntax: IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate");
			Console.WriteLine("Filtered with Linq using predicate: {0}", String.Join(",", filteredWithLinqUsingPredicate));

			Console.ReadKey();
        }

		static Func<Int32, Int32, Int32, bool> predicate = 
			(valueToValidate, lowerLimit, upperLimit) => (valueToValidate > lowerLimit && valueToValidate < upperLimit);

		static Predicate<Int32> predicate2 = (Int32 x) => x > 3 && x < 8;

		static Func<Int32, Boolean> predicate3 = x => x > 5;
	}
}
