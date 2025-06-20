﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iproductRepository;

        public ProductService ()
        {
            iproductRepository = new ProductRepository ();
        }

        public void GenerateSampleDataset()
        {
           iproductRepository.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return iproductRepository.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return iproductRepository.SaveProduct(product);
        }
    }
}
