namespace OptimakPDFReader
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.fd = new System.Windows.Forms.OpenFileDialog();
            this.pdfReaderBW = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.okunacakAlanTanımıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veritabanıİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bağlantıTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(13, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 82);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDF DOSYASI SEÇ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(221, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "EXCEL DOSYASI SEÇ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 166);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(73, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROJE | PDF - EXCEL KARŞILAŞTIR";
            // 
            // fd
            // 
            this.fd.FileName = "openFileDialog1";
            // 
            // pdfReaderBW
            // 
            this.pdfReaderBW.WorkerReportsProgress = true;
            this.pdfReaderBW.WorkerSupportsCancellation = true;
            this.pdfReaderBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pdfReaderBW_DoWork);
            this.pdfReaderBW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pdfReaderBW_ProgressChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programAyarlarıToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programAyarlarıToolStripMenuItem
            // 
            this.programAyarlarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.okunacakAlanTanımıToolStripMenuItem,
            this.veritabanıİşlemleriToolStripMenuItem,
            this.bağlantıTestToolStripMenuItem});
            this.programAyarlarıToolStripMenuItem.Name = "programAyarlarıToolStripMenuItem";
            this.programAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.programAyarlarıToolStripMenuItem.Text = "Program Ayarları";
            // 
            // okunacakAlanTanımıToolStripMenuItem
            // 
            this.okunacakAlanTanımıToolStripMenuItem.Name = "okunacakAlanTanımıToolStripMenuItem";
            this.okunacakAlanTanımıToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.okunacakAlanTanımıToolStripMenuItem.Text = "Okunacak Alan Tanımı";
            this.okunacakAlanTanımıToolStripMenuItem.Click += new System.EventHandler(this.okunacakAlanTanımıToolStripMenuItem_Click);
            // 
            // veritabanıİşlemleriToolStripMenuItem
            // 
            this.veritabanıİşlemleriToolStripMenuItem.Name = "veritabanıİşlemleriToolStripMenuItem";
            this.veritabanıİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.veritabanıİşlemleriToolStripMenuItem.Text = "Veritabanı İşlemleri";
            this.veritabanıİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.veritabanıİşlemleriToolStripMenuItem_Click);
            // 
            // bağlantıTestToolStripMenuItem
            // 
            this.bağlantıTestToolStripMenuItem.Name = "bağlantıTestToolStripMenuItem";
            this.bağlantıTestToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.bağlantıTestToolStripMenuItem.Text = "Bağlantı Test";
            this.bağlantıTestToolStripMenuItem.Click += new System.EventHandler(this.bağlantıTestToolStripMenuItem_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Location = new System.Drawing.Point(625, 100);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(150, 150);
            this.pdfViewer1.TabIndex = 8;
            this.pdfViewer1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(25, 256);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(710, 168);
            this.dataGridView1.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(25, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(233, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Excel\'de olup, PDF\'de olmayanları listele";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(431, 77);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(38, 13);
            this.lblDurum.TabIndex = 12;
            this.lblDurum.Text = "Durum";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " PDF Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog fd;
        private System.ComponentModel.BackgroundWorker pdfReaderBW;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem okunacakAlanTanımıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veritabanıİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bağlantıTestToolStripMenuItem;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblDurum;
    }
}

