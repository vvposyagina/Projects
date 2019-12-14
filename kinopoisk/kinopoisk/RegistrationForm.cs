using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kinopoisk
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        public static bool CheckTextBox(string str)
        {
            if (str.Count() < 6)
            {
                return false;
            }
            for(int i = 0; i < str.Count(); i++)
            {
                if (str[i] >= 'а' && str[i] <= 'я' || str[i] >= 'А' && str[i] <= 'Я')
                    return false;
            }
            return true;
        }
        private void bRegistrate_Click(object sender, EventArgs e)
        {
            bool logmail = true;
            bool passflag = true;
            string log = "";
            string pass = "";
            string email = "";
            if (CheckTextBox(Login) && CheckTextBox(Email))
            {
                log = Login;
                email = Email;
            }
            else
            {
                logmail = false;
            }       
            if (CheckTextBox(Password) && Password == tbRepeatPass.Text)
            {
                pass = Password;
            }
            else
            {
                passflag = false;
            }
            gender g = Gen;
            string date = Birthday;
            string country = Birthplace;
            if (logmail && passflag)
            {                
                User user = new User(log, pass, email, g, date, country);
                Dictionary<string, string> str = user.UserConvertToString();
                OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
                con.Open();
                funcSQL q = new funcSQL(con);
                q.AddUser(str);
                bRegistrate.DialogResult = DialogResult.OK;
                con.Close();
            }
            else
            {
                MessageBox.Show("Используйте только латинские символы, длина логина и пароля не менее 6 символов");
            }            
        }

        public String Login
        {
            get { return tbLogin.Text; }
        }
        public String Password
        {
            get { return tbPass.Text; }
        }

        public String Email
        {
            get { return tbEmail.Text; }
        }
        public gender Gen
        {
            get
            {
                if (rbMale.Checked)
                    return gender.male;
                else
                    return gender.female;
            }
        }
        public String Birthday
        {
            get 
            { 
                string str1 = dtpUserBirthday.Value.Date.ToString();
                string str2 = str1.Substring(6, 4) + "-" + str1.Substring(3, 2) + "-" + str1.Substring(0, 2);
                return str2;
            }
        }
        public String Birthplace
        {
            get {return cbUserBirthplace.Text;}
        }
        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

    }
}
