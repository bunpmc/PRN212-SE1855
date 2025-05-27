/*
 * De bai
Nhap vao 1 so >= 0 neu nhap sai quy tac thi yeu cau nhap lai khi nao dung moi dung
Neu nhap dung thi tinh n! cua no
 */

int n = -1; //gia su nhap sai

while(n < 0)
{
    Console.WriteLine("Nhap so: ");
    string input = Console.ReadLine();
    if (int.TryParse(input, out n) == true) //ep kieu
    {
        //khi vao day n la so co the < 0
        if (n >= 0)
        {
            break;
        } else
        {
            Console.WriteLine("n must >= 0");
        }
    } else
    {
        Console.WriteLine("Number only");
    }
}

int giaithua = 1;
for  (int i = 0; i <= n; i++)
{
    giaithua *= i;
}
Console.WriteLine($"{n}! = {giaithua}");