using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kinopoisk
{
    class funcSQL
    {
        protected OdbcConnection con;
        public funcSQL(OdbcConnection c)
        {
            con = c;
        }
        public funcSQL()
        {
           
        }        
        public gender ConvertToGender(string g)
        {
            if (g == "male")
            {
                return gender.male;
            }
            else 
            {
                return gender.female;
            }
        }
        public List<Film> SearchFilm(string n)
        {
            List<Film> answer = new List<Film>();
            OdbcCommand com = new OdbcCommand("SELECT * FROM film WHERE name LIKE ?", con);            
            com.Parameters.AddWithValue("@par", "%"+n+"%");

            OdbcDataReader dr = com.ExecuteReader();
            
            while (dr.Read())
            {
                uint id; 
                uint cy;
                double r;
                uint.TryParse(dr[0].ToString(), out id);
                uint.TryParse(dr[2].ToString(), out cy);
                double.TryParse(dr[3].ToString(), out r);
                answer.Add(new Film(id, dr["name"].ToString(), cy, r));
            }
            dr.Close();
            return answer;
        }
        public User SearchUser(string login)
        {
            OdbcCommand com = new OdbcCommand("SELECT * FROM users WHERE login = ?", con);
            com.Parameters.AddWithValue("@par", login);

            OdbcDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                gender g = ConvertToGender(dr[4].ToString());
                uint id;
                uint.TryParse(dr[0].ToString(), out id);
                User u = new User(id, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), g, dr[5].ToString(), dr[6].ToString());
                dr.Close();
                return u;
            }
            else
            {
                User u = new User();
                return u;
            }
        }
        public List<Person> SearchPerson(string name)
        {
            string[] str = name.Split(' ');
            List<Person> answer = new List<Person>();
            OdbcCommand com;
            if (str.Count() > 1)
            {
                com = new OdbcCommand("SELECT * FROM person WHERE first_name LIKE ? OR first_name LIKE ? OR last_name LIKE ? OR last_name LIKE ?", con);
                com.Parameters.AddWithValue("@s1", "%" + str[0] + "%");
                com.Parameters.AddWithValue("@s2", "%" + str[1] + "%");
                com.Parameters.AddWithValue("@s3", "%" + str[0] + "%");
                com.Parameters.AddWithValue("@s4", "%" + str[1] + "%");
            }
            else
            {
                com = new OdbcCommand("SELECT * FROM person WHERE first_name LIKE ? OR last_name LIKE ?", con);
                com.Parameters.AddWithValue("@s1", "%" + str[0] + "%");
                com.Parameters.AddWithValue("@s2", "%" + str[0] + "%");
            }

            OdbcDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                uint id;
                uint.TryParse(dr[0].ToString(), out id);
                gender g = ConvertToGender(dr[3].ToString());
                answer.Add(new Person(id, dr[1].ToString(), dr[2].ToString(), g, dr[4].ToString(), dr[5].ToString()));               
            }
            dr.Close();            
            return answer;
        }
        public void AddUser(Dictionary<string, string> user)
        {
            OdbcCommand com = new OdbcCommand("INSERT INTO users(login, password, email, gender, birthday, birthplace) VALUES (?, ?, ?, ?, ?, ?)", con);
            com.Parameters.AddWithValue("@login", user["login"]);
            com.Parameters.AddWithValue("@pass", user["password"]);
            com.Parameters.AddWithValue("@email", user["email"]);
            com.Parameters.AddWithValue("@gender", user["gender"]);
            com.Parameters.AddWithValue("@bd", user["birthday"]);
            com.Parameters.AddWithValue("@bp", user["birthplace"]);
            com.ExecuteScalar();
            return;
        }
        public DataTable ReviewsUser(string login)
        {
            OdbcDataAdapter adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("SELECT name, rating, date_of_publication FROM (SELECT film.name, review.rating, review.date_of_publication FROM review JOIN users ON users.id = review.author_id JOIN film ON film.id = review.film_id WHERE users.login = ?) AS q", con);
            selectCMD.Parameters.Add("@p1", login);
            adapter.SelectCommand = selectCMD;

            DataSet reviews = new DataSet();
            adapter.Fill(reviews, "ReviewsUser");
            return reviews.Tables["ReviewsUser"];
        }
        public DataTable ViewedFilmUser(string login)
        {
            OdbcDataAdapter adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("SELECT name FROM (SELECT film.name FROM viewed_film JOIN users ON users.id = viewed_film.user_id JOIN film ON film.id = viewed_film.film_id WHERE users.login = ?) AS q", con);
            selectCMD.Parameters.Add("@p1", login);
            adapter.SelectCommand = selectCMD;

            DataSet viewedFilm = new DataSet();
            adapter.Fill(viewedFilm, "ViewedFilm");
            return viewedFilm.Tables["ViewedFilm"];
        }
        public void UpdateUser(User newUser)
        {
            string str1 = newUser.Birthday;
            string str2 = str1.Substring(6, 4) + "-" + str1.Substring(3, 2) + "-" + str1.Substring(0, 2);
            OdbcCommand com = new OdbcCommand("UPDATE users SET password=?, email=?, gender=?, birthday=?, birthplace=? WHERE login = ?", con);
            com.Parameters.AddWithValue("@par1", newUser.Password);
            com.Parameters.AddWithValue("@par2", newUser.Email);
            com.Parameters.AddWithValue("@par3", newUser.Gen.ToString());
            com.Parameters.AddWithValue("@par4", str2);
            com.Parameters.AddWithValue("@par5", newUser.Birthplace);
            com.Parameters.AddWithValue("@par6", newUser.Login);
        }
    }
}
