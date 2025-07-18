using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace Services_EF
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public bool SaveProduct(Product product);
        public List<Product> GetProductByCategoryId(int categoryId);
        public bool DeleteProduct(int productId);
        public bool UpdateProduct(Product product);
    }
}
