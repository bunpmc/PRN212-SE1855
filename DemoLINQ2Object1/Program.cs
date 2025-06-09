using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = { 22, 13, 56, 2, 4, 3, 2, 5, 10, 1, 6, 2, 5, 34 };

/* 
 * Filter all even numbers
 */
//Method 1: Using Extention Method- Method Syntax
var ar_chan = arr.Where(x => x % 2 == 0);
Console.WriteLine("Even numbers using Method Syntax: ");
ar_chan.ToList().ForEach(x => Console.WriteLine(x));

//Method 2: Using Query Syntax
var ar_chan2 = from x in arr
               where x % 2 == 0
               select x;
Console.WriteLine("Even numbers using Query Syntax: ");
ar_chan2.ToList().ForEach(x => Console.WriteLine(x));

/*
 *  Increase +2 for all odd numbers 
*/
var arr2 = arr.Where(x => x % 2 != 0)
             .Select(x => x + 2);
Console.WriteLine("Original Data:");
foreach (var x in arr)
{
    Console.WriteLine(x + "\t");
}
Console.WriteLine("Data after increasing +2 for all odds:");
foreach (var x in arr2)
{
    Console.WriteLine(x + "\t");
}

/*
 * Order by ascending
*/
var arr4 = arr.OrderBy(x => x);
var arr5 = from x in arr
           orderby x
           select x;
Console.WriteLine("After ascending order by:");
foreach(var item in arr5)
{
    Console.WriteLine(item + "\t");
}

/*
 * Order by descending
*/
var arr6 = arr.OrderByDescending(x => x);
var arr7 = from x in arr
           orderby x descending
           select x;

/*
 * Count odds numbers
*/
Console.WriteLine("Số lẻ là =" + arr.Where(x => x % 2 != 0).Count());
int sole = (from x in arr
            where x % 2 != 0
            select x).Count();
Console.WriteLine("Odds = " + sole);