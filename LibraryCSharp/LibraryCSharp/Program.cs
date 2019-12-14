using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            Book book = new Book();
            Console.WriteLine("Добро пожаловать в программу. Выберите команду:");
            Console.WriteLine("");
            Console.WriteLine("1 - Загрузить библиотеку");
            Console.WriteLine("2 - Поиск");
            Console.WriteLine("3 - Добавить новый элемент библиотеки");
            Console.WriteLine("4 - Удалить элемент");
            Console.WriteLine("5 - Сохранить изменения");
            Console.WriteLine("6 - Очистить библиотеку");
            Console.WriteLine("0 - Выход из программы");

            int function;
            try
            {
                while ((function = Convert.ToInt32(Console.ReadLine())) != 0)
                {
                    switch (function)
                    {
                        case 1:
                            Console.WriteLine("Введите имя файла ввода: ");
                            string nameOfFileInput = Console.ReadLine();
                            bool success = catalog.DownloadFromFile(nameOfFileInput);
                            if (success)
                                Console.WriteLine("Библиотека успешно загружена");
                            else
                                Console.WriteLine("Не удалось загрузить библиотеку");
                            break;
                        case 2:
                            int id, year;
                            string name, author;
                            Console.WriteLine("Если вы хотите оставить поле пустым, введите 0");
                            Console.WriteLine("Введите id: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите название книги: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите имя автора: ");
                            author = Console.ReadLine();
                            Console.WriteLine("Введите год создания: ");
                            year = Convert.ToInt32(Console.ReadLine());
                            List<Book> answer = catalog.FindBooks(id, name, author, year);
                            foreach (Book element in answer)
                            {
                                string temp = Book.MakeString(element);
                                Console.WriteLine(temp);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Введите название книги: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите имя автора: ");
                            author = Console.ReadLine();
                            Console.WriteLine("Введите год создания: ");
                            year = Convert.ToInt32(Console.ReadLine());
                            catalog.AddBook(catalog.GetNumberOfNextBook(), name, author, year);
                            break;
                        case 4:
                            Console.WriteLine("Если вы хотите оставить поле пустым, введите 0");
                            Console.WriteLine("Введите id удаляемого элемента: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите название книги: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите имя автора: ");
                            author = Console.ReadLine();
                            Console.WriteLine("Введите год создания: ");
                            year = Convert.ToInt32(Console.ReadLine());
                            success = catalog.DeleteBook(id, name, author, year);
                            if (success)
                                Console.WriteLine("Найденные книги успешно удалены");
                            else
                                Console.WriteLine("Не удалось удалить элементы с данными параметрами");
                            break;
                        case 5:
                            Console.WriteLine("Введите имя файла вывода: ");
                            string nameOfFileOutput = Console.ReadLine();                            
                            success = catalog.SaveNewLibrary(nameOfFileOutput);
                            if (success)
                                Console.WriteLine("Библиотека успешно сохранена");
                            else
                                Console.WriteLine("Не удалось сохранить библиотеку");
                            break;
                        case 6:
                            Console.WriteLine("Работа программы завершена");
                            break;
                        default:
                            Console.WriteLine("Введенная команда не действительна");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Введенная команда не действительна");
            }
        }
    }
}
