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
using KFC_RMS.Forms.Client;

namespace KFC_RMS.Forms.Report
{
    public partial class ClientRecordUI : Form
    {
        public ClientRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private void ClientRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string load = string.Format("SELECT * FROM tblClient");
                command = new SqlCommand(load, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgClientRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgClientRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgClientRecord.SelectedRows[0];
                this.Hide();
                ClientInfoUI aInformationUi = new ClientInfoUI();
                aInformationUi.Show();
                aInformationUi.txtId.Text = dr.Cells[0].Value.ToString();
                aInformationUi.txtName.Text = dr.Cells[1].Value.ToString();
                aInformationUi.txtContactNo.Text = dr.Cells[2].Value.ToString();
                aInformationUi.txtAltContactNo.Text = dr.Cells[3].Value.ToString();
                aInformationUi.txtEmail.Text = dr.Cells[4].Value.ToString();
                aInformationUi.txtAddress.Text = dr.Cells[5].Value.ToString();
                aInformationUi.btnSave.Enabled = false;
                aInformationUi.btnUpdate.Enabled = true;
                aInformationUi.btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ClientRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientInfoUI aUi = new ClientInfoUI();
            aUi.Show();
        }
    }
}
