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

namespace KFC_RMS.Forms.Staff
{
    public partial class StaffInfoUI : Form
    {
        public StaffInfoUI()
        {
            InitializeComponent();
        }
        private void reset()
        {
            txtName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtPresentAddress.Text = string.Empty;
            txtPermanentAddress.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            dateTimePickerJoiningDate.Text = string.Empty;
            txtBasicSalary.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtAccNo.Text = string.Empty;
            comboGender.Text = string.Empty;
            comboReligion.Text = string.Empty;
            dateTimePickerBirth.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtGuardianMobNo.Text = string.Empty;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private void StaffInfoUI_Load(object sender, EventArgs e)
        {
            reset();
            txtId.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtFatherName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Father's Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFatherName.Focus();
                return;
            }
            if (txtMotherName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Mother's Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotherName.Focus();
                return;
            }
            if (txtPresentAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Present Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPresentAddress.Focus();
                return;
            }
            if (txtPermanentAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Permanent Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPermanentAddress.Focus();
                return;
            }
            if (txtDesignation.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDesignation.Focus();
                return;
            }
            if (dateTimePickerJoiningDate.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Joining Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerJoiningDate.Focus();
                return;
            }
            if (txtBasicSalary.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Basic Salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBasicSalary.Focus();
                return;
            }

            if (txtBankName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bank Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankName.Focus();
                return;
            }
            if (txtAccNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Acc No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccNo.Focus();
                return;
            }
            if (comboGender.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGender.Focus();
                return;
            }
            if (comboReligion.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Religion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboReligion.Focus();
                return;
            }
            if (dateTimePickerBirth.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Date of Birth", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerBirth.Focus();
                return;
            }
            if (txtMobileNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Mobile No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
                return;
            }
            if (txtGuardianMobNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Guardian Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGuardianMobNo.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string check = "SELECT Name,Designation FROM tbl_staffInform WHERE Name='" + txtName.Text +
                               "' AND Designation='" + txtDesignation.Text + "' ";
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


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insert =
                    "INSERT INTO tbl_staffInform(Name,Father,Mother,PreAddress,PerAddress,Designation,JoiningDate,BasicSalary,BankName,AccNo,Gender,Religion,DateOfBirth,MobileNo,GuardianMobileNo) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15) ";
                command = new SqlCommand(insert, con);

                command.Parameters.AddWithValue("@d1", txtName.Text);
                command.Parameters.AddWithValue("@d2", txtFatherName.Text);
                command.Parameters.AddWithValue("@d3", txtMotherName.Text);
                command.Parameters.AddWithValue("@d4", txtPresentAddress.Text);
                command.Parameters.AddWithValue("@d5", txtPermanentAddress.Text);
                command.Parameters.AddWithValue("@d6", txtDesignation.Text);

                command.Parameters.AddWithValue("@d7", dateTimePickerJoiningDate.Text);
                command.Parameters.AddWithValue("@d8", txtBasicSalary.Text);
                command.Parameters.AddWithValue("@d9", txtBankName.Text);
                command.Parameters.AddWithValue("@d10", txtAccNo.Text);
                command.Parameters.AddWithValue("@d11", comboGender.Text);
                command.Parameters.AddWithValue("@d12", comboReligion.Text);
                command.Parameters.AddWithValue("@d13", dateTimePickerBirth.Text);
                command.Parameters.AddWithValue("@d14", txtMobileNo.Text);
                command.Parameters.AddWithValue("@d15", txtGuardianMobNo.Text);

                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("data save ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                string update = "UPDATE tbl_staffInform SET PreAddress='" + txtPresentAddress.Text + "',Designation='" + txtDesignation.Text +
                                "',BasicSalary='" + txtBasicSalary.Text + "',MobileNo='" + txtMobileNo.Text + "' WHERE Id='" + txtId.Text + "'";
                command = new SqlCommand(update, con);
                reader = command.ExecuteReader();
                con.Close();
                MessageBox.Show("Data Updated Successfully", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want to Delete this Record?", "Confirmation",
                                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string delete = "DELETE FROM tbl_staffInform WHERE Id=@d1 ";
                    command = new SqlCommand(delete, con);
                    command.Parameters.AddWithValue("@d1", txtId.Text);
                    command.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Data Deleted Successfully", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    reset();
                }
                else if (dialog == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("Data Didn't Deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Modification Cancled", "Warnng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffRecordUI aUi = new StaffRecordUI();
            aUi.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
