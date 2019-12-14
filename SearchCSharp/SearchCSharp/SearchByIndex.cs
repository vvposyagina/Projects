using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp
{
    class SearchByIndex : Search
    {
        public override int SearchV(int neededElement)
        {
            int Step = (int)Math.Sqrt(countOfData);
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

            for (int i = Step; i + Step < countOfData; i += Step)
            {
                if (data[i] > neededElement)
                {
                    for (int j = i - Step; j < i; j++)
                    {
                        if (data[j] == neededElement)
                        {
                            return j;
                        }
                    }
                    return -1;
                }
            }
            for (int i = countOfData - 1 - Step; i < countOfData; i++)
            {
                if (data[i] == neededElement)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
