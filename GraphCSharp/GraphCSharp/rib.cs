using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCSharp
{
    class rib
    {
        public int fi, se, weight;
        public rib()
        {
            fi = 0;
            se = 0;
            weight = 0;
        }
        public rib(int f = 0, int s = 0, int w = 0)
        {
            fi = f;
            se = s;
            weight = w;
        }
    }
}
