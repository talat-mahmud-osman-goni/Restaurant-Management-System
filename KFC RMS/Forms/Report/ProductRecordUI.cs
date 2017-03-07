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
using KFC_RMS.Forms.Product;

namespace KFC_RMS.Forms.Report
{
    public partial class ProductRecordUI : Form
    {
        public ProductRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private void ProductRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string loadAll = "SELECT Id as 'Serial No',CategoryName as 'Category',ProductName as 'Product Name',Price FROM  tbl_Product_Info";
                command = new SqlCommand(loadAll, con);
                reader = command.ExecuteReader();
                while (reader.Read() == true)
                {
                    dgProductInfoRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgProductInfoRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow aDataGridViewRow = dgProductInfoRecord.SelectedRows[0];
                this.Hide();
                ProductInfoUI aUi = new ProductInfoUI();
                aUi.Show();
                aUi.txtId.Text = aDataGridViewRow.Cells[0].Value.ToString();
                aUi.comboCatagoryName.Text = aDataGridViewRow.Cells[1].Value.ToString();
                aUi.comboProductName.Text = aDataGridViewRow.Cells[2].Value.ToString();
                aUi.txtPrice.Text = aDataGridViewRow.Cells[3].Value.ToString();
                aUi.btnDelete.Enabled = true;
                aUi.btnUpdate.Enabled = true;
                aUi.btnSave.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void ProductRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProductInfoUI aUi = new ProductInfoUI();
            aUi.Show();
        }
    }
}
