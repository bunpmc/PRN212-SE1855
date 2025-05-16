using System.Text;

namespace FullStructureProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(":D \"...\" okay ");

            Console.WriteLine("Cac doi so dau vao cua ban");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            Console.ReadLine();
        }
    }
}