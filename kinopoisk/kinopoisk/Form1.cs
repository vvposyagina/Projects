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
    public partial class MainPage : Form
    {
        User user;
        public MainPage()
        {
            InitializeComponent();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=PostgreSQL30");            
            con.Open();
            funcSQL q = new funcSQL(con);
            List<Film> films = new List<Film>();            
            films = q.SearchFilm(tbSearch.Text);
            List<Person> persons = new List<Person>();
            persons = q.SearchPerson(tbSearch.Text);
            pResultOfSearch.Controls.Clear();
            pResultOfSearch.Visible = true;
            pResultOfSearch.Controls.Add(lResultOfSearch);
            pResultOfSearch.Controls.Add(lFilms);
            pResultOfSearch.Controls.Add(lPersons);
            int x1 = 4;
            int x2 = 300;
            int y = 55;            
            if (films.Count() > 0 || persons.Count() > 0)
            {                
                for (int i = 0; i < films.Count; i++)
                {
                    LinkLabel SearchAnswer = new LinkLabel();
                    SearchAnswer.Text = films[i].Name;
                    SearchAnswer.AutoSize = true;
                    SearchAnswer.Location = new Point(x1, y);                   
                    pResultOfSearch.Controls.Add(SearchAnswer);
                    SearchAnswer.Click += new System.EventHandler(LinkLabelClick);
                    y += 20;
                }
                y = 55;
                for (int j = 0; j < persons.Count; j++)
                {
                    LinkLabel SearchAnswer = new LinkLabel();
                    SearchAnswer.Text = persons[j].FirstName + " " + persons[j].LastName;
                    SearchAnswer.AutoSize = true;
                    SearchAnswer.Location = new Point(x2, y);
                    pResultOfSearch.Controls.Add(SearchAnswer);
                    y += 20;
                }
                
            }
            else
            {
                Label SearchAnswer = new Label();
                SearchAnswer.Text = "К сожалению, по вашему запросу ничего не найдено";
                SearchAnswer.AutoSize = true;
                SearchAnswer.Location = new Point(4, 55);
                pResultOfSearch.Controls.Add(SearchAnswer);
            }            
            con.Close();
        }
        public void LinkLabelClick(object sender, EventArgs e)
        {
            FormForFilm form = new FormForFilm();
        }
        private void llAuthorization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AutorizationForm f2 = new AutorizationForm();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                llRegistration.Visible = false;
                llAuthorization.Visible = false;
                llMyPage.Text = f2.Login;
                user = f2.User;
                lAutoriz.Visible = true;
                llMyPage.Visible = true;
                llExit.Visible = true;               
            }

        }

        private void llRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm f2 = new RegistrationForm();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                f2.Close();
                user = new User(f2.Login, f2.Password, f2.Email, f2.Gen, f2.Birthday, f2.Birthplace);
                llRegistration.Visible = false;
                llAuthorization.Visible = false;
                llMyPage.Text = f2.Login;
                lAutoriz.Visible = true;
                llMyPage.Visible = true;
                llExit.Visible = true;
            }
        }

        private void llExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            user = new User();
            llRegistration.Visible = true;
            llAuthorization.Visible = true;
            lAutoriz.Visible = false;
            llMyPage.Visible = false;
            llExit.Visible = false;
        }

        private void llMyPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForUser form = new FormForUser(user);
            form.Show();
        }
        
       
    }
}
