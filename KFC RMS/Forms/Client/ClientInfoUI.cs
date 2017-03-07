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
using KFC_RMS.Forms.Report;

namespace KFC_RMS.Forms.Client
{
    public partial class ClientInfoUI : Form
    {
        public ClientInfoUI()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtName.Text = null;
            txtContactNo.Clear();
            txtAltContactNo.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlDataReader reader = null;
        private SqlCommand command = null;

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please Insert Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please Insert Contact No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
            if (txtAltContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please Insert Alt Contact No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltContactNo.Focus();
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Please Insert Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Insert Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string check = "SELECT Name,Contact FROM tblClient WHERE Name='" + txtName.Text + "'AND Contact='" + txtContactNo.Text + "' ";
                command = new SqlCommand(check, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Data already exists", "Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (reader != null)
                {
                    reader.Close();
                }

                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insert =
                    "INSERT INTO tblClient(Name,Contact,AltContact,Email,Address) values('" + txtName.Text + "','" + txtContactNo.Text + "','" + txtAltContactNo.Text + "','" + txtEmail.Text + "','" + txtAddress.Text + "')";
                command = new SqlCommand(insert, con);
                //command.Parameters.AddWithValue("D1", txtName.Text);
                //command.Parameters.AddWithValue("D2", txtContactNo.Text);
                //command.Parameters.AddWithValue("D3", txtAltContactNo.Text);
                //command.Parameters.AddWithValue("D4", txtEmail.Text);
                //command.Parameters.AddWithValue("D5", txtAddress.Text);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string check = "SELECT Name,Contact FROM tblClient WHERE Name='" + txtName.Text + "'AND Contact='" +
                               txtContactNo.Text + "'";
                command = new SqlCommand(check, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Data Already Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                con.Close();
                con.Open();
                string update = "UPDATE tblClient SET Contact='" + txtContactNo.Text + "', AltContact='" +
                                txtAltContactNo.Text + "', Email='" + txtAltContactNo.Text + "', Address='" +
                                txtAddress.Text + "' WHERE Id='" + txtId.Text + "'";
                command = new SqlCommand(update, con);
                reader = command.ExecuteReader();
                con.Close();
                MessageBox.Show("Data Updated Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Do You Really Want to Delete This Record?", "Confirmation",
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string delete = "DELETE FROM tblClient WHERE Id=@d1";
                    command = new SqlCommand(delete, con);
                    command.Parameters.AddWithValue("@d1", txtId.Text);
                    command.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    Reset();
                }
                else if (dialog == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("Data Didn't Deleted", "Warning", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Modification Cancled", "Warning", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientRecordUI aRecordUi = new ClientRecordUI();
            aRecordUi.Show();
        }

        private void ClientInfoUI_Load_1(object sender, EventArgs e)
        {
            Reset();
            txtId.Hide();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
