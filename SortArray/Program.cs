void swap (ref int a, ref int b)
{
    int temp = a;
    a= b;
    b= temp;
}

//void sort_arr(int[] arr)
//{
//    for (int i = 0; i < arr.Length; i++)
//    {
//        for (int j = i + 1; j < arr.Length; j++)
//        {
//            if (arr[i] > arr[j]) swap(ref arr[i], ref arr[j]);
//        }
//    }
//}

void create_array(int[] arr)
{
    Random rd= new Random();
    for (int i = 0; arr.Length > i; i++)
    {
        arr[i] = rd.Next(100);
    }
}

void print_array (int [] arr)
{
    foreach(int x in arr)
    {
        Console.WriteLine($"{x}\t");
    }
}

int[] arr = new int[10];

create_array(arr);
Console.WriteLine("Mang truoc khi sap xep");
print_array(arr);
Console.WriteLine("Mang sau khi sap xep");
sort_arr(arr);
print_array(arr);



void sort_arr(int[] arr)
{
    int i = 0;
    do
    {
        int j = 0;
        do
        {
            if (arr[i] > arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j++;
        } while (j < i);
        i++;
    } while (i < arr.Length);
}

//void sort_arr(int[] arr)
//{
//    int i = 0;
//    while (i < arr.Length)
//    {
//        int j = 0;
//        while (j < i)
//        {
//            if (arr[i] > arr[j])
//            {
//                swap(ref arr[i], ref arr[j]);
//            }
//            j++;
//        }
//        i++;
//    }
//}