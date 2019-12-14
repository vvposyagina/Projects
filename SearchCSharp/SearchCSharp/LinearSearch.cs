using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp
{
    class LinearSearch : Search
    {
        public override int SearchV(int neededElement)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == neededElement)
                    return i;
            }
            return -1;
        }
    }
}
