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
    public partial class FormForUser : Form
    {
        User user;
        public FormForUser()
        {
            InitializeComponent();
        }
        public FormForUser(User u)
        {
            InitializeComponent();
            BindingSource BinSourceR = new BindingSource();
            BindingSource BinSourceV = new BindingSource();
            user = u;
            lMyLogin.Text = user.Login;
            lMyBirthday.Text = user.Birthday;
            lMyEmail.Text = user.Email;
            lMyBirthplace.Text = user.Birthplace;
            lMyGender.Text = user.Gen.ToString();
            lMyLogin.Location = new Point(130, 86);
            lMyBirthday.Location = new Point(130, 106);
            lMyEmail.Location = new Point(130, 126);
            lMyBirthplace.Location = new Point(130, 146);
            lMyGender.Location = new Point(130, 166);
            OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");
            con.Open();
            funcSQL q = new funcSQL(con);

            BinSourceR.DataSource = q.ReviewsUser(user.Login);
            dgvReviews.AutoGenerateColumns = false;
            dgvReviews.DataSource = BinSourceR;

            DataGridViewTextBoxColumn NameOfFilmR = new DataGridViewTextBoxColumn();           
            NameOfFilmR.DataPropertyName = "name";
            NameOfFilmR.HeaderText = "Фильм";
            dgvReviews.Columns.Add(NameOfFilmR);

            DataGridViewTextBoxColumn DateOfPublication = new DataGridViewTextBoxColumn();
            DateOfPublication.DataPropertyName = "date_of_publication";
            DateOfPublication.HeaderText = "Дата публикации";
            dgvReviews.Columns.Add(DateOfPublication);

            DataGridViewTextBoxColumn Rating = new DataGridViewTextBoxColumn();
            Rating.DataPropertyName = "rating";
            Rating.HeaderText = "Оценка";
            dgvReviews.Columns.Add(Rating);

            BinSourceV.DataSource = q.ViewedFilmUser(user.Login);
            dgvViewedFilm.AutoGenerateColumns = false;
            dgvViewedFilm.DataSource = BinSourceV;

            DataGridViewTextBoxColumn NameOfFilmV = new DataGridViewTextBoxColumn();
            NameOfFilmV.DataPropertyName = "name";
            NameOfFilmV.HeaderText = "Фильм";
            dgvViewedFilm.Columns.Add(NameOfFilmV);
        }

        private void bChangeData_Click(object sender, EventArgs e)
        {
            ChangeDataUser form = new ChangeDataUser(user);
            form.ShowDialog();
        }

        private void bChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordUser form = new ChangePasswordUser(user);
            form.ShowDialog();
            //if(form.DialogResult == DialogResult.OK)
        }

        

       
        
    }
}
