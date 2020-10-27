using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //x1 * 10 ^ 11 + x2 * 10 ^ 10 + ...
            //long persnum = 198811013456;

            long x1 = 456;
            long[] array = new long[3];
            long j = 2;
            for (int i = 0; i < 3; i++)
            {
                

                array[i] = x1 / Convert.ToInt32(Math.Pow(10, j));
                x1 = x1 - array[i] * Convert.ToInt32(Math.Pow(10, j));
                j = j - 1;
                Console.WriteLine(array[i]);
                
            }

            //int hej = 456 / Convert.ToInt32(Math.Pow(10, 3));
            //Console.WriteLine(hej);

            Console.ReadKey();
        }
    }
}
