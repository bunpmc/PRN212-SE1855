static int sum (int a, int b)
{
    return a + b;
}
void callsum() {
    int s = sum(5, 8);
}

double average (int a, int b )
{
    return (a + b) / 2;
}

static void callAverage()
{
    double d = average(3, 6);
}

//static khong can nap vao o nho => xuat hien truoc nen khong goi non-static duoc