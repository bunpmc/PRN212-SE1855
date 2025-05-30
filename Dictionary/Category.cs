using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }

        public Category ()
        {
            Products = new Dictionary<int, Product> ();
        }
        /*
         * Moi du lieu phai lam du: CRUD
         */

        public void AddProduct(Product p)
        {
            if (Products.ContainsKey(p.Id))
            {
                return;
            }
            Products[p.Id] = p;
        }

        //Xuat toan bo du lieu
        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> item in Products)
            {
                Product p = item.Value;
                Console.WriteLine(p.ToString());
            }
        }
        //Loc ra cac san pham co gia tu x toi y
        public Dictionary<int, Product> FilterProductsByPrice (double min, double max )
        {
            Dictionary<int, Product> results = new Dictionary<int, Product>();
            results = Products.Where(item => item.Value.Price >= min &&  
                        item.Value.Price <= max).ToDictionary<int, Product>();

            return results;
        }
        //Sap xep san pham theo thang gia tang dan
        public Dictionary<int, Product > SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price).ToDictionary<int, Product>();
        }
        /*
         * Hay sap xep san pham theo don gia tang dan
         * neu don gia trung nhau thi sap xep theo so luong giam dan
         */
        public Dictionary<int, Product> ComplexSort ()
        {
            return Products.OrderBy(item => item.Value.Price)
                .OrderByDescending(item => item.Value.Quantity).ToDictionary<int, Product>();
        }
        
        public bool UpdateProduct(Product product)
        {
            if (product == null) return false;
            if (!Products.ContainsKey(product.Id)) 
            {
                return false;
            }

            Products[product.Id] = product; // de du lieu len o nho hien tai || tham chieu o nho khac
            return true;
        }

        public bool RemoveProduct(Product product)
        {
            if (product == null) return false;
            if (!Products.ContainsKey(product.Id)) return false;
            Products.Remove(product.Id);
            return true;
        }
    }
}
