using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // создание подключения к базе данных на основе строки соединения 
            // с указанием источника данных ODBC
            OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
            // подключение к источнику данных
            con.Open();
            // формирование команды SQL на выборку данных
            int n = 1994;
            OdbcCommand com = new OdbcCommand("select * from film where creation_year=?", con);
            // выполнение команды на сервере и сохранение результата в курсоре типа OdbcDataReader
            // задание значение параметра запроса
            com.Parameters.AddWithValue("@par", n);

            OdbcDataReader dr = com.ExecuteReader();
            // переход к следующей строке посредством функции Read()
            // пока строки в результате есть – печатаем информацию из строк
            while (dr.Read())
                Console.WriteLine(dr["name"] + " " + dr["rating"]);
            // закрывается соединение
            dr.Close();
            con.Close();
             создание подключения к базе данных на основе строки соединения 
       с указанием источника данных ODBC
      OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
      // подключение к источнику данных
      con.Open();
      // ввод названия новой учебной дисциплины
      string title = "('Большой куш', 2000, 8.489)";
      // формирование команды SQL на добавление данных – в таблице ключ задается с помощью 
      // поля-счетчика, так что указывать его в запросе на вставку не обязательно
      OdbcCommand com = new OdbcCommand("insert into film(name, creation_year, rating) values ('?')", con);
      // задание значение параметра запроса
      com.Parameters.AddWithValue("@par",title);
      // выполнение команды на сервере 
      com.ExecuteScalar();
      // закрывается соединение
      con.Close();

        }
    }
}
