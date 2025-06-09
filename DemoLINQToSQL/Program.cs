using System.Text;
using DemoLINQToSQL;

Console.OutputEncoding = Encoding.UTF8;

string connectionString = @"server=MINHCHAU\DBI202;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);

//Cau 1: Truy van toan bo danh muc
var dsdm = context.Categories.ToList();
Console.WriteLine("Danh sach danh muc: ");
dsdm.ForEach(x =>  Console.WriteLine(x.CategoryID + "\t" + x.CategoryName));

//Cau 2: Dung query syntax de loc ra toan bo san pham 
var dssp = from p in context.Products
           select p;
Console.WriteLine("danh sach san pham");
foreach (var product in dssp)
{
    Console.WriteLine(product.ProductID + "\t" + product.ProductName);
}

//Cau 3: Tim danh muc khi biet ma danh muc
int mdm = 3;
Category cate = context.Categories.FirstOrDefault(x => x.CategoryID == mdm);
if(cate ==null)
{
    Console.WriteLine("Khong tim thay danh muc co ma");
} else
{
    Console.WriteLine("Da tim thay danh muc co ma");
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}
//Cau 4: Loc ra top 3 san pham co gia tri lon nhat 
var dssp_top3 = context.Products
    .OrderByDescending(x => x.UnitPrice)
    .Take(3)
    .ToList();
foreach (var p in dssp_top3)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName);
}

//Cau 5: Them moi mot danh muc
//Category c1 = new Category();
//c1.CategoryName = "Hang dien tu hahaha"; //=> Loi vuot ky tu cho phep 
//context.Categories.InsertOnSubmit(c1);
//context.SubmitChanges();

//Cau ^6: sua thuoc tinh
//Buoc 1: tim danh muc
//Buoc 2: sua thuoc tinh

Category c13 = context.Categories.FirstOrDefault(x => x.CategoryID == 13);
if (c13 != null)
{
    c13.CategoryName = "Hang gia dung";
    context.SubmitChanges();
    Console.WriteLine("Da sua thanh cong danh muc co ma 13");
}
else
{
    Console.WriteLine("Khong tim thay danh muc co ma 13");
}

//Cau 7: Xoa danh muc khi biet ma danh muc
Category c12 = context.Categories.FirstOrDefault(x => x.CategoryID == 12);
if(c12 != null)
{
    context.Categories.DeleteOnSubmit(c12);
    context.SubmitChanges();
    Console.WriteLine("Da xoa thanh cong danh muc co ma 12");
}
else
{
    Console.WriteLine("Khong tim thay danh muc co ma 12");
}

//Cau 8: Xoa tat ca danh muc chua co bat ky san pham nao
var dssp_empty_product = context.Categories
    .Where(x => x.Products.Count() ==0)
    .ToList();
context.Categories.DeleteAllOnSubmit(dssp_empty_product);
context.SubmitChanges();

//Cau 9: Them nhieu danh muc cung mot luc
List<Category> newCategories = new List<Category>
{
    new Category { CategoryName = "Hang thoi trang" },
    new Category { CategoryName = "Hang hoa chat" },
    new Category { CategoryName = "Hang dien tu" }
};
context.Categories.InsertAllOnSubmit(newCategories);
context.SubmitChanges();