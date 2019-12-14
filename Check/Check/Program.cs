using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    class Program
    {
        static void Main(string[] args)
        {
                // создание набора данных
                DataSet ds = new DataSet();

                // создаем таблицу чеков
                DataTable chek = new DataTable("Чеки");
                // добавляем таблицу в список таблиц набора данных
                ds.Tables.Add(chek);

                // формируем список столбцов таблицы чеков
                // для каждого столбца указывается имя столбца и тип данных

                // атрибут номера чека
                DataColumn dc = new DataColumn("НомерДоговора",
                Type.GetType("System.Int32"));
                ds.Tables["Чеки"].Columns.Add(dc);
                // атрибут даты чека
                dc = new DataColumn("ДатаДоговора", Type.GetType("System.DateTime"));
                ds.Tables["Чеки"].Columns.Add(dc);
                // атрибут названия магазина
                dc = new DataColumn("Турагентство", Type.GetType("System.String"));
                ds.Tables["Чеки"].Columns.Add(dc);
                // атрибут ФИОКассира
                dc = new DataColumn("ФИООператора", Type.GetType("System.String"));
                ds.Tables["Чеки"].Columns.Add(dc);
                // атрибут общей стоимости чека
                dc = new DataColumn("Стоимость", Type.GetType("System.Int32"));
                ds.Tables["Чеки"].Columns.Add(dc);

                // описание первичного ключа - массива ссылок на столбцы таблицы
                // первичным ключом будет комбинация номера и даты чека
                DataColumn[] key = new DataColumn[2] 
                { ds.Tables["Чеки"].Columns["НомерДоговора"], 
                ds.Tables["Чеки"].Columns["ДатаДоговора"] };
                ds.Tables["Чеки"].PrimaryKey = key;

                // создаем таблицу записей чеков
                // добавляем таблицу в список таблиц набора данных
                ds.Tables.Add(new DataTable("ЗаписьДоговора"));

                // атрибут номера записи чека
                dc = new DataColumn("НомерЗаписиДоговора",
                                        Type.GetType("System.Int32"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);
                // атрибут номера чека
                dc = new DataColumn("НомерДоговора", Type.GetType("System.Int32"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);
                // атрибут даты чека
                dc = new DataColumn("ДатаДоговора", Type.GetType("System.DateTime"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);
                // атрибут название товара
                dc = new DataColumn("Путевка", Type.GetType("System.String"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);
                // атрибут цены товара
                dc = new DataColumn("ЦенаПутевки", Type.GetType("System.Int32"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);
                // атрибут количества товара
                dc = new DataColumn("Количество", Type.GetType("System.Int32"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);
                // атрибут общей стоимости строки
                dc = new DataColumn("Стоимость", Type.GetType("System.Int32"));
                ds.Tables["ЗаписьДоговора"].Columns.Add(dc);

                // описание первичного ключа - массива ссылок на столбцы таблицы
                // первичным ключом будет номер записи чека
                key = new DataColumn[3] 
                { ds.Tables["ЗаписьДоговора"].Columns["НомерЗаписиДоговора"], 
                ds.Tables["ЗаписьДоговора"].Columns["НомерДоговора"], 
                ds.Tables["ЗаписьДоговора"].Columns["ДатаДоговора"] };
                ds.Tables["ЗаписьДоговора"].PrimaryKey = key;


                // создание связи между таблицами
                // указывается имя отношения и два массива связанных полей – 
                // для родительской и дочерней таблиц
                DataRelation rel = new DataRelation("СвязьДоговора",
                new DataColumn[]{ds.Tables["Чеки"].Columns["НомерДоговора"], 
                ds.Tables["Чеки"].Columns["ДатаДоговора"]},
                new DataColumn[]{ds.Tables["ЗаписьДоговора"].Columns["НомерДоговора"], 
                ds.Tables["ЗаписьДоговора"].Columns["ДатаДоговора"]});
                //добавляем связь в список связей набора данных
                ds.Relations.Add(rel);

                // сохранение структуры и данных в xml-файле 
                // второй параметр задает, что вместе с данными должна быть сохра-нена схема // данных, т.е. указание на структуру хранимых данных
                ds.WriteXml("chek.xml", XmlWriteMode.WriteSchema);
        }
    }
}
