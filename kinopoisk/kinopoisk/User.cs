using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kinopoisk
{
    public enum gender {male, female};
    public class User
    {
        uint id;
        string login;
        string password;
        string email;
        gender gen;
        string birthday;
        string birthplace;

        public User(uint i, string log, string pas, string em, gender g, string date, string country)
        {
            id = i;
            login = log;
            password = pas;
            email = em;
            gen = g;
            birthday = date;
            birthplace = country;
        }
        public User(string log, string pas, string em, gender g, string date, string country)
        {
            id = 0;
            login = log;
            password = pas;
            email = em;
            gen = g;
            birthday = date;
            birthplace = country;
        }
        public User()
        {
            id = 0;
        }

        public uint ID
        {
            get { return id; }
        }
        public string Login
        {
            get { return login; }
        }
        public string Password
        {
            get { return password; }
        }
        public gender Gen
        {
            get { return gen; }
        }
        public string Email
        {
            get { return email; }
        }
        public string Birthday
        {
            get { return birthday; }
        }
        public string Birthplace
        {
            get { return birthplace; }
        }

        public Dictionary<string, string> UserConvertToString()
        {
            Dictionary<string, string> user = new Dictionary<string, string>();
            if (ID != 0)
            {
                user.Add("id", ID.ToString());
            }
            user.Add("login", Login);
            user.Add("password", Password);
            user.Add("email", Email);
            user.Add("gender", Gen.ToString());
            user.Add("birthday", Birthday);
            user.Add("birthplace", Birthplace);
            return user;
        }
    }
}
