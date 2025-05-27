void hinh1(int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n*2; j++)
        {
            if (j == 0 || j == n *2 - 2 || (j==i && i <= n/2) ||( j == (n*2-2-i) && i <= n/2))
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

}

hinh1(8);
