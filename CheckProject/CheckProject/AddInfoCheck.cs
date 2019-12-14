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
    public partial class AddInfoCheck : Form
    {
        DataRow checkRow;
        DataTable checkInfoTable;
        public AddInfoCheck(DataTable checkInfoTable, DataRow checkRow)
        {
            InitializeComponent();
            this.checkInfoTable = checkInfoTable;
            this.checkRow = checkRow;
            //checkInfoView.DataSource = checkInfoTable;
            foreach(DataColumn dataColumn in checkInfoTable.Columns)
            {
                if(dataColumn.ColumnName != "idCheck" && dataColumn.ColumnName != "id")
                {
                    checkInfoView.Columns.Add(dataColumn.ColumnName, dataColumn.Caption);
                }
            }
            checkInfoView.Rows.Add(checkRow.GetChildRows("CheckToCheckInfo"));
        }

        private void add_Click(object sender, EventArgs e)
        {
            DataRow checkInfoRow = checkInfoTable.NewRow();
            checkInfoRow.SetParentRow(checkRow);
            checkInfoRow["idCheck"] = checkRow["id"];
            checkInfoRow["departureDate"] = DateTime.Parse(departureDate.Text);
            checkInfoRow["arrivalDate"] = DateTime.Parse(arrivalDate.Text);
            checkInfoRow["tourPrice"] = Decimal.Parse(tourPrice.Text);
            checkInfoRow["customerName"] = customerName.Text;
            checkInfoTable.Rows.Add(checkInfoRow);
            checkInfoView.Rows.Clear();
            checkInfoView.Rows.Add(checkRow.GetChildRows("CheckToCheckInfo"));
        }
    }
}
