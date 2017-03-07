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

namespace KFC_RMS.Forms.Company
{
    public partial class CompanyInfoUI : Form
    {
        public CompanyInfoUI()
        {
            InitializeComponent();
        }

        private void CompanyInfoUI_Load(object sender, EventArgs e)
        {
            txtiD.Hide();
            reset();
        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private void reset()
        {
            txtName.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtAltrContactNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtContactPerson.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Contact Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactPerson.Focus();
                return;
            }
            if (txtContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Contact No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
            if (txtAltrContactNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Alt Contact No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAltrContactNo.Focus();
                return;
            }
            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string check = "SELECT * FROM tblCompany WHERE Name='" + txtName.Text + "' AND ContactNo='" +
                               txtContactNo.Text + "'";
                command = new SqlCommand(check, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("This information is already exists", "Record", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();

                //string insert = "INSERT INTO tblCompany(Name,ContactPerson,ContactNo,AltContactNo,Address,Email) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";

                //command = new SqlCommand(insert, con);
                //command.Parameters.AddWithValue("@d1", txtName.Text);
                //command.Parameters.AddWithValue("@d2", txtContactPerson.Text);

                //command.Parameters.AddWithValue("@d3", txtContactNo.Text);
                //command.Parameters.AddWithValue("@d4", txtAltrContactNo.Text);

                //command.Parameters.AddWithValue("@d5", txtAddress.Text);
                //command.Parameters.AddWithValue("@d6", txtEmail.Text);


                string insert2 =
                    "INSERT INTO tblCompany(Name,ContactPerson,ContactNo,AltContactNo,Address,Email) VALUES('" +
                    txtName.Text + "','" + txtContactPerson.Text + "','" + txtContactNo.Text + "','" +
                    txtAltrContactNo.Text + "','" + txtAddress.Text + "','" + txtEmail.Text + "')";
                command = new SqlCommand(insert2, con);
                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string update = "UPDATE tblCompany SET Name='" + txtName.Text + "',ContactPerson='" +
                //                txtContactPerson.Text + "',ContactNo='" + txtContactNo.Text + "' WHERE Id='" + txtiD.Text + "'";
                string update = "UPDATE tblCompany SET Name=@d2,ContactPerson=@d3,ContactNo=@d4 WHERE Id=@d1";

                command = new SqlCommand(update, con);
                command.Parameters.AddWithValue("@d2", txtName.Text);
                command.Parameters.AddWithValue("@d3", txtContactPerson.Text);
                command.Parameters.AddWithValue("@d4", txtContactNo.Text);
                command.Parameters.AddWithValue("@d1", txtiD.Text);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Data updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (reader != null)
                {
                    reader.Close();
                }
                con.Close();

                btnUpdate.Enabled = false;
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
                if (MessageBox.Show("Do you Really wantto delete this record?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string delete = "DELETE FROM tblCompany WHERE Id='" + txtiD.Text + "'";
                    command = new SqlCommand(delete, con);
                    command.ExecuteReader();
                    MessageBox.Show("Data deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    reset();
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    con.Close();
                }

                else if (MessageBox.Show("Do you Really wantto delete this record?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                {

                    MessageBox.Show("modifying cancelled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    reset();
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
            CompanyRecordUI aUi = new CompanyRecordUI();
            aUi.Show();
           
        }
    }
}
