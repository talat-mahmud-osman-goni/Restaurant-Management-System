using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KFC_RMS.Forms.Expenditure;

namespace KFC_RMS.Forms.Report
{
    public partial class ExpenditureRecordUI : Form
    {
        public ExpenditureRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aConnectionString = new ConnectionString();
        private void ExpenditureRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string load = "SELECT * FROM tbl_Expenditure";
                command = new SqlCommand(load, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgExpenditureRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
           
        }

        private void dgExpenditureRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow adgvr = dgExpenditureRecord.SelectedRows[0];
                this.Hide();
                ExpenditureUI aExpenditureUi = new ExpenditureUI();
                aExpenditureUi.Show();
                aExpenditureUi.txtId.Text = adgvr.Cells[0].Value.ToString();
                aExpenditureUi.txtName.Text = adgvr.Cells[1].Value.ToString();
                aExpenditureUi.txtRemarks.Text = adgvr.Cells[2].Value.ToString();
                aExpenditureUi.txtAmount.Text = adgvr.Cells[3].Value.ToString();
                aExpenditureUi.DateTimePlickerDate.Text = adgvr.Cells[4].Value.ToString();
                aExpenditureUi.btnDelete.Enabled = true;
                aExpenditureUi.btnUpdate.Enabled = true;
                aExpenditureUi.btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ExpenditureRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExpenditureUI a = new ExpenditureUI();
            a.Show();
        }
    }
}
