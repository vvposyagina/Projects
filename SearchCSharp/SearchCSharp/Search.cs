using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SearchCSharp
{
    class Search
    {
        protected static int[] data;
        protected static int[] request;
        protected int countOfData, countOfRequest;

        public static void CreateArray(int countOfData, int countOfRequest)
        {
            Random rand = new Random();
            data = new int[countOfData];
            request = new int[countOfRequest];
            for(int i = 0; i < countOfData; i++)
            {
                data[i] = rand.Next(10000);
            }
            for(int j = 0; j < countOfRequest; j++)
            {
                request[j] = rand.Next(10000);
            }
            Array.Sort(data);
            Array.Sort(request);    
        }
        public virtual int SearchV(int neededElement)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == neededElement)
                    return i;
            }
            return - 1;
        }
       
        public long Tests()
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            
            foreach(int element in request)
            {
                SearchV(element);
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        

        
    }
}
