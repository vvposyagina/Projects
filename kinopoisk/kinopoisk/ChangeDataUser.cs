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
    public partial class ChangeDataUser : Form
    {
        User user;
        public ChangeDataUser()
        {
            InitializeComponent();
        }
        public ChangeDataUser(User u)
        {
            InitializeComponent();
            user = u;
        }

        private void bSaveChange_Click(object sender, EventArgs e)
        {
            string email = user.Email;
            gender gen = user.Gen;
            string bd = user.Birthday;
            string bp = user.Birthplace;
            if (RegistrationForm.CheckTextBox(tbEmail.Text))
            {
                email = tbEmail.Text;
            }
            if (rbMale.Checked)
            {
                gen = gender.male;
            }
            else
            {
                gen = gender.female;
            }
            if (dtpUserBirthday.Value.Date != DateTime.Now.Date)
            {
                string str1 = dtpUserBirthday.Value.Date.ToString();
                bd = str1.Substring(6, 4) + "-" + str1.Substring(3, 2) + "-" + str1.Substring(0, 2);
            }
            if(cbUserBirthplace.Text.Length != 0)
            {
                bp = cbUserBirthplace.Text;
            }

            User newUser = new User(user.ID, user.Login, user.Password, email, gen, bd, bp);
            OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
            con.Open();
            funcSQL q = new funcSQL(con);
            q.UpdateUser(newUser);
            user = newUser;
            bSaveChange.DialogResult = DialogResult.OK;
            con.Close();
        }
    }
}
