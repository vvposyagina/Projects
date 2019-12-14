using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            checkView.DataSource = checkDataSet.Tables["check"];
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddCheck addCheck = new AddCheck(checkDataSet.Tables["check"]);
            addCheck.ShowDialog();
        }

        private void addInfo_Click(object sender, EventArgs e)
        {
            int selectedID = Int32.Parse(checkView.Rows[checkView.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            AddInfoCheck addInfoCheck = new AddInfoCheck(checkDataSet.Tables["checkInfo"], checkDataSet.Tables["check"].Rows.Find(selectedID));
            addInfoCheck.ShowDialog();
        }
    }
}
