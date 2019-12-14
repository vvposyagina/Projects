using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp
{
    class BinarySearch : Search
    {
        public override int SearchV(int neededElement)
        {
            int begin = 0, end = countOfData, middle;

            if (countOfData == 0)
            {
                return -1;
            }
            else if (data[0] > neededElement)
            {
                return -1;
            }
            else if (data[countOfData - 1] < neededElement)
            {
                return -1;
            }

            while (begin < end)
            {
                middle = begin + (end - begin) / 2;

                if (neededElement <= data[middle])
                    end = middle;
                else
                    begin = middle + 1;
            }
            if (data[end] == neededElement)
            {
                return end;
            }
            else
            {
                return -1;
            }
        }
    }
}
