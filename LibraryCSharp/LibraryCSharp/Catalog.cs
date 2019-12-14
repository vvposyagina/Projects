using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCSharp
{
    class Catalog
    {
        private List<Book> Books;
        private int NumberOfNextBook;
        public Catalog()
        {
            this.Books = new List<Book>();
            this.NumberOfNextBook = 0;
        }
        public int GetNumberOfNextBook()
        {
            return Books.Count() + 1;
        }        
        public void AddBook(int id, string name, string author, int year)
        {
            Book NewBook = new Book(id, name, author, year);
            Books.Add(NewBook);
        }
        public static bool SearchBook(Book book, int id, string name, string author, int year)
        {
            bool findId  = false, findName = false, findAuthor = false, findYear = false;
            
            if ((book.GetId() == id) || (id == 0))
            {
                findId = true;
            }
            if ((book.GetName().Contains(name)) || (name == "0"))
            {
                findName = true;
            }
            if ((book.GetAuthor().Contains(author)) || (author == "0"))
            {
                findAuthor = true;
            }
            if ((book.GetYear() == year) || (year == 0))
            {
                findYear = true;
            }
            return (findId && findName && findAuthor && findYear);
            
        }
        public List<Book> FindBooks(int id, string name, string author, int year)
        {
            List<Book> arr = new List<Book>();
            foreach(Book book in Books)
            {
                if(SearchBook(book, id, name, author, year))
                {
                    arr.Add(book);
                }
            }
            return arr;
        }
        public bool DeleteBook(int id, string name, string author, int year)
        {
            bool flag = false;
            foreach (Book book in Books)
            {
                if (SearchBook(book, id, name, author, year))
                {
                    Books.Remove(book);
                    flag = true;
                }
              
            }
            return flag;
        }
        public bool DownloadFromFile(string nameFileInput)
        {
            string newBook;
            bool flag = false;

            System.IO.StreamReader file = new System.IO.StreamReader(@nameFileInput);
            while ((newBook = file.ReadLine()) != null)
            {              
                Book newElement = new Book(newBook);
                Books.Add(newElement);
                flag = true;
            }
            return flag;
        }
        public bool SaveNewLibrary(string nameOfFileOutput)
        {
            bool flag = false;
            foreach (Book element in Books)
            {
                string NewBookInList = Book.MakeString(element);            
                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@nameOfFileOutput, true))
                {
                    file.WriteLine(NewBookInList);
                }
                flag = true;
            }
            return flag;
        }
        public void CleaningCatalog()
        {
            Books.Clear();
        }
        
    }
}
