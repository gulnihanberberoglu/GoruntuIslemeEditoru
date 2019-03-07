//140202049 Elif Kurt - 160202097 Gülnihan Berberoğlu
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Goruntu_Isleme_Uygulaması
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Resim Ac
            //seçtiğimiz dosyadaki görüntüyü alıp picturebox1'e koymak icin
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "resimler |*.bmp|All Files|*.*";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            pictureBox1.ImageLocation = sfd.FileName;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Resim Kaydet

            SaveFileDialog kaydet = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

            kaydet.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.

            kaydet.Title = "Kaydet Ekranı";//diğaloğumuzun başlığını belirliyoruz.

            kaydet.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

            DialogResult sonuç = kaydet.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                //Böylelikle resmi istediğimiz yere kaydediyoruz.
                Bitmap varBmp = new Bitmap(pictureBox2.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                varBmp.Dispose();
                varBmp = null;
                newBitmap.Save(kaydet.FileName, ImageFormat.Jpeg);
            }



        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Resmi Tekrar Açma
            groupBox4.Visible = false;
            pictureBox2.Size = pictureBox1.Size;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap image = new Bitmap(pictureBox1.Image);
            pictureBox2.Image = image;

        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //sola döndürme işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap soldön = solaDondur(image);
            pictureBox2.Image = soldön;
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // sağa döndürme işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap sagdön = sagaDondur(image);
            pictureBox2.Image = sagdön;
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            //olceklendirme işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap boyut = olceklendirme(image, f2.Genislik, f2.Yukseklik);
            pictureBox2.Image = boyut;
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //histogram işlemi
            groupBox4.Visible = true;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap h1 = khistogram(image);
            Bitmap h2 = mhistogram(image);
            Bitmap h3 = yhistogram(image);
            Bitmap h4 = ghistogram(image);

            pictureBox3.Image = h1;
            pictureBox4.Image = h2;
            pictureBox5.Image = h3;
            pictureBox6.Image = h4;
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            //tersleme işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap ters = tersleme(image);
            pictureBox2.Image = ters;
        }
        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            //griTonlama işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap gri = griTonlama(image);
            pictureBox2.Image = gri;
        }
        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            //kırmızı renk kanalı işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap kırmızı = kırmızıRenkKanalı(image);
            pictureBox2.Image = kırmızı;
        }
        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            //yeşil renk kanalı işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap yesil = yesilRenkKanalı(image);
            pictureBox2.Image = yesil;
        }
        private void toolStripTextBox5_Click(object sender, EventArgs e)
        {
            //mavi renk kanalı işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap mavi = maviRenkKanalı(image);
            pictureBox2.Image = mavi;
        }
        private void toolStripTextBox6_Click(object sender, EventArgs e)
        {
            //sağa aynalama işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap saga = sagaAynalama(image);
            pictureBox2.Image = saga;
        }
        private void toolStripTextBox7_Click(object sender, EventArgs e)
        {
            //sola aynalama işlemi
            groupBox4.Visible = false;
            Bitmap image = new Bitmap(pictureBox1.Image);
            if (pictureBox2.Image == null)
            {
                image = new Bitmap(pictureBox1.Image);
            }
            else
            {
                image = new Bitmap(pictureBox2.Image);
            }
            Bitmap sola = solaAynalama(image);
            pictureBox2.Image = sola;
        }
        private void resimAcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Resim Ac
            //seçtiğimiz dosyadaki görüntüyü alıp picturebox1'e koymak icin
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "resimler |*.bmp|All Files|*.*";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            pictureBox1.ImageLocation = sfd.FileName;
        }
        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Resmi Tekrar Açma
            Bitmap image = new Bitmap(pictureBox1.Image);
            pictureBox2.Image = image;
        }
        private void kaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Resim Kaydet

            SaveFileDialog kaydet = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.

            kaydet.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.

            kaydet.Title = "Kaydet Ekranı";//diğaloğumuzun başlığını belirliyoruz.

            kaydet.FileName = "resim";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.

            DialogResult sonuç = kaydet.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                //Böylelikle resmi istediğimiz yere kaydediyoruz.
                Bitmap varBmp = new Bitmap(pictureBox2.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                varBmp.Dispose();
                varBmp = null;
                newBitmap.Save(kaydet.FileName, ImageFormat.Jpeg);
            }

        }
        private void toolStripSplitButton5_ButtonClick(object sender, EventArgs e)
        {
            //Yardım kısmı
            System.Diagnostics.Process.Start("https://www.google.com.tr/?gfe_rd=cr&dcr=0&ei=atXlWe2vMJCEhgPGt6_4Bg");
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //olceklendirme işlemi tracBar ile
            groupBox4.Visible = false;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            double[] katsayilar = { 0.25, 0.5, 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
            pictureBox2.Width = (int)(pictureBox2.Image.Width *
            katsayilar[trackBar1.Value]);
            pictureBox2.Height = (int)(pictureBox2.Image.Height *
            katsayilar[trackBar1.Value]);

        }
        public Bitmap khistogram(Bitmap bmp)
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            int[] gri = new int[256];

            //resmin her pixeli dolaşılıyor
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //pixelin değeri okunuyor
                    Color renk = bmp.GetPixel(i, j);
                    //bu değerin sayısını tutan değişkeni bir artırılıyor
                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                    //gri deger hesaplanıp bu degeri tutan değişken bir arttırılıyor
                    int griDeger = (renk.R + renk.G + renk.B) / 3;
                    gri[griDeger]++;
                }
            }
            Chart grafik = new Chart();
            chart1.Series.Clear();
            //Grafiğe değer ekleme
            chart1.Series.Add("Kırmızı");
            for (int i = 0; i < 256; i++)
            {
                //eleman ekleme
                chart1.Series["Kırmızı"].Points.Add(new DataPoint(i, kirmizi[i]));
            }
            //Sütun renklerini belirleme
            chart1.Series["Kırmızı"].Color = Color.Red;

            //Grafiği hafızaya kaydedip pictureBox2'ye koyma
            Bitmap sonuc1 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Bmp);
                sonuc1 = new Bitmap(ms);
            }

            return sonuc1;
        }
        public Bitmap mhistogram(Bitmap bmp)
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            int[] gri = new int[256];

            //resmin her pixeli dolaşılıyor
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //pixelin değeri okunuyor
                    Color renk = bmp.GetPixel(i, j);
                    //bu değerin sayısını tutan değişkeni bir artırılıyor
                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                    //gri deger hesaplanıp bu degeri tutan değişken bir arttırılıyor
                    int griDeger = (renk.R + renk.G + renk.B) / 3;
                    gri[griDeger]++;
                }
            }
            Chart grafik = new Chart();
            chart1.Series.Clear();
            //Grafiğe değer ekleme
            chart1.Series.Add("Mavi");
            for (int i = 0; i < 256; i++)
            {
                //eleman ekleme
                chart1.Series["Mavi"].Points.Add(new DataPoint(i, mavi[i]));
            }
            //Sütun renklerini belirleme
            chart1.Series["Mavi"].Color = Color.Blue;

            //Grafiği hafızaya kaydedip pictureBox2'ye koyma
            Bitmap sonuc = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Bmp);
                sonuc = new Bitmap(ms);
            }

            return sonuc;
        }
        public Bitmap yhistogram(Bitmap bmp)
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            int[] gri = new int[256];

            //resmin her pixeli dolaşılıyor
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //pixelin değeri okunuyor
                    Color renk = bmp.GetPixel(i, j);
                    //bu değerin sayısını tutan değişkeni bir artırılıyor
                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                    //gri deger hesaplanıp bu degeri tutan değişken bir arttırılıyor
                    int griDeger = (renk.R + renk.G + renk.B) / 3;
                    gri[griDeger]++;
                }
            }
            Chart grafik = new Chart();
            chart1.Series.Clear();
            //Grafiğe değer ekleme
            chart1.Series.Add("Yeşil");
            for (int i = 0; i < 256; i++)
            {
                //eleman ekleme
                chart1.Series["Yeşil"].Points.Add(new DataPoint(i, yesil[i]));
            }
            //Sütun renklerini belirleme
            chart1.Series["Yeşil"].Color = Color.Green;

            //Grafiği hafızaya kaydedip pictureBox2'ye koyma
            Bitmap sonuc = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Bmp);
                sonuc = new Bitmap(ms);
            }

            return sonuc;
        }
        public Bitmap ghistogram(Bitmap bmp)
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            int[] gri = new int[256];

            //resmin her pixeli dolaşılıyor
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //pixelin değeri okunuyor
                    Color renk = bmp.GetPixel(i, j);
                    //bu değerin sayısını tutan değişkeni bir artırılıyor
                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                    //gri deger hesaplanıp bu degeri tutan değişken bir arttırılıyor
                    int griDeger = (renk.R + renk.G + renk.B) / 3;
                    gri[griDeger]++;
                }
            }
            Chart grafik = new Chart();
            chart1.Series.Clear();
            //Grafiğe değer ekleme
            chart1.Series.Add("Gri");
            for (int i = 0; i < 256; i++)
            {
                //eleman ekleme
                chart1.Series["Gri"].Points.Add(new DataPoint(i, gri[i]));
            }
            //Sütun renklerini belirleme
            chart1.Series["Gri"].Color = Color.Black;

            //Grafiği hafızaya kaydedip pictureBox2'ye koyma
            Bitmap sonuc = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Bmp);
                sonuc = new Bitmap(ms);
            }

            return sonuc;
        }
        public Bitmap tersleme(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(255 - bmp.GetPixel(i, j).R, 255 - bmp.GetPixel(i, j).G, 255 - bmp.GetPixel(i, j).B));
                }
            }
            return bmp;
        }
        public Bitmap solaDondur(Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp.Height, bmp.Width);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    b.SetPixel(j, b.Height - 1 - i, bmp.GetPixel(i, j));
                }
            }
            return b;

        }
        public Bitmap sagaDondur(Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp.Height, bmp.Width);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    b.SetPixel(b.Width - j - 1, i, bmp.GetPixel(i, j));
                }
            }
            return b;
        }
        public Bitmap sagaAynalama(Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    b.SetPixel(b.Width - i - 1, j, bmp.GetPixel(i, j));
                }
            }
            return b;
        }
        public Bitmap solaAynalama(Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    b.SetPixel(i, b.Height - j - 1, bmp.GetPixel(i, j));
                }
            }
            return b;
        }
        public Bitmap olceklendirme(Bitmap bmp, int genislik, int yukseklik)
        {
            Bitmap b = new Bitmap(bmp.GetThumbnailImage(genislik, yukseklik, null, new IntPtr(10000000)));
            return b;
        }
        public Bitmap griTonlama(Bitmap bmp)
        {
            int deger = 0;
            //Color sınıfından bir renk nesnesi tanımlandı
            Color renk;
            //Görüntüyü pixel pixel gezmek için
            for (int i = 0; i < bmp.Height - 1; i++) //dikey olarak
            {
                for (int j = 0; j < bmp.Width - 1; j++) //yatay olarak
                {
                    //Renkli görüntüden grey görüntü elde etmek
                    deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }
        public Bitmap kırmızıRenkKanalı(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(bmp.GetPixel(i, j).R, 0, 0));
                }
            }

            return bmp;
        }
        public Bitmap yesilRenkKanalı(Bitmap bmp)
        {

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, bmp.GetPixel(i, j).G));
                }
            }
            return bmp;
        }
        public Bitmap maviRenkKanalı(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(0, bmp.GetPixel(i, j).B, 0));
                }
            }
            return bmp;
        }

    }
}
