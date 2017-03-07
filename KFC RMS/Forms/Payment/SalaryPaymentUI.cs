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

namespace KFC_RMS.Forms.Payment
{
    public partial class SalaryPaymentUI : Form
    {
        public SalaryPaymentUI()
        {
            InitializeComponent();
        }
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aConnectionString = new ConnectionString();
        private void reset()
        {
            comboName.Text = string.Empty;
            comboDesignation.Text = string.Empty;
            txtJoiningDate.Text = string.Empty;
            txtBasicSalary.Text = string.Empty;
            txtBonus.Text = string.Empty;
            txtGrossSalary.Text = string.Empty;
            txtPayingBy.Text = string.Empty;
            txtPayingToAcc.Text = string.Empty;
            txtBankName.Text = string.Empty;
            comboGender.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtDate.Text = string.Empty;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }
        private void SalaryPaymentUI_Load(object sender, EventArgs e)
        {
            reset();
            txtId.Hide();
            comboName.Items.Clear();
            connection = new SqlConnection(aConnectionString.DBConn);
            connection.Open();
            string load = "SELECT Name FROM tbl_staffInform";
            command = new SqlCommand(load, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboName.Items.Add(reader[0]);
            }
            connection.Close();
        }

       

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (comboName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboName.Focus();
                return;
            }
            if (comboDesignation.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboDesignation.Focus();
                return;
            }
            if (txtJoiningDate.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Joining Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJoiningDate.Focus();
                return;
            }
            if (txtBasicSalary.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Basic Salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBasicSalary.Focus();
                return;
            }
            if (txtBonus.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bonus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBonus.Focus();
                return;
            }
            if (txtGrossSalary.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Gross Salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGrossSalary.Focus();
                return;
            }
            if (txtPayingBy.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Paying By", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPayingBy.Focus();
                return;
            }
            if (txtPayingToAcc.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Paying To Acc No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPayingToAcc.Focus();
                return;
            }
            if (txtBankName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bank Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankName.Focus();
                return;
            }
            if (comboGender.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboGender.Focus();
                return;
            }
            if (txtMonth.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonth.Focus();
                return;
            }
            if (txtDate.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDate.Focus();
                return;
            }

            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string check = "SELECT Name,Month FROM tbl_Salary_Payment WHERE Name='" + comboName.Text + "'AND Month='" + txtMonth.Text + "' ";
                command = new SqlCommand(check, connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Data already Exists", "Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                connection.Close();
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();

                connection.Close();


                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string insert =
                    "INSERT INTO tbl_Salary_Payment(Name,Designation,JoiningDate,BasicSalary,Bonus,GrossSalary,PayingBy,PayingToAccNo,BankName,Gender,Month,Date) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12) ";
                command = new SqlCommand(insert, connection);
                command.Parameters.AddWithValue("@d1", comboName.Text);
                command.Parameters.AddWithValue("@d2", comboDesignation.Text);
                command.Parameters.AddWithValue("@d3", txtJoiningDate.Text);
                command.Parameters.AddWithValue("@d4", txtBasicSalary.Text);
                command.Parameters.AddWithValue("@d5", txtBonus.Text);
                command.Parameters.AddWithValue("@d6", txtGrossSalary.Text);
                command.Parameters.AddWithValue("@d7", txtPayingBy.Text);
                command.Parameters.AddWithValue("@d8", txtPayingToAcc.Text);
                command.Parameters.AddWithValue("@d9", txtBankName.Text);
                command.Parameters.AddWithValue("@d10", comboGender.Text);
                command.Parameters.AddWithValue("@d11", txtMonth.Text);
                command.Parameters.AddWithValue("@d12", txtDate.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data Saved Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            reset();

        }

        private void btnGetData_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SalaryPaymentRecordUI aUi = new SalaryPaymentRecordUI();
            aUi.Show();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want to Delete this Record?", "Confirmation",
                                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    connection = new SqlConnection(aConnectionString.DBConn);
                    connection.Open();
                    string delete = "DELETE FROM tbl_Salary_Payment WHERE id=@d1 ";
                    command = new SqlCommand(delete, connection);
                    command.Parameters.AddWithValue("@d1", txtId.Text);
                    command.ExecuteReader();
                    connection.Close();
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                //connection.Open();
                //string check = "SELECT Name,Month FROM tbl_Salary_Payment WHERE Name=@d1 AND Month=@d2";
                //command = new SqlCommand(check, connection);

                //command.Parameters.AddWithValue("@d1", comboName.Text);
                //command.Parameters.AddWithValue("@d2", txtMonth.Text);
                //reader = command.ExecuteReader();
                //if (reader.Read())
                //{
                //    MessageBox.Show("Data Already Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;

                //}
                //if (reader != null)
                //{
                //    reader.Close();
                //}
                //connection.Close();


                connection.Open();
                string update =
                    " UPDATE tbl_Salary_Payment SET BasicSalary=@d3,Bonus=@d4,GrossSalary=@d5,PayingBy=@d6,PayingToAccNo=@d7,BankName=@d8 WHERE id=@d9 ";
                command = new SqlCommand(update, connection);
                command.Parameters.AddWithValue("@d3", txtBasicSalary.Text);
                command.Parameters.AddWithValue("@d4", txtBonus.Text);
                command.Parameters.AddWithValue("@d5", txtGrossSalary.Text);
                command.Parameters.AddWithValue("@d6", txtPayingBy.Text);
                command.Parameters.AddWithValue("@d7", txtPayingToAcc.Text);
                command.Parameters.AddWithValue("@d8", txtBankName.Text);
                command.Parameters.AddWithValue("@d9", txtId.Text);
                reader = command.ExecuteReader();
                connection.Close();
                MessageBox.Show("Data Updated Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
