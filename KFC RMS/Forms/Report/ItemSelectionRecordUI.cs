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
using KFC_RMS.Forms.Items;

namespace KFC_RMS.Forms.Report
{
    public partial class ItemSelectionRecordUI : Form
    {
        public ItemSelectionRecordUI()
        {
            InitializeComponent();
        }
        private SqlConnection con = null;
        ConnectionString cs = new ConnectionString();
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        private void ItemSelectionRecordUI_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string loadAll =
                    "SELECT Id, ItemNo, Category, Name, Items, Price FROM tbl_ItemSelection";
                command = new SqlCommand(loadAll, con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dgItemSelectionRecord.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgItemSelectionRecord_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                this.Hide();
                DataGridViewRow dr = dgItemSelectionRecord.SelectedRows[0];
                ItemSelectionUI aSelectionUi = new ItemSelectionUI();
                aSelectionUi.Show();
                aSelectionUi.txtId.Text = dr.Cells[0].Value.ToString();
                aSelectionUi.txtItemNo.Text = dr.Cells[1].Value.ToString();
                aSelectionUi.comboCategory.Text = dr.Cells[2].Value.ToString();
                aSelectionUi.txtName.Text = dr.Cells[3].Value.ToString();
                aSelectionUi.txtItems.Text = dr.Cells[4].Value.ToString();
                aSelectionUi.txtPrice.Text = dr.Cells[5].Value.ToString();

                aSelectionUi.btnDelete.Enabled = true;
                aSelectionUi.btnUpdate.Enabled = true;
                aSelectionUi.btnSave.Enabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ItemSelectionRecordUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            ItemSelectionUI aUi = new ItemSelectionUI();
            aUi.Show();
        }
    }
}
