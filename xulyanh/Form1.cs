using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
struct Pixel
{
    public int R;
    public int G;
    public int B;
}
namespace xylyanh
{
    public partial class Form1 : Form
    {

        /***************************
         * ********************************/
        Bitmap bm, bmtg;
        OpenFileDialog openFile;
        public Bitmap taoanhxam(Bitmap b)
        {
            int[,] anh = new int[1500, 1500];
            Rectangle rec = new Rectangle(0, 0, b.Width, b.Height);
            BitmapData bdata = b.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bdata.Stride;
            int nOffset = stride - b.Width * 3;
            IntPtr ptr = bdata.Scan0;
            unsafe
            {
                byte* p = (byte*)ptr;
                int x, y;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = (p[2] + p[1] + p[0]) / 3;
                        anh[y, x] = c;
                        p += 3;
                    }
                    p += nOffset;
                }
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = anh[y, x];
                        p[0] = (byte)c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;
                        p += 3;
                    }
                    p += nOffset;
                }
            }
            b.UnlockBits(bdata);
            return b;
        }


        //fhdfhfh
        public Bitmap Gradient(Bitmap b, int nguong)
        {
            int[,] anh = new int[1500, 1500];       //ma trận ảnh ban đầu đưa vào

            int[,] anh1 = new int[1500, 1500];      //ma trận dùng để lưu trữ đường biên ( ảnh kết quả)
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x] = (p[0] + p[1] + p[2]) / 3;
                        p += 3;
                    }

                }
                b.UnlockBits(bdata);


                //qua trinh tim biên bằng đạo hàm bậc nhất
                int gt1, hx, hy, tong;
                for (i = 0; i < tg.Height - 1; i++)
                {
                    for (j = 1; j < tg.Width; j++)
                    {
                        gt1 = -(anh[i - 1, j - 1] + anh[i, j - 1] + anh[i + 1, j - 1]);
                        hx = Math.Abs(gt1 + (anh[i - 1, j + 1] + anh[i, j + 1] + anh[i + 1, j + 1]));
                        gt1 = -(anh[i - 1, j - 1] + anh[i - 1, j] + anh[i - 1, j + 1]);
                        hy = Math.Abs(gt1 + (anh[i + 1, j - 1] + anh[i + 1, j] + anh[i + 1, j + 1]));
                        tong = hx + hy;

                        anh1[i, j] = tong;
                    }
                }
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = anh1[y, x];
                        p[0] = (byte)c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;
                        p += 3;
                    }
                }
            }
            return tg;
        }
        /*------------------------thuat toan thuy van 1---------------------------------------*/
        public Bitmap WaterMarking1(Bitmap b, int nguong)
        {   //nhung 1 bit thuy van vao khoi 4x4
            string w = w1.Text;
            int bitNum;
            int bitNumMaybe;
            int countBit;
            Pixel[,] anh = new Pixel[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            Pixel[,] anh1 = new Pixel[1500, 1500];      //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x].R = p[0];
                        anh[y, x].G = p[1];
                        anh[y, x].B = p[2];
                        p += 3;
                    }

                }
                b.UnlockBits(bdata);
                //qua trinh tim biên bằng đạo hàm bậc nhất
                bitNum = w.Length * 8;
                bitNumMaybe = tg.Width / 8 * tg.Height / 8;
                //if (bitNum == 0) MessageBox("chưa nhập thông tin thủy vân!");
                if (bitNumMaybe > bitNum)
                {
                    for (i = 0; i <= tg.Height / 8 - 1; i++)
                    {
                        for (j = 0; j <= tg.Width / 8 - 1; j++)
                        {
                            countBit = 0;
                            for (x = i * 8; x < (i + 1) * 8; ++x)
                                for (y = j * 8; y < (j + 1) * 8; ++y)
                                {
                                    anh1[x, y] = anh[x, y];
                                    countBit += anh[x, y].R % 2;
                                }
                            if (countBit % 2 == 1)
                                anh1[i * 8, j * 8].R = (anh[i * 8, j * 8].R + 1) % 256;
                            else
                                anh1[i * 8, j * 8].G = (anh[i * 8, j * 8].G + 1) % 256;

                        }
                    }
                }
                //else
                //MessageBox("Kich thước thủy vân quá lớn!");
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        p[0] = (byte)anh1[y, x].R;
                        p[1] = (byte)anh1[y, x].G;
                        p[2] = (byte)anh1[y, x].B;
                        p += 3;
                    }
                }
            }
            return tg;
        }
        /*------------------------------------------------------------------------*/
        public Bitmap WaterMarking2(Bitmap b, int nguong)
        {   //nhung 1 bit thuy van vao khoi 4x4
            string w = w1.Text;
            int bitNum;
            int bitNumMaybe;
            int countBit;
            int[,] keyMatrix = new int[3, 3];
            keyMatrix[0, 0] = 0; keyMatrix[0, 1] = 1; keyMatrix[0, 2] = 0;
            keyMatrix[1, 0] = 1; keyMatrix[1, 1] = 1; keyMatrix[1, 2] = 1;
            keyMatrix[2, 0] = 0; keyMatrix[2, 1] = 1; keyMatrix[2, 2] = 0;
            Pixel[,] anh = new Pixel[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            Pixel[,] anh1 = new Pixel[1500, 1500];      //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x].R = p[0];
                        anh[y, x].G = p[1];
                        anh[y, x].B = p[2];
                        p += 3;
                    }
                }
                b.UnlockBits(bdata);
                //qua trinh tim biên bằng đạo hàm bậc nhất
                bitNum = w.Length * 8;
                bitNumMaybe = tg.Width / 3 * tg.Height / 3;
                //if (bitNum == 0) MessageBox("chưa nhập thông tin thủy vân!");
                if (bitNumMaybe > bitNum)
                {
                    for (i = 0; i <= tg.Height / 3 - 1; i++)
                    {
                        for (j = 0; j <= tg.Width / 3 - 1; j++)
                        {
                            countBit = 0;
                            for (x = i * 3; x < (i + 1) * 3; ++x)
                                for (y = j * 3; y < (j + 1) * 3; ++y)
                                {
                                    anh1[x, y] = anh[x, y];
                                    if (keyMatrix[x % 3, y % 3] == 1)
                                        countBit += anh[x, y].R % 2;
                                }
                            if (countBit % 2 == 1)
                                anh1[i * 3 + 1, j * 3 + 1].R = (anh[i * 3 + 1, j * 3 + 1].R + 1) % 256;
                            else
                                anh1[i * 3 + 1, j * 3 + 1].G = (anh[i * 3 + 1, j * 3 + 1].G + 1) % 256;

                        }
                    }
                }
                //else
                //MessageBox("Kich thước thủy vân quá lớn!");
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        p[0] = (byte)anh1[y, x].R;
                        p[1] = (byte)anh1[y, x].G;
                        p[2] = (byte)anh1[y, x].B;
                        p += 3;
                    }
                }
            }
            return tg;
        }
        /*----------------------------------------------------------------*/
        public Bitmap WaterMarking3(Bitmap b, int nguong)
        {   //nhung 2 bit thuy van vao khoi 3x3
            string w = w1.Text;
            int bitNum;//so bit can dau
            int bitNumMaybe;//tổng so bit co the dau vao anh
            int bitPerBlock = 2;//số bit can dau trong mot khoi 3x3
            int countBit;
            int[,] keyMatrix = new int[3, 3];
            int[,] weighMatrix = new int[3, 3];
            keyMatrix[0, 0] = 0; keyMatrix[0, 1] = 1; keyMatrix[0, 2] = 0;
            keyMatrix[1, 0] = 1; keyMatrix[1, 1] = 1; keyMatrix[1, 2] = 1;
            keyMatrix[2, 0] = 0; keyMatrix[2, 1] = 1; keyMatrix[2, 2] = 0;
            weighMatrix[0, 0] = 0; weighMatrix[0, 1] = 1; weighMatrix[0, 2] = 2;
            weighMatrix[1, 0] = 1; weighMatrix[1, 1] = 2; weighMatrix[1, 2] = 3;
            weighMatrix[2, 0] = 0; weighMatrix[2, 1] = 1; weighMatrix[2, 2] = 3;
            Pixel[,] anh = new Pixel[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            Pixel[,] anh1 = new Pixel[1500, 1500];      //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x].R = p[0];
                        anh[y, x].G = p[1];
                        anh[y, x].B = p[2];
                        p += 3;
                    }
                }
                b.UnlockBits(bdata);
                //qua trinh tim biên bằng đạo hàm bậc nhất
                bitNum = w.Length * 8;
                bitNumMaybe = tg.Width / 3 * tg.Height / 3 * 2;
                //if (bitNum == 0) MessageBox("chưa nhập thông tin thủy vân!");
                if (bitNumMaybe > bitNum)
                {
                    for (i = 0; i <= tg.Height / 3 - 1; i++)
                    {
                        for (j = 0; j <= tg.Width / 3 - 1; j++)
                        {
                            countBit = 0;
                            for (x = i * 3; x < (i + 1) * 3; ++x)
                                for (y = j * 3; y < (j + 1) * 3; ++y)
                                {
                                    anh1[x, y] = anh[x, y];
                                    if (keyMatrix[x % 3, y % 3] == 1)
                                        countBit += weighMatrix[x % 3, y % 3];
                                }
                            if (countBit % 2 == 1)
                                anh1[i * 8, j * 8].R = (anh[i * 8, j * 8].R + 1) % 256;
                            else
                                anh1[i * 8, j * 8].G = (anh[i * 8, j * 8].G + 1) % 256;

                        }
                    }
                }
                //else
                //MessageBox("Kich thước thủy vân quá lớn!");
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        p[0] = (byte)anh1[y, x].R;
                        p[1] = (byte)anh1[y, x].G;
                        p[2] = (byte)anh1[y, x].B;
                        p += 3;
                    }
                }
            }
            return tg;
        }
        /*----------------------------------------------------------------*/
        /// <summary>

        /// </summary>
        /// <param name="b"></param>
        /// <param name="nguong"></param>
        /// <returns></returns>

        public Bitmap Laplace(Bitmap b, int nguong)
        {
            int[,] anh = new int[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            int[,] anh1 = new int[1500, 1500];      //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x] = (p[0] + p[1] + p[2]) / 3;
                        p += 3;
                    }

                }
                b.UnlockBits(bdata);

                for (i = 0; i < tg.Height; i++)
                {
                    for (j = 0; j < tg.Width; j++)
                    {
                        anh1[i, j] = 0;
                    }
                }
                //qua trinh tim biên bằng đạo hàm bậc nhất

                for (i = 1; i < tg.Height - 1; i++)
                {
                    for (j = 1; j < tg.Width - 1; j++)
                    {

                        anh1[i, j] = Math.Abs(-anh[i, j - 1] - anh[i, j + 1] - anh[i - 1, j] - anh[i + 1, j] + 4 * anh[i, j]);
                    }
                }
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = anh1[y, x];
                        p[0] = (byte)c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;
                        p += 3;
                    }
                }
            }
            return tg;
        }
        public Bitmap Tangdosang(Bitmap b)
        {
            int[,] anh = new int[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            int[,] anh1 = new int[1500, 1500];      //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x] = (p[0] + p[1] + p[2]) / 3;
                        p += 3;
                    }

                }
                b.UnlockBits(bdata);


                //qua trinh tim biên bằng đạo hàm bậc nhất

                for (i = 0; i < tg.Height; i++)
                {
                    for (j = 0; j < tg.Width; j++)
                    {
                        if ((anh[i, j] + 50) > 255)
                        {
                            anh1[i, j] = anh[i, j];
                        }
                        else
                        {
                            anh1[i, j] = anh[i, j] + 50;
                        }
                    }
                }
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = anh1[y, x];
                        p[0] = (byte)c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;
                        p += 3;
                    }
                }
            }
            return tg;
        }


        public Bitmap DenTrang(Bitmap b)
        {
            int[,] anh = new int[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            int[,] anh1 = new int[1500, 1500];      //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x] = (p[0] + p[1] + p[2]) / 3;
                        p += 3;
                    }

                }
                b.UnlockBits(bdata);


                //qua trinh tim biên bằng đạo hàm bậc nhất

                for (i = 0; i < tg.Height; i++)
                {
                    for (j = 0; j < tg.Width; j++)
                    {
                        if ((anh[i, j]) < 127)
                        {
                            anh1[i, j] = 0;
                        }
                        else
                        {
                            anh1[i, j] = 255;
                        }
                    }
                }
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = anh1[y, x];
                        p[0] = (byte)c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;
                        p += 3;
                    }
                }
            }
            return tg;
        }

        public void OpenFile()
        {
            Bitmap originalBitmap;
            try
            {
                openFile = new OpenFileDialog();
                openFile.InitialDirectory = Application.ExecutablePath;
                openFile.Filter = "All File(*.jpg, *.bmp)|*.jpg;*.bmp|JPEG images(*.jpg)|*.jpg|Bitmap image(*.bmp)|*.bmp";
                openFile.FilterIndex = 0;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    bm = (Bitmap)Bitmap.FromFile(openFile.FileName);
                    originalBitmap = (Bitmap)bm.Clone();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.ClientSize = new Size(bm.Width, bm.Height);
                    pictureBox1.Image = (Image)bm;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông báo lỗi", "Có lỗi khi đọc file :\n" + ex.ToString());
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            OpenFile();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(1500, 1500, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        }

        private void btReadFile_Click(object sender, EventArgs e)
        {
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            bmtg = taoanhxam(bmtg);
            //bmtg = WaterMarking1(bmtg, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            //bmtg = taoanhxam(bmtg);
            bmtg = WaterMarking2(bmtg, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            //bmtg = taoanhxam(bmtg);
            bmtg = WaterMarking3(bmtg, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;

        }
        private void b2_Click(object sender, EventArgs e)
        {
            // Đọc file ảnh
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            // CHuyển ảnh về đa cấp xám, cân bằng histogram
            bmtg = histogram(bmtg);
            // Show dữ liệu đã xử lý
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;

        }

        private void b3_Click(object sender, EventArgs e)
        {
            //bmtg = bm;
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            bmtg = taoanhxam(bmtg);
            bmtg = Laplace(bmtg, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDT_Click(object sender, EventArgs e)
        {
            try
            {
                bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
                bmtg = DenTrang(bmtg);
                bmtg = taoanhxam(bmtg);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
                pictureBox2.Image = (Image)bmtg;
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            bmtg = taoanhxam(bmtg);
            bmtg = Tangdosang(bmtg);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;
        }
        public Bitmap Tangdosangmau(Bitmap b,int doTang)
        {
            Pixel[,] anh = new Pixel[1500, 1500];       //ma trận ảnh ban đầu đưa vào
            Pixel[,] anh1 = new Pixel[1500, 1500];    //ma trận dùng để lưu trữ đường biên
            int x, y, i, j;
            Bitmap tg = b;                          //khunhieunhan(b,nguong);
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;               //ptr quản lý ngay vùng nhớ đầu tiên của dữ liệu ảnh
            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anh[y, x].R = p[0];
                        anh[y, x].G = p[1];
                        anh[y, x].B = p[2];
                        p += 3;
                    }

                }
                b.UnlockBits(bdata);


                //qua trinh tim biên bằng đạo hàm bậc nhất

                for (i = 0; i < tg.Height; i++)
                {
                    for (j = 0; j < tg.Width; j++)
                    {
                        if ((anh[i, j].R + doTang) > 255)
                        {
                            anh1[i, j].R = 255;
                        }
                        else
                        {
                            anh1[i, j].R = anh[i, j].R + doTang;
                        }
                        if ((anh[i, j].G + doTang) > 255)
                        {
                            anh1[i, j].G = 255;
                        }
                        else
                        {
                            anh1[i, j].G = anh[i, j].G + doTang;
                        }
                        if ((anh[i, j].B + doTang) > 255)
                        {
                            anh1[i, j].B = 255;
                        }
                        else
                        {
                            anh1[i, j].B = anh[i, j].B + doTang;
                        }
                    }
                }
                //gan lai từ ma trận vào ảnh
                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int R = anh1[y, x].R;
                        int G = anh1[y, x].G;
                        int B = anh1[y, x].B;
                        p[0] = (byte)R;
                        p[1] = (byte)G;
                        p[2] = (byte)B;
                        p += 3;
                    }
                }
            }
            return tg;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bmtg = (Bitmap)Bitmap.FromFile(openFile.FileName);
            bmtg = Tangdosangmau(bmtg,80);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ClientSize = new Size(bmtg.Width, bmtg.Height);
            pictureBox2.Image = (Image)bmtg;
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save= new SaveFileDialog();
            save.Title = "Save";
            save.DefaultExt = "jpg";
            save.Filter = "All File(*.jpg, *.bmp)|*.jpg;*.bmp|JPEG images(*.jpg)|*.jpg|Bitmap image(*.bmp)|*.bmp";
            save.FilterIndex = 0;
            save.RestoreDirectory = true;
            if(save.ShowDialog()==DialogResult.OK)
            {
                pictureBox2.Image.Save(save.FileName);
            }
        }




        public Bitmap histogram(Bitmap b)
        {
            int[,] anhGoc = new int[1500, 1500];
            int[,] anhSau = new int[1500, 1500];
            int x, y, i, j;
            Bitmap tg = b;
            Rectangle rec = new Rectangle(0, 0, tg.Width, tg.Height);
            BitmapData bdata = tg.LockBits(rec, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = bdata.Scan0;


            int[] arr = new int[256];
            int[] arrm = new int[256];
            int total = 0;
            int size = tg.Height * tg.Width;
            for (int k = 0; k <= 255; k++)
            {
                arr[k] = 0;
            }

            unsafe
            {
                byte* p = (byte*)ptr;

                for (y = 0; y < tg.Height; y++)
                {
                    for (x = 0; x < tg.Width; x++)
                    {
                        anhGoc[y, x] = (p[0] + p[1] + p[2]) / 3;
                        p += 3;
                    }

                }

                b.UnlockBits(bdata);
                int g = 0;
                for (i = 0; i < tg.Height; i++)
                {
                    for (j = 0; j < tg.Width; j++)
                    {
                        arr[anhGoc[i, j]]++;
                    }
                }

                for (int z = 0; z <= 255; z++)
                {
                    total += arr[z];
                    arrm[z] = (total * 255 / size);
                }

                for (i = 0; i < tg.Height; i++)
                {
                    for (j = 0; j < tg.Width; j++)
                    {
                        anhSau[i, j] = arrm[anhGoc[i, j]];
                    }
                }

                p = (byte*)ptr;
                for (y = 0; y < b.Height; y++)
                {
                    for (x = 0; x < b.Width; x++)
                    {
                        int c = anhSau[y, x];
                        p[0] = (byte)c;
                        p[1] = (byte)c;
                        p[2] = (byte)c;
                        p += 3;
                    }
                }
            }

            return b;
        }

    }
}
