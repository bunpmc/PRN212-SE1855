using OOP2;
using OOP2_REUSE_LIBRARY;

Console.OutputEncoding =  System.Text.Encoding.UTF8;

FulltimeEmployee e1 = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Teo",
    Birthday = new DateTime(2011, 12,12 ),
};

Console.WriteLine($"{e1.Id}");
Console.WriteLine($"{e1.Name}");
Console.WriteLine($"{e1.IdCard}");
Console.WriteLine($"{e1.Birthday.ToString("dd/mm/yyyy")}");
Console.WriteLine($"Luong: {e1.calSalary()}");
Console.WriteLine($"{e1.TinhTuoi}");

