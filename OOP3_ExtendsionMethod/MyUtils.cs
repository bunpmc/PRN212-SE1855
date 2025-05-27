using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP3_ExtendsionMethod
{
    public static class MyUtils
    {
        /*Cau 1: Cai dat 1 ham trong TongTu1toiN
         * vao kieu int cua Microsoft
         */
        public static int TongTu1toiN(this int n )
        {
            int sum = 0;
            for (int i = 0; i < n; i++) 
            {
                sum += i;
            }
            return sum;
        }

        public static int Cong(this int a, int b)
        {
            return a + b;
        }

        public static void SapXepTangDan (this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }  
                }
            } 
        }

        public static void RandomArray (this int[] arr)
        {
            Random random = new Random();
            for (int i = 0; arr.Length > i; i++)
            {
                arr[i] = random.Next(100); //0-99
            }
        }

        public static void XuatMang(this int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i + "\t");
            }
            Console.WriteLine();
        }
    }
}
