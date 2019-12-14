using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kinopoisk
{
    public partial class FormForFilm : Form
    {
        Film film;
        User user;
        public FormForFilm()
        {
            InitializeComponent();
        }
        public FormForFilm(Film f, User u)
        {
            InitializeComponent();
            film = f;
            user = u;
        }
        public FormForFilm(Film f)
        {
            InitializeComponent();
            film = f;           
        }
    }
}
