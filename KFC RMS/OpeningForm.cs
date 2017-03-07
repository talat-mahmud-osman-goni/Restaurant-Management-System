using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KFC_RMS.Forms.Client;
using KFC_RMS.Forms.Company;
using KFC_RMS.Forms.Category;
using KFC_RMS.Forms.Staff;
using KFC_RMS.Forms.Payment;
using KFC_RMS.Forms.Product;
using KFC_RMS.Forms.Expenditure;
using KFC_RMS.Forms.Items;
using KFC_RMS.Forms.Sale;
using KFC_RMS.Forms.Purchase;
using KFC_RMS.Forms.Report;

namespace KFC_RMS
{
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
        }

        private void OpeningForm_Load(object sender, EventArgs e)
        {

        }
        

        private void companyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyInfoUI aUi = new CompanyInfoUI();
            aUi.Show();
        }

        

        


        

       

        

        private void productInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductInfoUI aUi = new ProductInfoUI();
            aUi.Show();
        }

        private void expenditureToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExpenditureUI aex = new ExpenditureUI();
            aex.Show();
        }

        private void catagoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CategorySelectionUI aUi=new CategorySelectionUI();
            aUi.Show();
        }

        private void clientInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClientInfoUI aUi = new ClientInfoUI();
            aUi.Show();
        }

        private void staffInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StaffInfoUI aUi=new StaffInfoUI();
            aUi.Show();
        }

        private void staffSalaryPaymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SalaryPaymentUI aUi=new SalaryPaymentUI();
            aUi.Show();
        }

        private void saleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaleUI aUi=new SaleUI();
            aUi.Show();
        }

        private void purchage1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseUI aUi=new PurchaseUI();
            aUi.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseRecordUI aUi=new PurchaseRecordUI();
            aUi.Show();
        }

        private void saleVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleRecordUI aUi=new SaleRecordUI();
            aUi.Show();
        }

        private void companyInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompanyRecordUI aUi=new CompanyRecordUI();
            aUi.Show();
        }

        private void staffInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StaffRecordUI aUi=new StaffRecordUI();
            aUi.Show();
        }

        private void catagoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CategoryRecordUI aUi=new CategoryRecordUI();
            aUi.Show();
        }

        private void productInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductRecordUI aUi=new ProductRecordUI();
            aUi.Show();
        }

        private void clientInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClientRecordUI aUi=new ClientRecordUI();
            aUi.Show();
        }

        private void expenditureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExpenditureRecordUI aUi=new ExpenditureRecordUI();
            aUi.Show();
        }

        private void salaryPaymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SalaryPaymentRecordUI aUi=new SalaryPaymentRecordUI();
            aUi.Show();
        }

        private void itemSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSelectionUI aUi=new ItemSelectionUI();
            aUi.Show();
        }

        private void itemSelectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemSelectionRecordUI aUi=new ItemSelectionRecordUI();
            aUi.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
