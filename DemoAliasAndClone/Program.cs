using DemoAliasAndClone;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Student s1 = new Student()
{
    Id = 1,
    Name = "A"
};

Student s2 = new Student()
{
    Id = 2,
    Name = "B"
};

//Luc nay tren thanh RAM se cap phat 2 o nho
//Cho s1 & s2 quan ly
//=> s1 doi gia tri khong lien quan den s2 
//vi s1 va s2 quan ly 2 o nho khac nhau

s1 = s2;
//Ta viet lenh: s1 = s2 
//Tuy nhien ve ban chat no hoat dong nhu sau
//s1 tro toi vung nho ma s2 dang quan ly chu khong phai s1 = s2

//Co 2 tinh huong xay ra:
//(1) o nho ben s2 gio co them s1 quan ly => alias (>= 2 doi tuong quan ly)
//    chi can 1 doi tuong bi doi, cac doi tuong khac cung bi doi

s2.Name = "Nguyen Thi Lung Linh";
Console.WriteLine("s2 doi ten thi s1 co ten la gi: ");
Console.WriteLine(s1.Name);

s1.Name = "Tran Van B";
Console.WriteLine("s1 doi ten thi s2 co ten la gi: ");
Console.WriteLine(s2.Name);

//(2) o nho luc truoc cua s1 dang quan ly, gio khong con doi tuong quan ly
// => luc nay He dieu hanh tu hieu va thu hoi: Automatic Garbage Collection
// tuc la ta khong the truy suat de lay lai gia tri s1 co id = 1, name "A"

Product p1 = new Product()
{
    Id = 1,
    Name = "P1",
    Quantity = 12,
    Price = 20
};

Product p2 = new Product()
{
    Id = 2,
    Name = "P2",
    Quantity = 5,
    Price = 45
};

p1 = p2;

p2.Name = "Dogshit";
p2.Price = 80;

Console.WriteLine("P1 info");
Console.WriteLine(p1);

Product p3 = new Product()
{
    Id = 3,
    Name = "P3",
    Quantity = 15,
    Price = 39
};

Product p4 = new Product()
{
    Id = 4,
    Name = "P4",
    Quantity = 55,
    Price = 58
};

Product p5 = p3;
p3 = p4;
//Hỏi ô nhớ cấp phát cho p3 có bị thu hồi ko? why?

Product p6 = p4.clone();
// sao chép toàn bộ data ô nhớ mà p4 quản lí
//sang ô nhớ mới và giao cho p6 quản lí
//lúc này ko phỉa là ALIAS vì p4 và p6 quản lí 2 ô nhớ khác nhau
Console.WriteLine("Data of p6");
Console.WriteLine(p6);
Console.WriteLine("Data of p4");
Console.WriteLine(p4);

p4.Name = 'dogfuck';
Console.WriteLine("Data of p6");
Console.WriteLine(p6);
Console.WriteLine("Data of p4");
Console.WriteLine(p4);
