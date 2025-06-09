using Lucy_SalesManagement;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string connectionString = @"server=MINHCHAU\DBI202;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);

//Cau 1: lay chi tiet thong tin khach hang khi biet ma
int makh = 1;
Customer c1 = context.Customers.FirstOrDefault(x => x.CustomerID == makh);

if (c1 != null)
{
    Console.WriteLine($"Thong tin khach hang co ma {makh}:");
    Console.WriteLine("Ma khach hang: {0}, Ten: {1}, Dia chi: {2}, So dien thoai: {3}",
        c1.CustomerID, c1.ContactName, c1.Address, c1.Phone);
}
else
{
    Console.WriteLine("Khong tim thay khach hang co ma {0}", makh);
}

//Cau 2: Loc ra danh sach cac hoa don cua khach hang tim tha
if (c1 != null)
{
    Console.WriteLine("Danh sach hoa don cua khach hang: ");
    foreach (var order in c1.Orders)
    {
        Console.WriteLine(order.OrderID + "\t" + order.OrderDate.ToString("dd/mm/yyyy") + "\t" + order.Order_Details);
    }
}
else
{
    Console.WriteLine("Khach hang khong co hoa don nao.");
}

//Cau 3: Nang cap cau 2, bo sung them mot cot hien thi tri gia cua hoa don
string details = "Order Details";
if (c1 != null)
{
    Console.WriteLine("Danh sach hoa don cua khach hang");
    foreach(var order in c1.Orders)
    {
        var price = context.Order_Details.Where(x => x.OrderID == order.OrderID).ToList();
        Console.WriteLine(order.OrderID + "\t" + order.OrderDate.ToString("dd/mm/yyyy") + "\t" + order.Order_Details);
        var sum = price.Sum(x => x.UnitPrice * x.Quantity);
        Console.WriteLine("Sum price: ", sum);
    }
}