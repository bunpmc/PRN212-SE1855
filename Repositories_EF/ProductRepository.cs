using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using DataAccessLayer_EF;

namespace Repositories_EF
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO pd = new ProductDAO();
        public List<Product> GetProducts()
        {
            return pd.GetProducts();
        }
        public bool SaveProduct(Product product)
        {
            return pd.SaveProduct(product);
        }
        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return pd.GetProductByCategoryId((int)categoryId);
        }
        public bool UpdateProduct(Product product)
        {
            return pd.UpdateProduct(product);
        }
        public bool DeleteProduct(int productId)
        {
            return pd.DeleteProduct(productId);
        }
    }
}
