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

namespace KFC_RMS.Forms.Items
{
    public partial class ItemSelectionUI : Form
    {
        public ItemSelectionUI()
        {
            InitializeComponent();
        }
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aConnectionString = new ConnectionString();
        private void reset()
        {
            txtItemNo.Text = string.Empty;
            comboCategory.Text = string.Empty;
            txtName.Text = string.Empty;
            txtItems.Text = string.Empty;
            txtPrice.Text = string.Empty;
            
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        private void ItemSelectionUI_Load(object sender, EventArgs e)
        {
            reset();
            txtId.Hide();
            txtItemNo.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Item No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemNo.Focus();
                return;
            }
            if (comboCategory.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Category ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboCategory.Focus();
                return;
            }
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtItems.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItems.Focus();
                return;
            }
            if (txtPrice.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string check = "SELECT ItemNo,Name FROM  tbl_ItemSelection WHERE ItemNo='" +
                               txtItemNo.Text + "' OR Name='" + txtName.Text + "' ";

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

                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string insert = "INSERT INTO tbl_ItemSelection(ItemNo,Category,Name,Items,Price) VALUES(@d1,@d2,@d3,@d4,@d5)";
                command = new SqlCommand(insert, connection);
                command.Parameters.AddWithValue("@d1", txtItemNo.Text);
                command.Parameters.AddWithValue("@d2", comboCategory.Text);
                command.Parameters.AddWithValue("@d3", txtName.Text);
                command.Parameters.AddWithValue("@d4", txtItems.Text);
                command.Parameters.AddWithValue("@d5", txtPrice.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data Saved Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string update = "UPDATE tbl_ItemSelection SET Name=@d1,Items=@d2,Price=@d3 WHERE Id=@d4 ";
                command = new SqlCommand(update, connection);
                command.Parameters.AddWithValue("@d1", txtName.Text);
                command.Parameters.AddWithValue("@d2", txtItems.Text);
                command.Parameters.AddWithValue("@d3", txtPrice.Text);
                command.Parameters.AddWithValue("@d4", txtId.Text);
                reader = command.ExecuteReader();
                connection.Close();
                MessageBox.Show("Data Updated Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    connection = new SqlConnection(aConnectionString.DBConn);
                    connection.Open();
                    string delete = "DELETE FROM tbl_ItemSelection WHERE Id=@d1 ";
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSelectionRecordUI aUi = new ItemSelectionRecordUI();
            aUi.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
