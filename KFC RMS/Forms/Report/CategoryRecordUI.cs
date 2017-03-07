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
using KFC_RMS.Forms.Category;

namespace KFC_RMS.Forms.Report
{
    public partial class CategoryRecordUI : Form
    {
        public CategoryRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString aConnectionString = new ConnectionString();
        private void CategoryRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(aConnectionString.DBConn);
                connection.Open();
                string CategoryLoad = "SELECT * FROM tbl_Category";
                command = new SqlCommand(CategoryLoad, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgCategoryRecord.Rows.Add(reader[0], reader[1]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgCategoryRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow aRow = dgCategoryRecord.SelectedRows[0];
                this.Hide();
                CategorySelectionUI aCategorySelectionUi = new CategorySelectionUI();
                aCategorySelectionUi.Show();
                aCategorySelectionUi.txtId.Text = aRow.Cells[0].Value.ToString();
                aCategorySelectionUi.txtCatagoryName.Text = aRow.Cells[1].Value.ToString();
                aCategorySelectionUi.btnDelete.Enabled = true;
                aCategorySelectionUi.btnUpdate.Enabled = true;
                aCategorySelectionUi.btnSave.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            CategorySelectionUI aUi = new CategorySelectionUI();
            aUi.Show();
        }
    }
}
