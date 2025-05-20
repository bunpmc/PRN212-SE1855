using System.Text;

void first_degree_solution (double a, double b)
{
    if ( a == 0 && b ==0 )
    {
        Console.WriteLine("Vo so nghiem");
    }
    else if ( a == 0 && b != 0) 
    {
        Console.WriteLine("Vo nghiem");
    }else
    {
        Console.WriteLine($"x = {-b / a}");
    }
}

void quadratic_equation_solution(double a, double b, double c)
{
    if (a == 0)
    {
        first_degree_solution(b, c);
    } else
    {
        var delta = Math.Pow(b, 2) - 4 * a * c;
        if(delta < 0)
        {
            Console.WriteLine("Phuong trinh vo nghiem");

        } else if (delta > 0 )
        {
            var x1 = (-b-Math.Sqrt(delta))/(2*a);
            var x2 = (-b+Math.Sqrt(delta))/(2*a);
            Console.WriteLine("X1 = {0}, X2 = {1}",x1, x2);
        } else
        {
            Console.WriteLine($"{-b / (2 * a)}");
        }
    }
}

Console.OutputEncoding = Encoding.UTF8;
while (true)
{
    Console.WriteLine("Phuong trinh bac 2: ax^2 + bx + c = 0");
    Console.WriteLine("He so a: ");
    double a = Double.Parse(Console.ReadLine());
    Console.WriteLine("He so b: ");
    double b = Double.Parse(Console.ReadLine());
    Console.WriteLine("He so c: ");
    double c = Double.Parse(Console.ReadLine());

    quadratic_equation_solution(a, b, c);
    Console.ReadLine();
}
