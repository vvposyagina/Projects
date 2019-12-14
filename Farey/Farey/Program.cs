using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farey
{
    class Program
    {
        public Tuple<int, int> Fraction(double k, int n)
        {
            int m = 1;
            int i;
            for (; m < n; m++)
            {   
                i = n;
                for (; i > m; i--)
                {
                    if (i % m != 0)
                    {
                        if (k < (m / i))
                        {
                            return new Tuple<int, int>(m, i);
                        }
                    }
                }               
            }
            return new Tuple<int, int>(n - 1, n);
        }
        static void Main(string[] args)
        {
            double k = Math.PI / 4;
            int m = 1;
            int n = 16;
        }
    }
}
