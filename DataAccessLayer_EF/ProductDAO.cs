using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace DataAccessLayer_EF
{
    public class ProductDAO
    {
        MyStoreContext context = new MyStoreContext();

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProductByCategoryId(int categoryId) {
            return context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool SaveProduct(Product product)
        {
            if(product == null)
            {
                return false;
            }

            Product isExisting = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (isExisting == null)
            {
                context.Products.Add(product);
            }
            int ret = context.SaveChanges();
            return ret > 0;
        }
        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Product isExisting = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (isExisting != null)
            {
                isExisting.ProductName = product.ProductName;
                isExisting.UnitsInStock = product.UnitsInStock;
                isExisting.UnitPrice = product.UnitPrice;
                isExisting.CategoryId = product.CategoryId;
                context.Products.Update(isExisting);
            }
            int ret = context.SaveChanges();
            return ret > 0;
        }
        public bool DeleteProduct(int productId)
        {
            Product isExisting = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (isExisting != null)
            {
                context.Products.Remove(isExisting);
            }
            int ret = context.SaveChanges();
            return ret > 0;
        }
    }
}
