﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();
        public void GenerateSampleDataset()
        {
            productDAO.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return productDAO.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return productDAO.SaveProduct(product);
        }
        public bool UpdateProduct(Product product)
        {
            return productDAO.UpdateProduct(product);
        }

        public bool DeleteProduct(Product product)
        {
            return productDAO.DeleteProduct(product);
        }
    }
}
