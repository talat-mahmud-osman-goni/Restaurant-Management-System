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

namespace KFC_RMS.Forms.Category
{
    public partial class CategorySelectionUI : Form
    {
        public CategorySelectionUI()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Reset()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtCatagoryName.Text = string.Empty;

        }
        private SqlConnection con = null;
        private ConnectionString cs = new ConnectionString();
        private SqlCommand comm = null;
        private SqlDataReader reader = null;

        private void CategorySelectionUI_Load(object sender, EventArgs e)
        {
            Reset();
            txtId.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string check = "SELECT Name FROM tbl_Category WHERE Name='" + txtCatagoryName.Text + "'";
                comm = new SqlCommand(check, con);
                reader = comm.ExecuteReader();
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
                string update = "UPDATE tbl_Category SET Name='" + txtCatagoryName.Text + "' WHERE Id='" + txtId.Text + "'";

                comm = new SqlCommand(update, con);
                reader = comm.ExecuteReader();
                MessageBox.Show("Data Updated Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do You Really Want to Delete This Record?", "Confirmation",
                                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            try
            {
                if (dialog == System.Windows.Forms.DialogResult.Yes)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string delete = "DELETE FROM tbl_Category WHERE Id='" + txtId.Text + "'";
                    comm = new SqlCommand(delete, con);
                    comm.ExecuteReader();
                    con.Close();
                    Reset();
                    MessageBox.Show("Data Deleted Successfully", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                }
                else if (dialog == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("Data is not Deleted", "Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;

                }
                else
                {
                    MessageBox.Show("Data Modification Cancled", "Informatiom", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            
            if (txtCatagoryName.Text == string.Empty)
            {
                MessageBox.Show("Pleasr Enter Category Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCatagoryName.Focus();
                return;
            }



            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string check = "SELECT Name FROM tbl_Category WHERE Name='" + txtCatagoryName.Text + "'";
                comm = new SqlCommand(check, con);
                reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Category is already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (reader != null)
                {
                    reader.Close();
                }
                con.Close();


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string Insert = "INSERT INTO tbl_Category(Name) VALUES(@d2)";
                comm = new SqlCommand(Insert, con);
                comm.Connection = con;
               // comm.Parameters.AddWithValue("@d1", txtId.Text);
                comm.Parameters.AddWithValue("@d2", txtCatagoryName.Text);
                comm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved Successfully", "RECORD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            CategoryRecordUI a = new CategoryRecordUI();
            a.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
