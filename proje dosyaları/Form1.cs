using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExcelApp = Microsoft.Office.Interop.Excel;

using System.Threading;

using Dev = DevExpress.Pdf;
using DevExpress.XtraPdfViewer;


using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Exporting.Text;
using Spire.Pdf.General.Find;
using System.IO;
using Spire.Pdf.Graphics.Fonts;

namespace OptimakPDFReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

        }




        DataTable dtPDF;
        DataTable dtExcelAyarlari;
        DataTable dtExcel;
        DataTable dtokunansayfalar;

        public DataTable ToDataTable(ExcelApp.Range range, int rows, int cols)
        {

            DataTable table = new DataTable();

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


                // boş satırları silmek.


            }

            return table;
        }




        void Karsilastir()
        {
            if (button1.Tag != null && button2.Tag != null)
            {

                ExcelApp.Application excelApp = new ExcelApp.Application();

                if (excelApp != null)
                {

                


                    ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(Application.StartupPath.ToString() + @"\excelayarlari.xlsx");
                    ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                    ExcelApp.Range excelRange = excelSheet.UsedRange;
                    int sutunSayisi = excelRange.Columns.Count;
                    int satirSayisi = excelRange.Rows.Count;
                    dtExcelAyarlari = ToDataTable(excelRange, satirSayisi, sutunSayisi);



                    //Bilgilendirme
                    lblDurum.Text = "Excel Verileri Alınıyor";

                    for (int k = dtExcelAyarlari.Rows.Count; k >= 1; k--)
                    {
                        DataRow currentRow = dtExcelAyarlari.Rows[k - 1];
                        if (string.IsNullOrEmpty(currentRow["X"].ToString()))
                        {
                            dtExcelAyarlari.Rows[k - 1].Delete();
                        }
                    }


                    excelBook = excelApp.Workbooks.Open(button2.Tag.ToString());
                    excelSheet = excelBook.Sheets[1];
                    excelRange = excelSheet.UsedRange;
                    sutunSayisi = excelRange.Columns.Count;
                    satirSayisi = excelRange.Rows.Count;
                    dtExcel = ToDataTable(excelRange, satirSayisi, sutunSayisi);


                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    PdfPen pen = new PdfPen(Color.ForestGreen, 0.1f);
                    PdfBrush b_Orange = new PdfSolidBrush(Color.Orange);
                    PdfBrush b_LightGreen = new PdfSolidBrush(Color.LightGreen);
                    SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();



                  

                    PdfDocument pdf = new PdfDocument();
                    pdf.LoadFromFile(button1.Tag.ToString());
                    PdfPageBase page;

                    dtokunansayfalar = new DataTable();




                    for (int baslikexcelayar = 0; baslikexcelayar < dtExcelAyarlari.Rows.Count; baslikexcelayar++)
                    {
                        dtokunansayfalar.Columns.Add(dtExcelAyarlari.Rows[baslikexcelayar][0].ToString());
                    }

                    dtokunansayfalar.Columns.Add("Sayfa");


                    //Bilgilendirme
                    lblDurum.Text = "PDF Sayfaları Okunuyor.";

                    for (int i = 0; i < pdf.Pages.Count; i++)
                    {

                 
                   
                        DataRow row = dtokunansayfalar.NewRow();
                        page = pdf.Pages[i];
                        PdfGraphicsState state = page.Canvas.Save();
             
                        for (int j = 0; j < dtExcelAyarlari.Rows.Count; j++)
                        {
                        
                          
                            PointF p_OA = new PointF(float.Parse(dtExcelAyarlari.Rows[j]["X"].ToString()), float.Parse(dtExcelAyarlari.Rows[j]["Y"].ToString()));
                            SizeF s_OA = new SizeF(float.Parse(dtExcelAyarlari.Rows[j]["W"].ToString()), float.Parse(dtExcelAyarlari.Rows[j]["H"].ToString()));
                            RectangleF okunacakalan = new RectangleF(p_OA, s_OA);
                            string okunanmetin = page.ExtractText(okunacakalan);
                            string silinecektext = "Evaluation Warning : The document was created with Spire.PDF for .NET.";
                            okunanmetin = okunanmetin.Remove(0, silinecektext.Length);


                            

                            okunanmetin = okunanmetin.TrimStart();
                            okunanmetin = okunanmetin.TrimEnd();

                            if(dtExcelAyarlari.Rows[j][0].ToString() == "Resim No" || dtExcelAyarlari.Rows[j][0].ToString() == "Rota")
                            {
                              
                                okunanmetin = okunanmetin.Replace("'", String.Empty);
                            }

                            row[dtExcelAyarlari.Rows[j][0].ToString()] = okunanmetin;
                            row["Sayfa"] = i.ToString();


                            //      okunanmetin += "[" +dtExcelAyarlari.Rows[j][0].ToString() +"]" + j.ToString() ;

                            //    " .Show(okunanmetin);
                            /*
                            PdfTextFind[] results = null;
                            for (int k = 0; k < dtExcel.Rows.Count; k++)
                            {
                                MessageBox.Show(dtExcel.Rows[k][dtExcelAyarlari.Rows[j][0].ToString()].ToString() + " --> " +okunanmetin);
                                if (dtExcel.Rows[k][dtExcelAyarlari.Rows[j][0].ToString()].ToString().Contains(okunanmetin))
                                {
                                    MessageBox.Show("oldu lan");
                                    results = page.FindText(dtExcel.Rows[k][dtExcelAyarlari.Rows[j][0].ToString()].ToString()).Finds;
                                }
                            }
                            */





                            ///PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 10f);
                            //PdfSolidBrush brush = new PdfSolidBrush(Color.Blue);

                            // page.Canvas.DrawString(dtExcelAyarlari.Rows[j][0].ToString(), font, brush, okunacakalan);
                            //  page.Canvas.DrawRectangle(b_LightGreen, okunacakalan);
                            page.Canvas.Restore(state);
                        }
                        dtokunansayfalar.Rows.Add(row);

                    }

                    dataGridView1.DataSource = dtokunansayfalar;
                    

                    for (int exceli = 0; exceli < dtExcel.Rows.Count; exceli++)
                    {
                      
                        for (int okunani = 0; okunani < dtokunansayfalar.Rows.Count; okunani++)
                        {
                            if (dtExcel.Rows[exceli]["Parça Adı"].ToString()== dtokunansayfalar.Rows[okunani]["Parça Adı"].ToString())
                            {
                               

                                for (int ayarcolumn = 0; ayarcolumn < dtExcelAyarlari.Rows.Count; ayarcolumn++)
                                {
                                    if (dtExcel.Rows[exceli][dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].ToString() == dtokunansayfalar.Rows[okunani][dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].ToString())
                                    {
                            
                                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                                        style.BackColor = Color.LightGreen;
                                        dataGridView1.Rows[okunani].Cells[dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].Style = style;

                                   
                                    }
                                    else
                                    {
                                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                                        style.BackColor = Color.OrangeRed;
                                        dataGridView1.Rows[okunani].Cells[dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].Style = style;
                                        dataGridView1.Rows[okunani].Cells[dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].Value += " Excel: " + dtExcel.Rows[exceli][dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].ToString();
                                    }

                                   
                                }
                               
                            }
                        }
                    }


                    //   pdf.SaveToFile("Rectangles.pdf");
                    //                    System.Diagnostics.Process.Start("Rectangles.pdf");

                    button3.Enabled = true;



                }

            }
            else
            {
                MessageBox.Show("Excel yüklü değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            fd.Filter = "PDF Dosyaları (*.pdf)|*.pdf";
            fd.FileName = "Proje Dosyası";
            fd.Title = "Proje Dosyası Seç";

            if (fd.ShowDialog() == DialogResult.OK)
            {


                button1.Text = fd.SafeFileName;
                button1.Tag = fd.FileName;
                button1.BackColor = Color.LimeGreen;
                pdfViewer1.DocumentFilePath = fd.FileName;
                pdfViewer1.CursorMode = PdfCursorMode.Custom;
                //   Karsilastir();






            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        //    pdfViewer1.Height = this.Height - 100;
        //    pdfViewer1.Width = this.Width - 500;


            dataGridView1.Height = this.Height - 300;
            dataGridView1.Width = this.Width - 70;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //   pdf = new PdfDocument();
            dtPDF = new DataTable();
            dtExcel = new DataTable();
            dtExcelAyarlari = new DataTable();


            pdfViewer1.Height = this.Height - 100;
            pdfViewer1.Width = this.Width - 500;




        }

        private void button2_Click(object sender, EventArgs e)
        {
            fd.Filter = "Excel Dosyası|*.xls;*.xlsx;*.xlsm";
            fd.FileName = "Proje Dosyası";
            fd.Title = "Proje Dosyası Seç";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                button2.Text = fd.SafeFileName;
                button2.Tag = fd.FileName;
                button2.BackColor = Color.LimeGreen;
                Karsilastir();

            }
        }

        private void pdfReaderBW_DoWork(object sender, DoWorkEventArgs e)
        {


        }

        private void pdfReaderBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void pdfViewer1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void okunacakAlanTanımıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            okunacakalanlar okunacak = new okunacakalanlar();
            okunacak.ShowDialog();
        }

        private void veritabanıİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void bağlantıTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            button3.Enabled = false;


            dataGridView1.DataSource = dtExcel;

            for (int exceli = 0; exceli < dtExcel.Rows.Count; exceli++)
            {

                for (int okunani = 0; okunani < dtokunansayfalar.Rows.Count; okunani++)
                {


                    if (dtExcel.Rows[exceli]["Parça Adı"].ToString() ==dtokunansayfalar.Rows[okunani]["Parça Adı"].ToString())
                    {
                       
                        for (int ayarcolumn = 0; ayarcolumn < dtExcelAyarlari.Rows.Count; ayarcolumn++)
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();

                            if (dtExcel.Rows[exceli][dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].ToString() == dtokunansayfalar.Rows[okunani][dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].ToString())
                            {

                                style.BackColor = Color.LightGreen;
                                dataGridView1.Rows[exceli].Cells[dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].Style = style;


                            }
                            else
                            {

                                style.BackColor = Color.OrangeRed;
                                dataGridView1.Rows[exceli].Cells[dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].Style = style;
                                dataGridView1.Rows[exceli].Cells[dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].Value += " PDF: " + dtokunansayfalar.Rows[okunani][dtExcelAyarlari.Rows[ayarcolumn][0].ToString()].ToString();
                            }

                        }

                    }
                }
            }

            for (int i = dataGridView1.Rows.Count-1; i >= 0; i--)
            {
                if(dataGridView1.Rows[i].Cells["Parça Adı"].Style.BackColor == Color.LightGreen)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
               // MessageBox.Show(dataGridView1.Rows[i].Cells["Parça Adı"].Style.BackColor.ToString() + " --> " + dataGridView1.Rows[i].Cells["Parça Adı"].Value.ToString());
            }

        }
    }
}
