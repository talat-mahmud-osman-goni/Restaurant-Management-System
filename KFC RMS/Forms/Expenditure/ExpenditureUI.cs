using KFC_RMS.Forms.Report;
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

namespace KFC_RMS.Forms.Expenditure
{
    public partial class ExpenditureUI : Form
    {
        public ExpenditureUI()
        {
            InitializeComponent();
        }
        private void ExpenditureUI_Load(object sender, EventArgs e)
        {
            reset();
            txtId.Hide();
        }

        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aConnectionString=new ConnectionString();
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
        }

        private void reset()
        {
            txtName.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtAmount.Text = string.Empty;
            DateTimePlickerDate.Text = string.Empty;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        
        private void btnSave_Click_1(object sender, EventArgs e)
        {
             
            if(txtName.Text==string.Empty)
            {
                MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtRemarks.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Remarks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRemarks.Focus();
                return;
            }
            if (txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }
            try
            {
                
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string check = "SELECT Name,Remarks,Amount,Date FROM tbl_Expenditure WHERE Name='" + txtName.Text + "'AND Remarks='" + txtRemarks.Text + "' AND Amount='" +
                               txtAmount.Text + "'AND Date='" + DateTimePlickerDate.Text +
                               "'";
                command=new SqlCommand(check,connection);
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    MessageBox.Show("Data Already Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(reader!=null)
                {
                    reader.Close();
                    
                }
                connection.Close();

                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string insert = "INSERT INTO tbl_Expenditure(Name,Remarks,Amount,Date) VALUES(@d1,@d2,@d3,@d4)";
                command = new SqlCommand(insert, connection);
                command.Parameters.AddWithValue("@d1", txtName.Text);
                command.Parameters.AddWithValue("@d2", txtRemarks.Text);
                command.Parameters.AddWithValue("@d3", txtAmount.Text);
                command.Parameters.AddWithValue("@d4", DateTimePlickerDate.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data Saved Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
             reset();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ExpenditureRecordUI aUi=new ExpenditureRecordUI();
            aUi.Show();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string check = "SELECT Name,Remarks,Amount,Date FROM tbl_Expenditure WHERE Name='" + txtName.Text + "'AND Remarks='" + txtRemarks.Text + "' AND Amount='" +
                               txtAmount.Text + "'AND Date='" + DateTimePlickerDate.Text +
                               "'";
                command = new SqlCommand(check, connection);
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
                connection.Close();


                connection.Open();
                string update = "UPDATE tbl_Expenditure SET Remarks='" + txtRemarks.Text + "',Amount='" + txtAmount.Text +
                                "' WHERE Id='" + txtId.Text + "'";
                command=new SqlCommand(update,connection);
                reader = command.ExecuteReader();
                connection.Close();
                MessageBox.Show("Data Updated Successfully", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
             try
            {
                DialogResult dialog = MessageBox.Show("Do You Really Want to Delete This Record?", "Confirmation",
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(dialog==System.Windows.Forms.DialogResult.Yes)
                {
                    connection = new SqlConnection(aConnectionString.DBConn);
                    connection.Open();
                    string delete = "DELETE FROM tbl_Expenditure WHERE Id=@d1";
                    command = new SqlCommand(delete, connection);
                    command.Parameters.AddWithValue("@d1", txtId.Text);
                    command.ExecuteReader();
                    connection.Close();
                    MessageBox.Show("Data Delete Successfully", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    reset(); 
                }
                else if(dialog==System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("Data Didn't Deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Modification Cancled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }

       

     
    

