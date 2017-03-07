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
using KFC_RMS.Forms.Company;

namespace KFC_RMS.Forms.Report
{
    public partial class CompanyRecordUI : Form
    {
        public CompanyRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private void CompanyRecordUI_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string loadAll =
                    "SELECT Id, Name, ContactPerson, ContactNo, AltContactNo, Address, Email FROM tblCompany";
                command = new SqlCommand(loadAll, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgCompanyRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgCompanyRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                this.Hide();
                DataGridViewRow dr = dgCompanyRecord.SelectedRows[0];
                CompanyInfoUI aCompanyInformationUi = new CompanyInfoUI();
                aCompanyInformationUi.Show();
                aCompanyInformationUi.txtiD.Text = dr.Cells[0].Value.ToString();
                aCompanyInformationUi.txtName.Text = dr.Cells[1].Value.ToString();
                aCompanyInformationUi.txtContactPerson.Text = dr.Cells[2].Value.ToString();
                aCompanyInformationUi.txtContactNo.Text = dr.Cells[3].Value.ToString();
                aCompanyInformationUi.txtAltrContactNo.Text = dr.Cells[4].Value.ToString();
                aCompanyInformationUi.txtAddress.Text = dr.Cells[5].Value.ToString();
                aCompanyInformationUi.txtEmail.Text = dr.Cells[6].Value.ToString();
                aCompanyInformationUi.btnDelete.Enabled = true;
                aCompanyInformationUi.btnUpdate.Enabled = true;
                aCompanyInformationUi.btnSave.Enabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompanyRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompanyInfoUI aCompanyInformationUi = new CompanyInfoUI();
            aCompanyInformationUi.Show();
        }
    }
}
