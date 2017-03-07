namespace KFC_RMS.Forms.Report.PrintableReport
{
    partial class PrintableSaleVautcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_Sale_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kFCDATASET = new KFC_RMS.KFCDATASET();
            this.tbl_Sold_InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSaleInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_Sale_InvoiceTableAdapter = new KFC_RMS.KFCDATASETTableAdapters.tbl_Sale_InvoiceTableAdapter();
            this.tblSoldInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_Sold_InvoiceTableAdapter = new KFC_RMS.KFCDATASETTableAdapters.tbl_Sold_InvoiceTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Sale_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kFCDATASET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Sold_InvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSaleInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSoldInvoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 447);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 447);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill No";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "SalesProductDataSet";
            reportDataSource3.Value = this.tbl_Sale_InvoiceBindingSource;
            reportDataSource4.Name = "SoldDataSet";
            reportDataSource4.Value = this.tbl_Sold_InvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KFC_RMS.Forms.Report.PrintableReport.SalesInvoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(566, 447);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tbl_Sale_InvoiceBindingSource
            // 
            this.tbl_Sale_InvoiceBindingSource.DataMember = "tbl_Sale_Invoice";
            this.tbl_Sale_InvoiceBindingSource.DataSource = this.kFCDATASET;
            // 
            // kFCDATASET
            // 
            this.kFCDATASET.DataSetName = "KFCDATASET";
            this.kFCDATASET.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_Sold_InvoiceBindingSource
            // 
            this.tbl_Sold_InvoiceBindingSource.DataMember = "tbl_Sold_Invoice";
            this.tbl_Sold_InvoiceBindingSource.DataSource = this.kFCDATASET;
            // 
            // tblSaleInvoiceBindingSource
            // 
            this.tblSaleInvoiceBindingSource.DataMember = "tbl_Sale_Invoice";
            this.tblSaleInvoiceBindingSource.DataSource = this.kFCDATASET;
            // 
            // tbl_Sale_InvoiceTableAdapter
            // 
            this.tbl_Sale_InvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // tblSoldInvoiceBindingSource
            // 
            this.tblSoldInvoiceBindingSource.DataMember = "tbl_Sold_Invoice";
            this.tblSoldInvoiceBindingSource.DataSource = this.kFCDATASET;
            // 
            // tbl_Sold_InvoiceTableAdapter
            // 
            this.tbl_Sold_InvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // PrintableSaleVautcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 447);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PrintableSaleVautcher";
            this.Text = "PrintableSaleVautcher";
           // this.Load += new System.EventHandler(this.PrintableSaleVautcher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Sale_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kFCDATASET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Sold_InvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSaleInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSoldInvoiceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private KFCDATASET kFCDATASET;
        private System.Windows.Forms.BindingSource tblSaleInvoiceBindingSource;
        private KFCDATASETTableAdapters.tbl_Sale_InvoiceTableAdapter tbl_Sale_InvoiceTableAdapter;
        private System.Windows.Forms.BindingSource tblSoldInvoiceBindingSource;
        private KFCDATASETTableAdapters.tbl_Sold_InvoiceTableAdapter tbl_Sold_InvoiceTableAdapter;
        private System.Windows.Forms.BindingSource tbl_Sale_InvoiceBindingSource;
        private System.Windows.Forms.BindingSource tbl_Sold_InvoiceBindingSource;
    }
}