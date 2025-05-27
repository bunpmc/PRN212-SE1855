int sum (params int[] arr)
{
    int sum = 0;
    foreach (int x in arr)
    {
        sum += x;
    }
    return sum;
}

Console.WriteLine(sum());
Console.WriteLine(sum(1, 4, 9));
Console.WriteLine(sum(1, 4, 6,1,2,3,10,112,10));