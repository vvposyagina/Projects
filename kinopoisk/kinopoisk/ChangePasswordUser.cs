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
    public partial class ChangePasswordUser : Form
    {
        User user;
        public ChangePasswordUser()
        {
            InitializeComponent();
        }
        public ChangePasswordUser(User u)
        {
            InitializeComponent();
            user = u;
        }

        private void bSaveNewPassword_Click_1(object sender, EventArgs e)
        {
            if (tbPass.Text == tbRepeatPass.Text)
            {
                if (RegistrationForm.CheckTextBox(tbPass.Text))
                {
                    OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
                    con.Open();
                    funcSQL q = new funcSQL(con);                    
                    User newUser = new User(user.ID, user.Login, tbPass.Text, user.Email, user.Gen, user.Birthday, user.Birthplace);
                    q.UpdateUser(newUser);
                    user = newUser;
                    bSaveNewPassword.DialogResult = DialogResult.OK;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Пароль не удовлетворяет условиям");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }       
    }
}
