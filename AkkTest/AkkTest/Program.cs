using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AkkTest
{
    class Program
    {
        //версия функции Аккермана с тремя переменными, найденная в альтернативном источнике
        public static BigInteger AckermannFunctionV2(BigInteger z, BigInteger x, BigInteger y)
        {
            BigInteger answer = 0;
            
            if (y == 0)
            {
                answer = z + x;
            }
            else if (x == 0 && y == 1)
            {
                answer = 0;
            }
            else if (x == 0 && y == 2)
            {
                answer = 1;
            }
            else if (x == 0 && y > 2)
            {
                answer = z;
            }
            else
            {
                answer = AckermannFunctionV2(z, AckermannFunctionV2(z, x - 1, y), y - 1);
            }
            return answer;
        }
        //Версия функции Аккермана с тремя переменными, данная на лекции
        public static BigInteger AckermannFunctionV1(BigInteger z, BigInteger x, BigInteger y)
        {
            BigInteger answer = 0;
            if (x == 0 && z == 0)
            {
                answer = y;
            }
            else if (z == 0)
            {
                answer = AckermannFunctionV1(0, x - 1, y) + 1;
            }
            else if (x == 0 && z == 1)
            {
                answer = 0;
            }
            else if (z > 1 && x == 0)
            {
                answer = 1;
            }
            else
            {
                answer = AckermannFunctionV1(z - 1, AckermannFunctionV1(z, x - 1, y), y);
            }
            
            return answer;
        }
        public static BigInteger AckermannFunctionV3(BigInteger m, BigInteger n) 
        { 
            if ((m == 0) && (n >= 0))
            return (n + 1); 
            if ((m >= 1) && (n == 0))
                return (AckermannFunctionV3(m - 1, 1));
            if ((m >= 1) && (n >= 1))
                return (AckermannFunctionV3(m - 1, AckermannFunctionV3(m, n - 1)));

        }

        static void Main(string[] args)
        {
            Console.WriteLine(AckermannFunctionV1(2, 2, 2));
            Console.WriteLine(AckermannFunctionV2(2, 2, 2));
        }
    }
}
