(int, double ) SumAndAverage(params int[] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    double avg = sum/arr.Length;
    return (sum, avg);
}

int[] arr = { 1, 2, 6, 5, 3, 23, 4, 243, 423 };
(int s , double v) =  SumAndAverage(arr);

Console.WriteLine($"Sum = {s}");
Console.WriteLine($"Average = {v}");