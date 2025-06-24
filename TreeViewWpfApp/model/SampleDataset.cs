using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.model
{
    public class SampleDataset
    {
        public static Dictionary<int, Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category c1 = new Category() { Id = 1, Name = "Nuoc Ngot"};
            Category c2 = new Category() { Id = 2, Name = "Bia ruou" };
            Category c3 = new Category() { Id = 3, Name = "Thuc an nhanh" };

            categories.Add(c1.Id, c1);
            categories.Add(c2.Id, c2);
            categories.Add(c3.Id, c3);

            Product p1 = new Product() { Id = 1, Name = "Coca", Quantity = 2, Price = 67 };
            Product p2 = new Product() { Id = 2, Name = "Sting", Quantity = 2, Price = 54 };
            Product p3 = new Product() { Id = 3, Name = "Sprite", Quantity = 2, Price = 40 };
            Product p4 = new Product() { Id = 4, Name = "Tiger", Quantity = 2, Price = 30 };
            Product p5 = new Product() { Id = 5, Name = "Ha Noi", Quantity = 2, Price = 120 };
            Product p6 = new Product() { Id = 6, Name = "Sai Gon", Quantity = 2, Price = 10 };
            Product p7 = new Product() { Id = 7, Name = "Bia Viet", Quantity = 2, Price = 1 };
            Product p8 = new Product() { Id = 8, Name = "Bia Duc", Quantity = 2, Price = 5 };
            Product p9 = new Product() { Id = 9, Name = "Nuoc Cam", Quantity = 2, Price = 18 };
            Product p10 = new Product() { Id = 10, Name = "Chanh day", Quantity = 2, Price = 9 };
            Product p11 = new Product() { Id = 11, Name = "Snack", Quantity = 2, Price = 20 };
            Product p12 = new Product() { Id = 12, Name = "Bimbim", Quantity = 2, Price = 25 };
            Product p13 = new Product() { Id = 13, Name = "Khoai nuong", Quantity = 2, Price = 27 };
            Product p14 = new Product() { Id = 14, Name = "Hanh la", Quantity = 2, Price = 50 };
            Product p15 = new Product() { Id = 15, Name = "Mi tom", Quantity = 2, Price = 80 };

            c1.Products.Add(p1.Id, p1);
            c1.Products.Add(p2.Id, p2);
            c1.Products.Add(p3.Id, p3);
            c1.Products.Add(p4.Id, p4);
            c1.Products.Add(p5.Id, p5);

            c2.Products.Add(p6.Id, p6);
            c2.Products.Add(p7.Id, p7);
            c2.Products.Add(p8.Id, p8);
            c2.Products.Add(p9.Id, p9);
            c2.Products.Add(p10.Id, p10);

            c3.Products.Add(p11.Id, p11);
            c3.Products.Add(p12.Id, p12);
            c3.Products.Add(p13.Id, p13);
            c3.Products.Add(p14.Id, p14);
            c3.Products.Add(p15.Id, p15);

            return categories;
        }
    }
}
