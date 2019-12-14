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
    public partial class AddCheck : Form
    {
        DataTable checkTable;
        public AddCheck(DataTable checkTable)
        {
            InitializeComponent();
            this.checkTable = checkTable;
        }

        private void add_Click(object sender, EventArgs e)
        {
            DataRow dataRow = checkTable.NewRow();
            dataRow["conclusionDate"] = DateTime.Parse(conclusionDate.Text);
            dataRow["travelAgentName"] = travelAgentName.Text;
            dataRow["customerName"] = customerName.Text;
            dataRow["orderCost"] = Decimal.Parse(orderCost.Text);
            checkTable.Rows.Add(dataRow);
        }
    }
}
