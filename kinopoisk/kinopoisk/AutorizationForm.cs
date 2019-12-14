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
    public partial class AutorizationForm : Form
    {
        User u;        
        public User User
        {
            get { return u; }
        }
        public string Login
        {
            get { return tbLogin.Text; }
        }
        public AutorizationForm()
        {
            InitializeComponent(); 
        }

        private void bAutorizate_Click_1(object sender, EventArgs e)
        {

            OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
            con.Open();
            funcSQL q = new funcSQL(con);
            u = q.SearchUser(Login);
            if (u.ID == 0 || u.Password != tbPassword.Text)
            {
                MessageBox.Show("Пользователя с таким логином не существует или введеный пароль неверен");
            }
            else
            {
                bAutorizate.DialogResult = DialogResult.OK;
            }
            con.Close();  
        }
    }
}
