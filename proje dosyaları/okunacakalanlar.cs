using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using ClosedXML.Excel;


using DevExpress.XtraPdfViewer;
using DevExpress.Pdf;

using Spire.Pdf;

//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tanimlar.mdf;Integrated Security=True



namespace OptimakPDFReader
{
    public partial class okunacakalanlar : Form
    {
        public okunacakalanlar()
        {
            InitializeComponent();


            pdfViewer1.MouseDown += pdfViewer1_MouseDown;
            pdfViewer1.MouseMove += pdfViewer1_MouseMove;
            pdfViewer1.MouseUp += pdfViewer1_MouseUp;
            pdfViewer1.Paint += pdfViewer1_Paint;
        }





        bool mouseButtonPressed = false;
        PdfDocumentPosition startPosition;
        PdfDocumentPosition endPosition;

        void pdfViewer1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPosition = pdfViewer1.GetDocumentPosition(e.Location);
                endPosition = null;
                mouseButtonPressed = true;
                pdfViewer1.Invalidate();
            }
        }

        void pdfViewer1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseButtonPressed)
            {
                endPosition = pdfViewer1.GetDocumentPosition(e.Location);
                pdfViewer1.Invalidate();
            }
        }

        void pdfViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            try {
                mouseButtonPressed = false;

                if (dataGridView1.Rows.Count > 0)
                {
                    if (MessageBox.Show($"Bu koordinatları, {dataGridView1.SelectedRows[0].Cells[0].Value.ToString()} için onaylıyor musunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        RectangleF okunacakalan =
                        RectangleF.FromLTRB
                            (
                            Math.Min((float)startPosition.Point.X, (float)endPosition.Point.X), Math.Min((float)(PDF_Size.Height - startPosition.Point.Y), (float)(PDF_Size.Height - endPosition.Point.Y)),
                            Math.Max((float)startPosition.Point.X, (float)endPosition.Point.X), Math.Max((float)(PDF_Size.Height - startPosition.Point.Y), (float)(PDF_Size.Height - endPosition.Point.Y))
                            );

                        dataGridView1.SelectedRows[0].Cells["X"].Value = okunacakalan.X;
                        dataGridView1.SelectedRows[0].Cells["Y"].Value = okunacakalan.Y;
                        dataGridView1.SelectedRows[0].Cells["H"].Value = okunacakalan.Height;
                        dataGridView1.SelectedRows[0].Cells["W"].Value = okunacakalan.Width;




                        //    MessageBox.Show(pdf.Pages[0].ExtractText(aa));

                        //  MessageBox.Show("onayladı");
                    }
                    //  MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }


                /*
                if(startPosition.Point.Y >= 0)
                MessageBox.Show((PDF_Size.Height - startPosition.Point.Y).ToString());
               else
                MessageBox.Show((PDF_Size.Height + startPosition.Point.Y).ToString());*/



                //  MessageBox.Show( ((int)x.Point.X).ToString() + "  /// " + (((int)(x.Point.Y-841,89)*-1).ToString()));
                //MessageBox.Show(x.Point.Y - pdfViewer1);


                /*  MessageBox.Show(RectangleF.FromLTRB(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y),
                       Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y)).ToString());
                       */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            }
        bool secilialaniciz;
        RectangleF RF_secilialan;
        PointF startPoint;

        PointF endPoint;
        void pdfViewer1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (secilialaniciz)
            {
                using (SolidBrush blueBrush = new SolidBrush(Color.FromArgb(128, Color.Aqua)))
                {

                    g.FillRectangle(blueBrush, RF_secilialan);
                }
                secilialaniciz = false;
                return;

            }


            if (startPosition != null && endPosition != null)
            {

                startPoint = pdfViewer1.GetClientPoint(startPosition);
                endPoint = pdfViewer1.GetClientPoint(endPosition);

                using (SolidBrush blueBrush = new SolidBrush(Color.FromArgb(128, Color.Aqua)))
                {

                    g.FillRectangle(blueBrush,
                    RectangleF.FromLTRB(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y),
                    Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y)));
                }
            }

        }




        DataTable dt;

        public DataTable ToDataTable(ExcelApp.Range range, int rows, int cols)
        {

            DataTable table = new DataTable();
            rows = 3;
            for (int i = 1; i <= rows; i++)
            {
                if (i == 1)
                { // ilk satırı Sutun Adları olarak kullanıldığından
                  // bunları Sutün Adları Olarak Kaydediyoruz.
                    for (int j = 1; j <= cols; j++)
                    {
                        //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                            table.Columns.Add(range.Cells[i, j].Value2.ToString());
                        else //Boş olduğunda Kaçınsı Sutünsa Adı veriliyor.
                            table.Columns.Add(j.ToString() + ".Sütun");
                    }
                    continue;
                }
                //Yukarıda Sütunlar eklendi
                // onun şemasına göre yeni bir satır oluşturuyoruz. 
                //Okunan verileri yan yana sıralamak için
                var yeniSatir = table.NewRow();
                for (int j = 1; j <= cols; j++)
                {
                    //Sütunların içeriği boş mu kontrolü yapılmaktadır.
                    if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                        yeniSatir[j - 1] = range.Cells[i, j].Value2.ToString();
                    else // İçeriği boş hücrede hata vermesini önlemek için
                        yeniSatir[j - 1] = String.Empty;
                }
                table.Rows.Add(yeniSatir);
            }
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fd.Filter = "Excel Dosyası|*.xls;*.xlsx;*.xlsm";
            fd.FileName = "Proje Dosyası";
            fd.Title = "Proje Dosyası Seç";

            ExcelApp.Application excelApp = new ExcelApp.Application();

            if (excelApp != null)
            {

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(fd.FileName);
                    ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                    ExcelApp.Range excelRange = excelSheet.UsedRange;
                    int sutunSayisi = excelRange.Columns.Count;
                    int satirSayisi = excelRange.Rows.Count;
                    dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);


                    //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);






                }

            }
            else
            {
                MessageBox.Show("Excel yüklü değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        Spire.Pdf.PdfDocument pdf;
        private void okunacakalanlar_Load(object sender, EventArgs e)
        {
            uyariPopup uyariformu = new uyariPopup();
            uyariformu.uyarimetni = "Bu ekranda gerçekleştireceğiniz işlemler\n1-) Tek seferliktir, projenin PDF ve Excel yapısını ayarlandırabilmeniz içindir.\n2-) Burada belirteceğiniz alanlar daha sonradan değiştirilebilir, birden fazla yapı farklılıkları ile kontrol sağlayabilirsiniz. falan filan.";
            uyariformu.ShowDialog();
        }

        SizeF PDF_Size;
        private void pdfButton_Click(object sender, EventArgs e)
        {
            fd.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
            fd.FileName = "Proje Dosyası";
            fd.Title = "Proje Dosyası Seç";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pdfButton.BackColor = Color.LimeGreen;
                pdfButton.Tag = fd.FileName.ToString();
                pdfButton.Text = fd.SafeFileName;

                pdf = new Spire.Pdf.PdfDocument();
                pdf.LoadFromFile(fd.FileName);


                PDF_Size = pdf.Pages[0].Size;

                excelButton.Visible = true;




            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            fd.Filter = "Excel Dosyası|*.xls;*.xlsx;*.xlsm";
            fd.FileName = "Proje Dosyası";
            fd.Title = "Proje Dosyası Seç";

            ExcelApp.Application excelApp = new ExcelApp.Application();

            if (excelApp != null)
            {

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    excelButton.BackColor = Color.LimeGreen;
                    excelButton.Tag = fd.FileName;
                    excelButton.Text = fd.SafeFileName;
                    ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(fd.FileName);
                    ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                    ExcelApp.Range excelRange = excelSheet.UsedRange;
                    int sutunSayisi = excelRange.Columns.Count;
                    int satirSayisi = excelRange.Rows.Count;
                    dt = ToDataTable(excelRange, satirSayisi, sutunSayisi);


                    //Okuduktan Sonra Excel Uygulamasını Kapatıyoruz.
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    pdfViewer1.DocumentFilePath = pdfButton.Tag.ToString();
                    //  pdfViewer1.CursorMode = PdfCursorMode.Custom;

                    DataTable dtsutunlar = new DataTable();
                    dtsutunlar.Columns.Add("Sütun Adı");
                    dtsutunlar.Columns.Add("X");
                    dtsutunlar.Columns.Add("Y");
                    dtsutunlar.Columns.Add("W");
                    dtsutunlar.Columns.Add("H");


                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataRow yenisatir = dtsutunlar.NewRow();
                        yenisatir[0] = dt.Columns[i].ColumnName.ToString();
                        dtsutunlar.Rows.Add(yenisatir);

                    }
                    dataGridView1.DataSource = dtsutunlar;


                    pPdf.Visible = false;
                    pEsitle.Visible = true;
                    pdfViewer1.Visible = true;

                    pdfViewer1.Left = pEsitle.Left;
                    pEsitle.Left = pPdf.Left;






                }

            }
            else
            {
                MessageBox.Show("Excel yüklü değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void okunacakalanlar_Resize(object sender, EventArgs e)
        {
            pdfViewer1.Height = this.Height - 100;
            pdfViewer1.Width = this.Width - 400;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dataGridView1.SelectedRows[0].Cells["X"].Value.ToString()))
                {
                    RF_secilialan.X = float.Parse(dataGridView1.SelectedRows[0].Cells["X"].Value.ToString());
                    RF_secilialan.Y = float.Parse(dataGridView1.SelectedRows[0].Cells["Y"].Value.ToString());
                    RF_secilialan.Height = float.Parse(dataGridView1.SelectedRows[0].Cells["H"].Value.ToString());
                    RF_secilialan.Width = float.Parse(dataGridView1.SelectedRows[0].Cells["W"].Value.ToString());


                    secilialaniciz = true;
                    pdfViewer1.Invalidate();
                    // MessageBox.Show("boş değil");
                }
                else
                {
                    //MessageBox.Show("boş");
                }
            }


            //string deger = dataGridView1.SelectedRows[0].Cells["X"].Value.ToString();


        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                DataTable dt_excelAyarlari = (DataTable)dataGridView1.DataSource;
      
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dt_excelAyarlari, "ExcelAyarlari");
                wb.SaveAs("excelayarlari.xlsx");



                    //SqlCommand pdfSizeInsert = new SqlCommand("Insert INTO pdfBilgileri (pHeight, pWidth, pName) values (@h, @w, @n); SELECT SCOPE_IDENTITY();", baglanti);
                    //pdfSizeInsert.Parameters.AddWithValue("@h", PDF_Size.Height.ToString());
                    //pdfSizeInsert.Parameters.AddWithValue("@w", PDF_Size.Width.ToString());
                    //pdfSizeInsert.Parameters.AddWithValue("@n", pdfButton.Text.ToString());

                    //SqlDataReader reader = pdfSizeInsert.ExecuteReader();
                    //reader.Read();
                    //string pdf_id = reader[0].ToString();
                    //reader.Close();


                    //SqlCommand excelInsert = new SqlCommand("Insert INTO excelHeaders (eName, eDate,pdf_id) values (@n, @d,@pid); SELECT SCOPE_IDENTITY();", baglanti);
                    //excelInsert.Parameters.AddWithValue("@n", excelButton.Text.ToString());
                    //excelInsert.Parameters.AddWithValue("@d", DateTime.Now.ToString());
                    //excelInsert.Parameters.AddWithValue("@pid", pdf_id);





                    //reader = excelInsert.ExecuteReader();
                    //reader.Read();
                    //string excel_id = reader[0].ToString();
                    //reader.Close();


                    //for (int i = 0; i < dataGridView1.RowCount; i++)
                    //{
                    //    if (!String.IsNullOrEmpty(dataGridView1.Rows[i].Cells["X"].Value.ToString()))
                    //    {
                    //        string ColumName, p_X, p_Y, p_W, p_H;

                    //        ColumName = dataGridView1.Rows[i].Cells["Sütun Adı"].Value.ToString();
                    //        p_X = dataGridView1.Rows[i].Cells["X"].Value.ToString();
                    //        p_Y = dataGridView1.Rows[i].Cells["Y"].Value.ToString();
                    //        p_W = dataGridView1.Rows[i].Cells["W"].Value.ToString();
                    //        p_H = dataGridView1.Rows[i].Cells["H"].Value.ToString();

                    //        SqlCommand excelBilgileriInsert = new SqlCommand("Insert INTO excelBilgileri (eColumnName, pdfLocation_X, pdfLocation_Y,pdfLocation_W,pdfLocation_H, e_Id, pdf_Id) values (@n, @x, @y, @w,@h, @eid, @pid);", baglanti);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@n", ColumName);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@x", p_X);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@y", p_Y);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@w", p_W);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@h", p_H);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@pid", pdf_id);
                    //        excelBilgileriInsert.Parameters.AddWithValue("@eid", excel_id);

                    //        excelBilgileriInsert.ExecuteNonQuery();

                    //        /* 
                    //         * (@n, @x, @y, @w,@h, @eid, @pid)
                    //            dtsutunlar.Columns.Add("Sütun Adı");
                    //    dtsutunlar.Columns.Add("X");
                    //    dtsutunlar.Columns.Add("Y");
                    //    dtsutunlar.Columns.Add("W");
                    //    dtsutunlar.Columns.Add("H");    
                    //     */


                    //    }
                    //}
                    MessageBox.Show("Tanımlar ayarlandı! Sayfa kapatılıyor", "Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                    this.Close();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
