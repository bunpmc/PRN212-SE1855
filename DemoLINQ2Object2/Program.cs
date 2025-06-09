using System.Text;
using DemoLINQ2Object2;

Console.OutputEncoding = Encoding.UTF8;

ListProduct lp = new ListProduct();
lp.gen_products();
//C1: filter products with prices from a to b
//using method syntax and query syntax
var result1 = lp.FilterProductsByPrice(200, 300);
Console.WriteLine("Danh sách sản phẩm có giá từ 200 đến 300");
result1.ForEach(x => Console.WriteLine(x));

//C2: Order products descendingly by price
//using query syntax
var result2 = lp.SortProductByPriceDesc();
Console.WriteLine("List products after descending sort by price");
result2.ForEach(x => Console.WriteLine(x));

//C3: Calculate the sum of the products in the storage
Console.WriteLine("Sum: " + lp.SumOfValue());