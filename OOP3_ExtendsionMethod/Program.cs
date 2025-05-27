using OOP3_ExtendsionMethod;

int n1 = 5;
Console.WriteLine("Tong tu 1 toi 5 = " + n1.TongTu1toiN());
int n2 = 10;
Console.WriteLine("Tong tu 1 toi 5 = " + n2.TongTu1toiN());
Console.WriteLine("Tong tu 1 toi 5 = " + 100.TongTu1toiN());

Console.WriteLine("10 + 20 = " + 10.Cong(20));

int[] arr = new int[8];
arr.RandomArray();
Console.WriteLine();
arr.XuatMang();
arr.SapXepTangDan();
Console.WriteLine();
arr.XuatMang();