void ham1(int n)
{
    n = 8;
    Console.WriteLine($"n trong ham = {n}");
}

int n = 5;
Console.WriteLine($"n truoc khi vao ham = {n}");
ham1(n);
Console.WriteLine($"n sau khi vao ham = {n}");

void ham2(ref int  n )
{
    n = 8;
    Console.WriteLine($"n trong ham = {n}");
}

Console.WriteLine("=======REF=========");
n = 5;
Console.WriteLine($"n truoc khi vao ham = {n}");
ham2(ref n);
Console.WriteLine($"n sau khi vao ham = {n}");
//ref phai khoi tao gia tri cho bien truoc khi goi
//int m;
//ham2(ref m); //bao loi vi m chua duoc khoi tao gia tri

void ham3(out int n)
{
    //out bat buoc phai gan gia tri trong ham - bat buoc co gia tri moi
    n = 8;
}