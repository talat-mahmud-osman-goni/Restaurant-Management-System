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
using KFC_RMS.Forms.Staff;

namespace KFC_RMS.Forms.Report
{
    public partial class StaffRecordUI : Form
    {
        public StaffRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aS = new ConnectionString();
        private void StaffRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aS.DBConn);
                connection.Open();
                string load = "SELECT * FROM tbl_staffInform";
                command = new SqlCommand(load, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgStaffInfoRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6],
                                               reader[7], reader[8], reader[9], reader[10], reader[11], reader[12],
                                               reader[13], reader[14], reader[15]);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgStaffInfoRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgStaffInfoRecord.SelectedRows[0];
                this.Hide();
                StaffInfoUI aUi = new StaffInfoUI();
                aUi.Show();
                aUi.txtId.Text = dr.Cells[0].Value.ToString();
                aUi.txtName.Text = dr.Cells[1].Value.ToString();
                aUi.txtFatherName.Text = dr.Cells[2].Value.ToString();
                aUi.txtMotherName.Text = dr.Cells[3].Value.ToString();
                aUi.txtPresentAddress.Text = dr.Cells[4].Value.ToString();
                aUi.txtPermanentAddress.Text = dr.Cells[5].Value.ToString();
                aUi.txtDesignation.Text = dr.Cells[6].Value.ToString();
                aUi.dateTimePickerJoiningDate.Text = dr.Cells[7].Value.ToString();
                aUi.txtBasicSalary.Text = dr.Cells[8].Value.ToString();
                aUi.txtBankName.Text = dr.Cells[9].Value.ToString();
                aUi.txtAccNo.Text = dr.Cells[10].Value.ToString();
                aUi.comboGender.Text = dr.Cells[11].Value.ToString();
                aUi.comboReligion.Text = dr.Cells[12].Value.ToString();
                aUi.dateTimePickerBirth.Text = dr.Cells[13].Value.ToString();
                aUi.txtMobileNo.Text = dr.Cells[14].Value.ToString();
                aUi.txtGuardianMobNo.Text = dr.Cells[15].Value.ToString();
                aUi.btnDelete.Enabled = true;
                aUi.btnUpdate.Enabled = true;
                aUi.btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void StaffRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            StaffInfoUI aUi = new StaffInfoUI();
            aUi.Show();
        }
    }
}
