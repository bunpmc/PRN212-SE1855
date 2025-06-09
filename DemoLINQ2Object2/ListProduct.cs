using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2Object2
{
    public  class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }
        public void gen_products()
        {
            products.Add(new Product() { Id = 1, Name = "P1", Quantity = 10, Price = 21 });
            products.Add(new Product() { Id = 2, Name = "P2", Quantity = 11, Price = 20 });
            products.Add(new Product() { Id = 3, Name = "P3", Quantity = 12, Price = 19 });
            products.Add(new Product() { Id = 4, Name = "P4", Quantity = 13, Price = 18 });
            products.Add(new Product() { Id = 5, Name = "P5", Quantity = 14, Price = 17 });
            products.Add(new Product() { Id = 6, Name = "P6", Quantity = 15, Price = 16 });
            products.Add(new Product() { Id = 7, Name = "P7", Quantity = 16, Price = 15 });
            products.Add(new Product() { Id = 8, Name = "P8", Quantity = 17, Price = 14 });
            products.Add(new Product() { Id = 9, Name = "P9", Quantity = 18, Price = 13 });
            products.Add(new Product() { Id = 10, Name = "P10", Quantity = 19, Price = 12 });
            products.Add(new Product() { Id = 11, Name = "P11", Quantity = 20, Price = 11 });
        }
        public List<Product> FilterProductsByPrice(double price1, double price2)
        {
            return products
                    .Where(p => p.Price=>price1 && p.Price <= price2)
                    .ToList();
        }
        public List<Product> FilterProductsByPrice2(double price1, double price2)
        {
            var results = from p in products
                          where p.Price <= price1 && p.Price <= price2
                          select p;
            return results.ToList();
        }
        public List<Product> SortProductByPriceDesc()
        {
            return products
                    .OrderByDescending(p => p.Price)
                    .ToList();
        }
        public List<Product> SortProductByPriceDesc()
        {
            var results = from p in products
                          orderby p.Price descending
                          select p;
            return results.ToList();
        }
        public int SumOfValue()
        {
            return products.Sum(p => p.Quantity * p.Price);
        }
    }
}
