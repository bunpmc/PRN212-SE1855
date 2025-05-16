// See https://aka.ms/new-console-template for more information

using System.Text;

Console.OutputEncoding = Encoding.UTF8;

void do_calculation(double a, double b, string op)
{
    switch (op)
    {
        case "+":
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            break;
        case "-":
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
            break;
        case "*":
            Console.WriteLine("{0} * {1} = {2}", a, b, a*b);
            Console.WriteLine($" {a} +  { b} = { a+b}");
            break;
        case "/":
            Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
            break;
        default:
            Console.WriteLine("Nhap lui ha ban");
            break;
    }
}

Console.WriteLine("Simple Calculation");
Console.WriteLine("Nhap so a: ");
double a = Double.Parse(Console.ReadLine());
Console.WriteLine("Nhap so b:");
double b = Double.Parse(Console.ReadLine());

Console.WriteLine("Nhap phep toan + - * /");
string  op = Console.ReadLine();
do_calculation(a, b, op);
Console.ReadLine();