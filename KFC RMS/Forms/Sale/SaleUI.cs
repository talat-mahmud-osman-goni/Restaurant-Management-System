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

namespace KFC_RMS.Forms.Sale
{
    public partial class SaleUI : Form
    {
        public SaleUI()
        {
            InitializeComponent();
        }

        private SqlConnection con = null;
        private SqlCommand command = null;
        private SqlDataReader reader = null;
        ConnectionString cs=new ConnectionString();
        public void Calculate()
        {
            try
            {
                double valueOne = 0;
                double valueTwo = 0;
                double valueThree = 0;
                double valueFour = 0;
                double valueFive = 0;

                if (txtVAT.Text != "")
                {
                    valueOne = Convert.ToDouble((Convert.ToDouble(txtSubTotal.Text)*Convert.ToDouble(txtVAT.Text))/100);
                    valueOne = Math.Round(valueOne, 2);
                    txtParcVAT.Text = valueOne.ToString();

                }
                if (txtDiscount.Text != "")
                {
                    valueTwo =
                        Convert.ToDouble(((Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txtParcVAT.Text))*
                                          Convert.ToDouble(txtDiscount.Text))/100);
                    valueTwo = Math.Round(valueTwo, 2);
                    txtPercDiscount.Text = valueTwo.ToString();
                }

                double.TryParse(txtSubTotal.Text, out valueOne);
                double.TryParse(txtParcVAT.Text, out valueTwo);
                double.TryParse(txtPercDiscount.Text, out valueThree);
                double.TryParse(txtGrandTotal.Text, out valueFour);
                double.TryParse(txtCash.Text, out valueFive);

                valueOne = Math.Round(valueOne, 2);
                valueTwo = Math.Round(valueTwo, 2);
                valueThree = Math.Round(valueThree, 2);

                valueFour = ((valueOne + valueTwo) - valueThree);
                txtGrandTotal.Text = valueFour.ToString();

                double I = valueFive - valueFour;
                I = Math.Round(I, 2);
                txtChange.Text = I.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double valueOne = 0;
                double valueTwo = 0;

                double.TryParse(txtUnitPrice.Text, out valueOne);
                double.TryParse(txtQuantity.Text, out valueTwo);
                valueOne = Math.Round(valueOne, 2);
                valueTwo = Math.Round(valueTwo, 2);
                double I = (valueOne*valueTwo);
                I = Math.Round(I, 2);

                txtTotalAmount.Text = I.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double valueOne = 0;
                double valueTwo = 0;

                double.TryParse(txtUnitPrice.Text, out valueOne);
                double.TryParse(txtQuantity.Text, out valueTwo);
                valueOne = Math.Round(valueOne, 2);
                valueTwo = Math.Round(valueTwo, 2);
                double I = (valueOne * valueTwo);
                I = Math.Round(I, 2);

                txtTotalAmount.Text = I.ToString();

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

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (comboOrderItemNo.Text=="")
            {
                MessageBox.Show("Please Select Order Item No", "Selection Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                comboOrderItemNo.Focus();
                return;
            }
            if (txtCategory.Text == "")
            {
                MessageBox.Show("Please Enter Category", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCategory.Focus();
                return;
            }
            if (txtItemName.Text == "")
            {
                MessageBox.Show("Please Enter Item No", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtItemName.Focus();
                return;
            }
            if (txtItemDetails.Text == "")
            {
                MessageBox.Show("Please Enter Item Details", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtItemDetails.Focus();
                return;
            }
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }
            if (txtUnitPrice.Text == "")
            {
                MessageBox.Show("Please Enter Unit Price", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUnitPrice.Focus();
                return;
            }
            
            ListViewItem aItem=new ListViewItem();
            aItem.SubItems.Add(comboOrderItemNo.Text);
            aItem.SubItems.Add(txtCategory.Text);
            aItem.SubItems.Add(txtItemName.Text);
            aItem.SubItems.Add(txtItemDetails.Text);
            aItem.SubItems.Add(txtQuantity.Text);
            aItem.SubItems.Add(txtUnitPrice.Text);
            aItem.SubItems.Add(txtTotalAmount.Text);

            listViewSale.Items.Add(aItem);
            subTotalCount();
            SoldEmpty();

            

        }

        

        public double subTotalCount()
        {
            int i = 0;
            int j = 0;
            double k = 0;
            i = 0;
            j = 0;
            k = 0;
            try
            {
                j = listViewSale.Items.Count;
                for ( i = 0; i <= j-1; i++)
                {
                    k = k + Convert.ToDouble(listViewSale.Items[i].SubItems[7].Text);
                    k = Math.Round(k, 2);
                }
                txtSubTotal.Text = k.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
            }
            return k;
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewSale_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtParcVAT_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtPercDiscount_TextChanged(object sender, EventArgs e)
        {
           Calculate();
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtBillNo.Text == "")
                {
                    MessageBox.Show("Please Enter Bill No.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBillNo.Focus();
                    return;
                }
                if (comboCurrency.Text == "")
                {
                    MessageBox.Show("Please Select Currency", "Selection Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    comboCurrency.Focus();
                    return;
                }
                if (txtSubTotal.Text == "")
                {
                    MessageBox.Show("Please Fill up Sub Total", "Input Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtSubTotal.Focus();
                    return;
                }
                if (txtVAT.Text == "")
                {
                    MessageBox.Show("Please Enter VAT", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVAT.Focus();
                    return;
                }
                if (txtDiscount.Text == "")
                {
                    MessageBox.Show("Please Enter Discount", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiscount.Focus();
                    return;
                }
                if (txtCash.Text == "")
                {
                    MessageBox.Show("Please Enter Cash", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCash.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insert =
                    "INSERT INTO tbl_Sale_Invoice (BillNo,Date,Currency,SubTotal,VAT,ParcVAT,Discount,ParcDiscount,GrandTotal,Cash,Change) VALUES('" +
                    txtBillNo.Text + "','" + dateTimeSaleDate.Text + "','" + comboCurrency.Text + "','" +
                    txtSubTotal.Text + "','" + txtVAT.Text + "','" + txtParcVAT.Text + "','" + txtDiscount.Text + "','" +
                    txtPercDiscount.Text + "','" + txtGrandTotal.Text + "','" + txtCash.Text + "','" + txtChange.Text +
                    "')";
                command = new SqlCommand(insert);
                command.Connection = con;
                command.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();

                for (int i = 0; i <= listViewSale.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string Insertsold =
                        "INSERT INTO tbl_Sold_Invoice(BillNo,ItemID,ItemNo,Category,ItemName,ItemDetails,Quantity,UnitPrice,TotalAmount) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                    command = new SqlCommand(Insertsold);
                    command.Connection = con;
                    command.Parameters.AddWithValue("@d1", txtBillNo.Text);
                    command.Parameters.AddWithValue("@d2", listViewSale.Items[i].SubItems[0].Text);
                    command.Parameters.AddWithValue("@d3", listViewSale.Items[i].SubItems[1].Text);
                    command.Parameters.AddWithValue("@d4", listViewSale.Items[i].SubItems[2].Text);
                    command.Parameters.AddWithValue("@d5", listViewSale.Items[i].SubItems[3].Text);
                    command.Parameters.AddWithValue("@d6", listViewSale.Items[i].SubItems[4].Text);
                    command.Parameters.AddWithValue("@d7", listViewSale.Items[i].SubItems[5].Text);
                    command.Parameters.AddWithValue("@d8", listViewSale.Items[i].SubItems[6].Text);
                    command.Parameters.AddWithValue("@d9", listViewSale.Items[i].SubItems[7].Text);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                btnSave.Enabled = false;
                btnPrintInvoice.Enabled = true;
                MessageBox.Show("Data Saved Successfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

               // SoldEmpty();
                SaleEmpty();
                

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        public void SoldEmpty()
        {
            comboOrderItemNo.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtItemDetails.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
        }

        public void SaleEmpty()
        {
            txtBillNo.Text = string.Empty;
            comboCurrency.Text = string.Empty;
            listViewSale.Clear();
            txtSubTotal.Text = string.Empty;
            txtVAT.Text = string.Empty;
            txtParcVAT.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtPercDiscount.Text = string.Empty;
            txtGrandTotal.Text = string.Empty;
            txtCash.Text = string.Empty;
            txtChange.Text = string.Empty;
        }
        

        private void btnNew_Click(object sender, EventArgs e)
        {
            SaleEmpty();
            SoldEmpty();
        }

        private void SaleUI_Load(object sender, EventArgs e)
        {

        }

        }

    }

