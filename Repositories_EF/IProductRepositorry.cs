using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace Repositories_EF
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public bool SaveProduct(Product product);
        public List<Product> GetProductByCategoryId(int categoryId);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int productId);
    }
}
