using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using Repositories_EF;

namespace Services_EF
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }
        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return productRepository.GetProductByCategoryId(categoryId);
        }

        public List<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public bool DeleteProduct(int productId)
        {
            return productRepository.DeleteProduct(productId);
        }
        public bool SaveProduct(Product product)
        {
            return productRepository.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
    }
}
