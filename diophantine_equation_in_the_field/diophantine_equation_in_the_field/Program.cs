using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace diophantine_equation_in_the_field
{
    class Program
    {
        public static Tuple<int, int> SearchingXY(int k, int a, int b)
        {
            double sqrtK = Math.Sqrt(Convert.ToDouble(k));
            Tuple<int, int> answer = new Tuple<int, int>(0, 0); ;
            for (int i = 0; i <= sqrtK; i++)
            {
                for (int j = 0; j <= sqrtK; j++)
                {
                    if (i * j <= sqrtK)
                    {
                        if ((a * i + b * j) % k == 0)
                            answer = new Tuple<int, int>(i, j);
                        if ((a * i - b * j) % k == 0)
                            answer = new Tuple<int, int>(i, -j);                                                
                    }                    
                }
            }
            return answer;
        }

        public static double SearchingC(int k, int a, int b)
        {
            int x = SearchingXY(k, a, b).Item1;
            int y = SearchingXY(k, a, b).Item2;

            double c = (x * a + y * b) / k;
            return c;
        }
        static void Main(string[] args)
        {            

            Console.WriteLine("Введите к: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите A: ");    
            int a  = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите B: ");    
            int b  = Convert.ToInt32(Console.ReadLine());

            Tuple<int, int> answer = SearchingXY(k, a, b);
            Console.WriteLine("X = " + answer.Item1);
            Console.WriteLine("Y = " + answer.Item2);
            Console.WriteLine("C = " + SearchingC(k, a, b));
        }
    }
}
