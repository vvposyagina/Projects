using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kinopoisk
{
    public class Person
    {
        uint id;
        string first_name;
        string last_name;
        gender gen;
        string birthday;
        string birthplace;
        public Person(uint i, string fn, string ln, gender g, string bd, string bp)
        {
            id = i;
            first_name = fn;
            last_name = ln;
            gen = g;
            birthday = bd;
            birthplace = bp;
        }
        public Person(string fn, string ln, gender g, string bd, string bp)
        {
            id = 0;
            first_name = fn;
            last_name = ln;
            gen = g;
            birthday = bd;
            birthplace = bp;
        }
        public Person()
        {
            id = 0;
        }
        public uint ID
        {
            get { return id; }
        }
        public string FirstName
        {
            get { return first_name; }
        }
        public string LastName
        {
            get { return last_name; }
        }
        public gender Gen
        {
            get { return gen; }
        }       
        public string Birthday
        {
            get { return birthday; }
        }
        public string Birthplace
        {
            get { return birthplace; }
        }

    }
}
