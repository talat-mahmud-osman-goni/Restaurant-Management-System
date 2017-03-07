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
using KFC_RMS.Forms.Payment;

namespace KFC_RMS.Forms.Report
{
    public partial class SalaryPaymentRecordUI : Form
    {
        public SalaryPaymentRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aConnectionString = new ConnectionString();
        private void SalaryPaymentRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string load = "SELECT * FROM tbl_Salary_Payment";
                command = new SqlCommand(load, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgSalaryPaymentRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5],
                                                   reader[6], reader[7], reader[8], reader[9], reader[10], reader[11],
                                                   reader[12]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
           
        }

        private void dgSalaryPaymentRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow aDataGridViewRow = dgSalaryPaymentRecord.SelectedRows[0];
                this.Hide();
                SalaryPaymentUI aUi = new SalaryPaymentUI();
                aUi.Show();
                aUi.txtId.Text = aDataGridViewRow.Cells[0].Value.ToString();
                aUi.comboName.Text = aDataGridViewRow.Cells[1].Value.ToString();
                aUi.comboDesignation.Text = aDataGridViewRow.Cells[2].Value.ToString();
                aUi.txtJoiningDate.Text = aDataGridViewRow.Cells[3].Value.ToString();
                aUi.txtBasicSalary.Text = aDataGridViewRow.Cells[4].Value.ToString();
                aUi.txtBonus.Text = aDataGridViewRow.Cells[5].Value.ToString();
                aUi.txtGrossSalary.Text = aDataGridViewRow.Cells[6].Value.ToString();
                aUi.txtPayingBy.Text = aDataGridViewRow.Cells[7].Value.ToString();
                aUi.txtPayingToAcc.Text = aDataGridViewRow.Cells[8].Value.ToString();
                aUi.txtBankName.Text = aDataGridViewRow.Cells[9].Value.ToString();
                aUi.comboGender.Text = aDataGridViewRow.Cells[10].Value.ToString();
                aUi.txtMonth.Text = aDataGridViewRow.Cells[11].Value.ToString();
                aUi.txtDate.Text = aDataGridViewRow.Cells[12].Value.ToString();
                aUi.btnDelete.Enabled = true;
                aUi.btnUpdate.Enabled = true;
                aUi.btnSave.Enabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SalaryPaymentRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalaryPaymentUI aUi = new SalaryPaymentUI();
            aUi.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
