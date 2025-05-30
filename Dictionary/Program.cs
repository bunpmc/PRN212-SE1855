using Dictionary;

Console.OutputEncoding =  System.Text.Encoding.UTF8;

Category c1 = new Category()
{
    Id = 1,
    Name = "Nuoc ngot",

};

Product p1 = new Product()
{
    Id = 1,
    Name = "Coca",
    Quantity = 10,
    Price = 15,
};

c1.AddProduct(p1);

Product p2 = new Product()
{
    Id = 2,
    Name = "Pepsi",
    Quantity = 30,
    Price = 15,
};
c1.AddProduct(p2);


Product p3 = new Product()
{
    Id = 3,
    Name = "Sting",
    Quantity = 4,
    Price = 20,
};
c1.AddProduct(p3);


Product p4 = new Product()
{
    Id = 4,
    Name = "Redbull",
    Quantity = 30,
    Price = 5,
};
c1.AddProduct(p4);


Product p5 = new Product()
{
    Id = 5,
    Name = "Aquafina Soda",
    Quantity = 10,
    Price = 16,
};

c1.AddProduct(p5);

Console.WriteLine("=========Toan bo danh sach sp cua Nuoc Ngot============");
c1.PrintAllProducts();

Dictionary<int, Product> filters = c1.FilterProductsByPrice(10, 20);
foreach (KeyValuePair<int, Product> kvp in filters)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Console.WriteLine("=========Toan bo danh sach sp Complex sort cua Nuoc Ngot============");
Dictionary<int, Product> complexFilters = c1.ComplexSort();
foreach (KeyValuePair<int, Product> kvp in complexFilters)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p1.Name = "Xa Xi";
p1.Price = 10;
p1.Quantity = 50;

c1.UpdateProduct(p1);
Console.WriteLine("========San pham sau khi chinh sua========");
c1.PrintAllProducts();

Console.WriteLine("========Toan dah sach san pham sau khi xoa product========");
c1.RemoveProduct(p4);
c1.PrintAllProducts();

Category c2 = new Category()
{
    Id = 2,
    Name = "Bia",
};

c2.AddProduct(new Product()
{
    Id = 6,
    Name = "333",
    Quantity = 2,
    Price = 10,
});

c2.AddProduct(new Product()
{
    Id = 7,
    Name = "Ken",
    Quantity = 2,
    Price = 10,
});

c2.AddProduct(new Product()
{
    Id = 8,
    Name = "Tiger",
    Quantity = 9,
    Price = 11,
});

LinkedList<Category> list = new LinkedList<Category>();
list.AddLast(c2);
list.AddLast(c1);

Console.WriteLine("======Toan bo du lieu======");
foreach (Category c in list)
{
    Console.WriteLine(c.Name);
    Console.WriteLine();
    c.PrintAllProducts();
    Console.WriteLine("----------------");
}
