using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2;

namespace OOP2_REUSE_LIBRARY
{
    public static class YourUtils
    {
        public static int TinhTuoi (this Employee employee)
        {
            return DateTime.Now.Year - employee.Birthday.Year + 1;
        }
    }
}
