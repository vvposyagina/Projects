using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCSharp
{
    class Book
    {
        private int id, year;
        private string name, author;

        public int GetId()
        {
            return this.id;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetAuthor()
        {
            return this.author;
        }
        public int GetYear()
        {
            return this.year;
        }
       public Book()
        {
            this.id = 0;
            this.name = null;
            this.author = null;
            this.year = 0;
        }
        public Book(int id, string name, string author, int year)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.year = year;
        }
        public Book(string infoAboutBook)
        {
            string[] arrInfoAboutBook = infoAboutBook.Split(';'); 
            
            this.id = Convert.ToInt32(arrInfoAboutBook[0].Trim(' '));

            this.name = arrInfoAboutBook[1].Trim(' ');

            this.author = arrInfoAboutBook[2].Trim(' ');

            this.year = Convert.ToInt32(arrInfoAboutBook[3].Trim(' '));
        }
        public static string MakeString(Book NewBookInList)
        {
           string answer = null;
           answer = NewBookInList.id.ToString() + "; " + NewBookInList.name + "; " + NewBookInList.author + "; " + NewBookInList.year.ToString() + ";";
           return answer;
        }

    }
}
