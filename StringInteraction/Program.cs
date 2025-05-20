using System.Text;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string ho = "Nguyen";
string tenlot = "Thi";
String ten = "Teo";

//Not recommended moi dau + la xin 1 o nho
string fullname = ho + " " + tenlot  + " " + ten;   
Console.WriteLine(fullname);

//Chi cap 1 o nho 1 lan
StringBuilder sb = new StringBuilder();
sb.Append(ho);
sb.Append(" ");
sb.Append(tenlot);
sb.Append(" ");
sb.Append(ten);
Console.WriteLine(sb.ToString());