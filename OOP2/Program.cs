using OOP2;

Console.OutputEncoding = System.Text.Encoding.UTF8;

FulltimeEmployee obama = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Barack Obama",
    Birthday = new DateTime(1960, 11,25),

};

Console.WriteLine("=====Thong tin cua Obama=========");
Console.WriteLine($"{obama.Id}");
Console.WriteLine($"{obama.Name}");
Console.WriteLine($"{obama.IdCard}");
Console.WriteLine($"{obama.Birthday.ToString("dd/mm/yyyy")}");
Console.WriteLine($"Luong: {obama.calSalary()}");

PartimeEmployee trump = new PartimeEmployee()
{
    Id = 2,
    IdCard = "124",
    Name = "Donald Trump",
    Birthday = new DateTime(1959, 11, 27),
    WorkingHour = 3,
};


Console.WriteLine("=====Thong tin cua Trump=========");
Console.WriteLine($"{trump.Id}");
Console.WriteLine($"{trump.Name}");
Console.WriteLine($"{trump.IdCard}");
Console.WriteLine($"{trump.Birthday.ToString("dd/mm/yyyy")}");
Console.WriteLine($"Luong: {trump.calSalary()}");

Console.WriteLine("=======Using toString()=========");
Console.WriteLine(trump.ToString());
Console.WriteLine(obama.ToString());