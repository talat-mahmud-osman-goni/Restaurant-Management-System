using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC_RMS.Forms.Report.PrintableReport
{
    public partial class PrintableSaleVautcher : Form
    {
        public PrintableSaleVautcher()
        {
            InitializeComponent();
        }

        private void Load()
        {
            
        }
        private void PrintableSaleVautcher_Load(object sender, EventArgs e)
        {
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kFCDATASET.tbl_Sold_Invoice' table. You can move, or remove it, as needed.
            this.tbl_Sold_InvoiceTableAdapter.FillBy(this.kFCDATASET.tbl_Sold_Invoice, comboBox1.Text);

            // TODO: This line of code loads data into the 'kFCDATASET.tbl_Sale_Invoice' table. You can move, or remove it, as needed.
            this.tbl_Sale_InvoiceTableAdapter.FillBy(this.kFCDATASET.tbl_Sale_Invoice, comboBox1.Text);


            this.reportViewer1.RefreshReport();
       
        }
    }
}
