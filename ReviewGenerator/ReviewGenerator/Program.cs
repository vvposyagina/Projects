using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewGenerator
{
    class Program
    {
        static DataSet ds = new DataSet();
        static void Main(string[] args)
        {
            OdbcConnection con = new OdbcConnection("DSN=PostgreSQL31");
            con.Open();

            OdbcDataAdapter adaptFilm = new OdbcDataAdapter("SELECT * FROM film", con);
            adaptFilm.Fill(ds, "Film");            
            OdbcDataAdapter adaptUser = new OdbcDataAdapter("SELECT * FROM users", con);
            adaptUser.Fill(ds, "User");
            OdbcDataAdapter adaptEditor = new OdbcDataAdapter("SELECT * FROM editor", con);
            adaptEditor.Fill(ds, "Editor");

            con.Close();

            StreamWriter tf = new StreamWriter(new FileStream("Reviews.csv", FileMode.Create));
            tf.WriteLine("\"id\";\"date_of_publication\";\"author_id\";\"film_id\";\"rating\";\"editor_id\";\"agreement\"");
            GenerateData(tf);
            tf.Close();            
        }
        static void GenerateData(StreamWriter tf)
        {
            Random rand = new Random();
            int n = rand.Next(50);
            for(int i = 0; i < n; i++)
            {
                int id = rand.Next(ds.Tables["Film"].Rows.Count);
                int id_film = (int)ds.Tables["Film"].Rows[id]["id"];
                id = rand.Next(ds.Tables["User"].Rows.Count);
                int id_author = (int)ds.Tables["User"].Rows[id]["id"];
                id = rand.Next(ds.Tables["Editor"].Rows.Count);
                int id_editor = (int)ds.Tables["Editor"].Rows[id]["id"];
                DateTime date =new DateTime(2016 - rand.Next(5), rand.Next(11) + 1, 1 + rand.Next(28));
                //double rating  = Math.Round(10 * rand.NextDouble(), 2);
                int wholePartRating = rand.Next(10);
                int fractionalPartRating = rand.Next(100);
                int flagInt = rand.Next(2);
                bool flag = true;
                if (flagInt == 0)
                {
                    flag = false;
                }

                tf.WriteLine("{0};{1};{2};{3};{4}.{5};{6};{7}", i + 1, date, id_author, id_film, wholePartRating, fractionalPartRating, id_editor, flag);                
            }
        }
    }
}
