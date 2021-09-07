namespace OptimakPDFReader
{
    partial class okunacakalanlar
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
            this.fd = new System.Windows.Forms.OpenFileDialog();
            this.pPdf = new System.Windows.Forms.Panel();
            this.excelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pdfButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pEsitle = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.pPdf.SuspendLayout();
            this.pEsitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fd
            // 
            this.fd.FileName = "openFileDialog1";
            // 
            // pPdf
            // 
            this.pPdf.Controls.Add(this.excelButton);
            this.pPdf.Controls.Add(this.label1);
            this.pPdf.Controls.Add(this.pdfButton);
            this.pPdf.Location = new System.Drawing.Point(12, 12);
            this.pPdf.Name = "pPdf";
            this.pPdf.Size = new System.Drawing.Size(338, 426);
            this.pPdf.TabIndex = 3;
            // 
            // excelButton
            // 
            this.excelButton.Location = new System.Drawing.Point(41, 252);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(246, 77);
            this.excelButton.TabIndex = 2;
            this.excelButton.Text = "Excel Tanımla";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Visible = false;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanımladığınız PDF\'in bütün sayfalarının;\r\nGenişlik\r\nYükseklik\r\ndeğerleri aynı ol" +
    "mak zorundadır.\r\n";
            // 
            // pdfButton
            // 
            this.pdfButton.Location = new System.Drawing.Point(41, 169);
            this.pdfButton.Name = "pdfButton";
            this.pdfButton.Size = new System.Drawing.Size(246, 77);
            this.pdfButton.TabIndex = 0;
            this.pdfButton.Text = "PDF Tanımla";
            this.pdfButton.UseVisualStyleBackColor = true;
            this.pdfButton.Click += new System.EventHandler(this.pdfButton_Click);
            // 
            // pEsitle
            // 
            this.pEsitle.Controls.Add(this.button1);
            this.pEsitle.Controls.Add(this.dataGridView1);
            this.pEsitle.Controls.Add(this.label2);
            this.pEsitle.Location = new System.Drawing.Point(356, 12);
            this.pEsitle.Name = "pEsitle";
            this.pEsitle.Size = new System.Drawing.Size(338, 426);
            this.pEsitle.TabIndex = 4;
            this.pEsitle.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tamamla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(14, 64);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(304, 276);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(42, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Excel Sütunlarını PDF\'e eşitleyiniz";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.CursorMode = DevExpress.XtraPdfViewer.PdfCursorMode.Custom;
            this.pdfViewer1.Location = new System.Drawing.Point(700, 12);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(150, 423);
            this.pdfViewer1.TabIndex = 5;
            this.pdfViewer1.Visible = false;
            // 
            // okunacakalanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 450);
            this.Controls.Add(this.pEsitle);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.pPdf);
            this.Name = "okunacakalanlar";
            this.Text = "Optimak PDF Reader - Okunacak Alan Tanımı";
            this.Load += new System.EventHandler(this.okunacakalanlar_Load);
            this.Resize += new System.EventHandler(this.okunacakalanlar_Resize);
            this.pPdf.ResumeLayout(false);
            this.pPdf.PerformLayout();
            this.pEsitle.ResumeLayout(false);
            this.pEsitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog fd;
        private System.Windows.Forms.Panel pPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pdfButton;
        private System.Windows.Forms.Button excelButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pEsitle;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}