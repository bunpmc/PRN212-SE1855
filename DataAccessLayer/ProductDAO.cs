using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        
        public void GenerateSampleDataset()
        {
            products.Add(new Product() { Id = 1, Name = "Soda", Quantity= 2, Price=9}) ;
            products.Add(new Product() { Id = 2, Name = "Aquafina", Quantity = 23, Price = 3 });
            products.Add(new Product() { Id = 3, Name = "Fanta", Quantity = 6, Price = 20 });
            products.Add(new Product() { Id = 4, Name = "Pepsi", Quantity = 3, Price = 9 });
            products.Add(new Product() { Id = 5, Name = "Coca", Quantity = 1, Price = 94});
        }
        public List<Product> GetProducts() {
            return products;
        }

        public bool SaveProduct(Product product) { 
            Product old = products.FirstOrDefault(p => p.Id ==  product.Id);

            if (old!=null)
            {
                return false;
            }

            products.Add(product);

            return true;
        }
    }
}
