using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kinopoisk
{
    public class Film
    {
        uint id;
        string name;
        uint creation_year;
        double rating;

        public Film(uint i, string n, uint cy, double r)
        {
            id = i;
            name = n;
            creation_year = cy;
            rating = r;
        }
        public Film(string n, uint cy, double r)
        {
            id = 0;
            name = n;
            creation_year = cy;
            rating = r;
        }
        public Film()
        {
            id = 0;         
        }
        public uint ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
        }
        public uint CreationYear
        {
            get { return creation_year; }
        }
        public double Rating
        {
            get { return rating; }
        }
        
    }
}
