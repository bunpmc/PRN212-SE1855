using OOP1;

Console.OutputEncoding =  System.Text.Encoding.UTF8;

//Tao 1 doi tuong danh muc
Category c1 = new Category();
//Gan gia tri cho cac thuoc tinh
c1.Id = 1;
c1.Name = "Nuoc mam";

c1.PrintInfor();

//Khoi tao 1 nhan vien
Employee employee = new Employee();
employee.Id = 1;
employee.Id_Card = "00123";
employee.Name = "A";
employee.Email = "a@gmail.com";
employee.Phone = "098765456789";

employee.PrintInfor();

//Truy xuat tung Property lay gia tri cua tung thuoc tinh
Console.WriteLine("----------------");
Console.WriteLine($"ID: {employee.Id}");
Console.WriteLine($"Name: {employee.Name}");

//Ta cung co the khoi tao doi tuong va cac gia tri cua thuoc tinh nhu sau.
Employee employee2 = new Employee()
{
    Id = 2,
    Id_Card = "0667",
    Name = "B",
    Email = "b@gmail.com",
    Phone = "093456789",
};

employee2.PrintInfor();

Console.WriteLine("-------------------");
Employee emplpyee3 = new Employee(3, "0988", "D", "d@gmail.com", "09876543456");
emplpyee3.PrintInfor();
//hoac tu dong goi toString()
Console.WriteLine(emplpyee3);

//thu dung contructor mac dinh khong doi so
Employee employee4 = new Employee(); 
Console.WriteLine(employee4);


Customer customer = new Customer()
{
    Id = "1",
    Name = "A",
    Address = "B",
    Email = "7890@gmail.com",
    Phone = "34567890-"
};

customer.PrintInfor();
