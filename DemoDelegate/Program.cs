using System.Text;

class Program
{
    public delegate int MyDelegate1(int x, int y);
    static int Cong(int x, int y)
    {
        return x + y;
    }
    static int Tru(int x, int y)
    {
        return x - y;
    }
    public delegate int[] MyDelegate2(int n);
    static int[] DanhSachSoChan(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i = i + 2)
        {
            list.Add(i);
        }
        return list.ToArray();
    }
    static int[] DanhSachSoNguyenTo(int n)
    {
        List<int> list = new List<int>();
        for (int i=2; i<=n;i++)
        {
            int count = 0;
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    count++;
                }
            }
            if (count==2)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    public static void main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        MyDelegate1 d1 = new MyDelegate1(Cong);
        Console.WriteLine("Sum of 5 and 8=" + d1(5, 8));
        d1 = new MyDelegate1(Tru);
        Console.WriteLine("Hiệu của 5 và 8=" + d1(5, 8));

        MyDelegate2 d2 = new MyDelegate2(DanhSachSoChan);
        int[] arr = d2(10);
        Console.WriteLine("Danh sach so chan:");
        foreach (int i in arr) Console.WriteLine(i);

        d2 = new MyDelegate2(DanhSachSoNguyenTo);
        arr = d2(10);
        Console.WriteLine("Danh sach so nguyen to:");
        foreach (int i in arr) Console.WriteLine(i);
    }
}