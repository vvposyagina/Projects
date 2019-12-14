using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfData, countOfRequest;

            BinarySearch BS = new BinarySearch();
            LinearSearch LS = new LinearSearch();
            SearchByIndex SS = new SearchByIndex();  
          
            Search[] arr = {LS, BS, SS};

            Console.WriteLine("Введите количество элементов в массиве данных: ");
            countOfData = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество поисковых запросов: ");
            countOfRequest = Convert.ToInt32(Console.ReadLine());

            Search.CreateArray(countOfData, countOfRequest);

            for (int i = 0; i < 3; i++)
            {
                double time = (double)arr[i].Tests() / 1000 ;
                Console.WriteLine("Время работы поиска №" + (i + 1) + ": " + time);
            }

           
            

        }
    }
}
