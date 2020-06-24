using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Kaliko.ImageLibrary;
using Kaliko.ImageLibrary.Filters;


namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private List<Bitmap> _bitmaps2;
        private List<Bitmap> _bitmaps1;
        public Bitmap bmp = null;
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // диалог для выбора файла
            OpenFileDialog ofd = new OpenFileDialog();
            // фильтр форматов файлов
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // если в диалоге была нажата кнопка ОК
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // загружаем изображение
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Y-chanal
        public void Ychanal(object b22)
        {
            Bitmap b2 = new Bitmap((Bitmap)b22);
            Bitmap outB2 = new Bitmap(b2);
            try
            {
                for (int i = 0; i < b2.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b2.Height; j++)
                    {
                        Color c = b2.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        double rYUV = 0.299;
                        double gYUV = 0.587;
                        double bYUV = 0.114;
                        int yYUV;
                        yYUV = Convert.ToInt32(rYUV * Convert.ToDouble(r) + gYUV * Convert.ToDouble(g) + bYUV * Convert.ToDouble(b));
                        if (yYUV > 255)
                        {
                            yYUV = 255;
                        }
                        if (yYUV < 0)
                        {
                            yYUV = 0;
                        }
                        r = yYUV;
                        g = yYUV;
                        b = yYUV;
                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (b > 255)
                        {
                            b = 255;
                        }
                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }
                        outB2.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                Action action2 = () =>
                {
                    pictureBox2.Image = new Bitmap(outB2);
                };
                if (InvokeRequired)
                    Invoke(action2);
                else
                    action2();
            }
            catch { }
        }

        //U-chanal
        public void Uchanal(object b33)
        {
            Bitmap b3 = new Bitmap((Bitmap)b33);
            Bitmap outB3 = new Bitmap(b3);
            try
            {
                for (int i = 0; i < b3.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b3.Height; j++)
                    {
                        Color c = b3.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        double rYUV = -0.147;
                        double gYUV = -0.289;
                        double bYUV = 0.436;
                        int uYUV;
                        uYUV = Convert.ToInt32(rYUV * Convert.ToDouble(r) + gYUV * Convert.ToDouble(g) + bYUV * Convert.ToDouble(b));
                        if (uYUV > 112)
                        {
                            uYUV = 112;
                        }
                        if (uYUV < -112)
                        {
                            uYUV = -112;
                        }

                        r = 127;
                        g = Convert.ToInt32(127+(-0.395) * uYUV);
                        b = Convert.ToInt32(127+2.032 * uYUV);
                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (b > 255)
                        {
                            b = 255;
                        }
                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }

                        outB3.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                Action action3 = () =>
                {
                    pictureBox3.Image = new Bitmap(outB3);
                };
                if (InvokeRequired)
                    Invoke(action3);
                else
                    action3();
            }
            catch { }
        }

        //V-chanal
        public void Vchanal(object b44)
        {
            Bitmap b4 = new Bitmap((Bitmap)b44);
            Bitmap outB4 = new Bitmap(b4);
            try
            {
                for (int i = 0; i < b4.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b4.Height; j++)
                    {
                        Color c = b4.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        double rYUV = 0.615;
                        double gYUV = -0.515;
                        double bYUV = -0.1;
                        int vYUV;
                        vYUV = Convert.ToInt32(rYUV * r + gYUV * g + bYUV * b);
                        if (vYUV > 157)
                        {
                            vYUV = 157;
                        }
                        if (vYUV < -157)
                        {
                            vYUV = -157;
                        }

                        r = Convert.ToInt32(127+1.14 * vYUV);
                        g = Convert.ToInt32(127-0.581 * vYUV);
                        b = 127;
                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (b > 255)
                        {
                            b = 255;
                        }
                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }

                        outB4.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                Action action4 = () =>
                {
                    pictureBox4.Image = new Bitmap(outB4);
                };
                if (InvokeRequired)
                    Invoke(action4);
                else
                    action4();
            }
            catch { }
        }

        //UV-chanal
        public void UVchanal(object b55)
        {
            Bitmap b5 = new Bitmap((Bitmap)b55);
            Bitmap outB5 = new Bitmap(b5);
            try
            {
                for (int i = 0; i < b5.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b5.Height; j++)
                    {
                        Color c = b5.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        double rvYUV = 0.615;
                        double gvYUV = -0.515;
                        double bvYUV = -0.1;
                        int vYUV;
                        
                        vYUV = Convert.ToInt32(rvYUV * Convert.ToDouble(r) + gvYUV * Convert.ToDouble(g) + bvYUV * Convert.ToDouble(b));
                        if (vYUV > 157)
                        {
                            vYUV = 157;
                        }
                        if (vYUV < -157)
                        {
                            vYUV = -157;
                        }
                        double ruYUV = -0.147;
                        double guYUV = -0.289;
                        double buYUV = 0.436;
                        int uYUV;
                        uYUV = Convert.ToInt32(ruYUV * Convert.ToDouble(r) + guYUV * Convert.ToDouble(g) + buYUV * Convert.ToDouble(b));
                        if (uYUV > 112)
                        {
                            uYUV = 112;
                        }
                        if (uYUV < -112)
                        {
                            uYUV = -112;
                        }

                        r = Convert.ToInt32(127+1.14 * vYUV);
                        g = Convert.ToInt32(127+(-0.395) * uYUV + (-0.581) * vYUV);
                        b = Convert.ToInt32(127+2.032 * uYUV);
                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (b > 255)
                        {
                            b = 255;
                        }
                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }

                        outB5.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                Action action5 = () =>
                {
                    pictureBox5.Image = new Bitmap(outB5);
                };

                if (InvokeRequired)
                    Invoke(action5);
                else
                    action5();
            }
            catch { }
        }

        public void calculateBarChart(object b66)
        {
            Bitmap barChart = null;
            int width = 768, height = 600;
            Bitmap bmp = new Bitmap((Bitmap)b66);
            barChart = new Bitmap(width, height);
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            int i, j;
            Color color;
            for (i = 0; i < bmp.Width; ++i)
                for (j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);
                    ++R[color.R];
                    ++G[color.G];
                    ++B[color.B];
                }
            int max = 0;
            for (i = 0; i < 256; ++i)
            {
                if (R[i] > max)
                    max = R[i];
                if (G[i] > max)
                    max = G[i];
                if (B[i] > max)
                    max = B[i];
            }
            double point = (double)max / height;
            for (i = 0; i < width - 3; ++i)
            {
                for (j = height - 1; j > height - R[i / 3] / point; --j)
                {
                    barChart.SetPixel(i, j, Color.Red);
                }
                ++i;
                for (j = height - 1; j > height - G[i / 3] / point; --j)
                {
                    barChart.SetPixel(i, j, Color.Green);
                }
                ++i;
                for (j = height - 1; j > height - B[i / 3] / point; --j)
                {
                    barChart.SetPixel(i, j, Color.Blue);
                }
            }

            Action action6 = () =>
            {
                pictureBox6.Image = new Bitmap(barChart);
            };

            if (InvokeRequired)
                Invoke(action6);
            else
                action6();
        }

        public void Autolevels(object b22)
        {
            Bitmap b2 = new Bitmap((Bitmap)b22);
            Bitmap outB2 = new Bitmap(b2);
            int rmax = 0;
            int rmin = 255;
            int gmax = 0;
            int gmin = 255;
            int bmax = 0;
            int bmin = 255;
            try
            {
                for (int i = 0; i < b2.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b2.Height; j++)
                    {
                        Color c = b2.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        if (rmin > r)
                            rmin = r;
                        if (rmax < r)
                            rmax = r;
                        if (gmin > g)
                            gmin = g;
                        if (gmax < g)
                            gmax = g;
                        if (bmin > b)
                            bmin = b;
                        if (bmax < b)
                            bmax = b;
                    }
                }



                for (int i = 0; i < b2.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b2.Height; j++)
                    {
                        Color c = b2.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        int rnew;
                        rnew = Convert.ToInt32((r-rmin)*(255/(rmax-rmin)));
                        if (rnew > 255)
                        {
                            rnew = 255;
                        }
                        if (rnew < 0)
                        {
                            rnew = 0;
                        }

                        int gnew;
                        gnew = Convert.ToInt32((g - gmin) * (255 / (gmax - gmin)));
                        if (gnew > 255)
                        {
                            gnew = 255;
                        }
                        if (gnew < 0)
                        {
                            gnew = 0;
                        }

                        int bnew;
                        bnew = Convert.ToInt32((b - bmin) * (255 / (bmax - bmin)));
                        if (bnew > 255)
                        {
                            bnew = 255;
                        }
                        if (bnew < 0)
                        {
                            bnew = 0;
                        }

                        outB2.SetPixel(i, j, Color.FromArgb(rnew, gnew, bnew));
                    }
                }               
                        
                Action action2 = () =>
                {
                    pictureBox7.Image = new Bitmap(outB2);
                };
                if (InvokeRequired)
                    Invoke(action2);
                else
                    action2();
            }
            catch { }
        }

        public void brightness(object b22)
        {
            Bitmap b2 = new Bitmap(pictureBox1.Image);//удали если не получилось
            //Bitmap b2 = new Bitmap((Bitmap)b22);
            Bitmap outB2 = new Bitmap(b2);
            //int rmax = 0;
            //int rmin = 255;
            //int gmax = 0;
            //int gmin = 255;
            //int bmax = 0;
            //int bmin = 255;
            int y = 0;
             

            try
            {
               for (int i = 0; i < b2.Width; i++)
                {
                    //double pc = (double)i * (double)100 / bmp.Width;
                    for (int j = 0; j < b2.Height; j++)
                    {
                        Color c = b2.GetPixel(i, j);
                        int r = c.R;
                        int g = c.G;
                        int b = c.B;
                        //int y = Change;
                        double rYUV = 0.299;
                        double gYUV = 0.587;
                        double bYUV = 0.114;
                        int yYUV;
                        yYUV = Convert.ToInt32(rYUV * Convert.ToDouble(r) + gYUV * Convert.ToDouble(g) + bYUV * Convert.ToDouble(b));
                        if (yYUV > 255)
                        {
                            yYUV = 255;
                        }
                        if (yYUV < 0)
                        {
                            yYUV = 0;
                        }
                        y = yYUV+Convert.ToInt32(b22);
                        if (y > 255)
                        {
                            y = 255;
                        }
                        if (y < 0)
                        {
                            y = 0;
                        }
                        int rnew;
                        rnew = Convert.ToInt32(y + 0.7011 * r - 0.5871 * g - 0.114 * b);
                        if (rnew > 255)
                        {
                            rnew = 255;
                        }
                        if (rnew < 0)
                        {
                            rnew = 0;
                        }

                        int gnew;
                        gnew = Convert.ToInt32(y - 0.29925 * r + 0.41337 * g - 0.11412 * b);
                        if (gnew > 255)
                        {
                            gnew = 255;
                        }
                        if (gnew < 0)
                        {
                            gnew = 0;
                        }

                        int bnew;
                        bnew = Convert.ToInt32(y - 0.298704 * r - 0.587248 * g + 0.885952 * b);
                        if (bnew > 255)
                        {
                            bnew = 255;
                        }
                        if (bnew < 0)
                        {
                            bnew = 0;
                        }

                        outB2.SetPixel(i, j, Color.FromArgb(rnew, gnew, bnew));
                    }
                }

                Action action2 = () =>
                {
                    pictureBox8.Image = new Bitmap(outB2);
                    trackBar1.Enabled = true;
                };
                if (InvokeRequired)
                    Invoke(action2);
                else
                    action2();
            }
            catch { }
        }

        public void Unsharpmask(object b22)
        {
            KalikoImage image = new KalikoImage("C:\\Users\\Dima\\Pictures\\1.jpg");

            // Create a thumbnail of 128x128 pixels
            KalikoImage thumb = image.GetThumbnailImage(128, 128, ThumbnailMethod.Crop);

            // Apply unsharpen filter (radius = 1.4, amount = 32%, threshold = 0)
            thumb.ApplyFilter(new UnsharpMaskFilter(1.4f, 0.32f, 0));

            // Save the thumbnail as JPG in quality 99 (very high)
            thumb.SaveJpg("C:\\Users\\Dima\\Pictures\\1111.jpg", 99);
        }

        public int Casaburi(int i,int j,int n,int m,int RGB,int threshold,int chanal)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int rgb = 0;
            Color c1 = bmp.GetPixel(i, j);
            if (chanal == 0)
                rgb = c1.R;
            if (chanal == 1)
                rgb = c1.G;
            if (chanal == 2)
                rgb = c1.B;
            int rgb1 = 0;
            int count_rgb = 0;
            int tot_rgb = 0;
            int N = Convert.ToInt32(i - 0.5 + n / 2);
            int M = Convert.ToInt32(j - 0.5 + m / 2);
            for (int x = 0-N; x < i+N; x++)
            {
                for (int y = 0-N; y < i+M; y++)
                {
                    if (x < 0)
                        rgb = RGB;
                    if (y < 0)
                        rgb = RGB;
                    if((i==x) && (j==y))
                        rgb = RGB;
                    Color c2 = bmp.GetPixel(x, y);
                    if (chanal == 0)
                        rgb1 = c1.R;
                    if (chanal == 1)
                        rgb1 = c1.G;
                    if (chanal == 2)
                        rgb1 = c1.B;




                    if (Math.Abs(rgb1 - rgb) < threshold)
                    { tot_rgb += rgb1; count_rgb++; }
                }
            }

            return rgb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                // создаём Bitmap для черно-белого изображения
                //Bitmap output = new Bitmap(bmp.Width, bmp.Height);
                Thread Ythread = new Thread(Ychanal);
                Ythread.Start(bmp);
                Thread Uthread = new Thread(Uchanal);
                Uthread.Start(bmp);
                Thread Vthread = new Thread(Vchanal);
                //Vthread.Start(bmp);
                Thread UVthread = new Thread(UVchanal);
                //UVthread.Start(bmp);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Thread CBHthread = new Thread(calculateBarChart);
                CBHthread.Start(bmp);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
            {
                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Thread Autolevelsthread = new Thread(Autolevels);
                Autolevelsthread.Start(bmp);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                int Change;
                Change = trackBar1.Value;
                trackBar1.Enabled = false;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Thread brightnessthread = new Thread(brightness);
                brightnessthread.Start(Change);
            }
            catch
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            //Thread Unsharpmaskthread = new Thread(Unsharpmask);
            //Unsharpmaskthread.Start(bmp);
            KalikoImage image = new KalikoImage("C:\\Users\\Dima\\Pictures\\1.jpg");

            // Create a thumbnail of 128x128 pixels
            //KalikoImage thumb = image.GetThumbnailImage(128, 128, ThumbnailMethod.Crop);

            // Apply unsharpen filter (radius = 1.4, amount = 32%, threshold = 0)
            image.ApplyFilter(new UnsharpMaskFilter(1.4f, 0.32f, 0));

            // Save the thumbnail as JPG in quality 99 (very high)
            image.SaveJpg("C:\\Users\\Dima\\Pictures\\1111.jpg", 99);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            int Threshold = 30;
            for (int i = 1; i < (bmp.Width - 1); i++)
            {
                //double pc = (double)i * (double)100 / bmp.Width;
                for (int j = 1; j < (bmp.Height - 1); j++)
                {
                    int count_r = 0;
                    int count_g = 0;
                    int count_b = 0;
                    int tot_r = 0;
                    int tot_g = 0;
                    int tot_b = 0;
                    Color c = bmp.GetPixel(i, j);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    Color c1 = bmp.GetPixel(i-1, j+1);
                    int r1 = c1.R;
                    if (Math.Abs(r1-r)< Threshold)
                    { tot_r += r1; count_r++; }
                    int g1 = c1.G;
                    if (Math.Abs(g1 - g) < Threshold)
                    { tot_g += g1; count_g++; }
                    int b1 = c1.B;
                    if (Math.Abs(b1 - b) < Threshold)
                    { tot_b += b1; count_b++; }

                    Color c2 = bmp.GetPixel(i, j+1);
                    int r2 = c2.R;
                    if (Math.Abs(r2 - r) < Threshold)
                    { tot_r += r2; count_r++; }
                    int g2 = c2.G;
                    if (Math.Abs(g2 - g) < Threshold)
                    { tot_g += g2; count_g++; }
                    int b2 = c2.B;
                    if (Math.Abs(b2 - b) < Threshold)
                    { tot_b += b2; count_b++; }

                    Color c3 = bmp.GetPixel(i+1, j+1);
                    int r3 = c3.R;
                    if (Math.Abs(r3 - r) < Threshold)
                    { tot_r += r3; count_r++; }
                    int g3 = c3.G;
                    if (Math.Abs(g3 - g) < Threshold)
                    { tot_g += g3; count_g++; }
                    int b3 = c3.B;
                    if (Math.Abs(b3 - b) < Threshold)
                    { tot_b += b3; count_b++; }

                    Color c4 = bmp.GetPixel(i+1, j);
                    int r4 = c4.R;
                    if (Math.Abs(r4 - r) < Threshold)
                    { tot_r += r4; count_r++; }
                    int g4 = c4.G;
                    if (Math.Abs(g4 - g) < Threshold)
                    { tot_g += g4; count_g++; }
                    int b4 = c4.B;
                    if (Math.Abs(b4 - b) < Threshold)
                    { tot_b += b4; count_b++; }

                    Color c5 = bmp.GetPixel(i+1, j-1);
                    int r5 = c5.R;
                    if (Math.Abs(r5 - r) < Threshold)
                    { tot_r += r5; count_r++; }
                    int g5 = c5.G;
                    if (Math.Abs(g5 - g) < Threshold)
                    { tot_g += g5; count_g++; }
                    int b5 = c5.B;
                    if(Math.Abs(b5 - b) < Threshold)
                    { tot_b += b5; count_b++; }

                    Color c6 = bmp.GetPixel(i, j-1);
                    int r6 = c6.R;
                    if (Math.Abs(r6 - r) < Threshold)
                    { tot_r += r6; count_r++; }
                    int g6 = c6.G;
                    if (Math.Abs(g6 - g) < Threshold)
                    { tot_g += g6; count_g++; }
                    int b6 = c6.B;
                    if (Math.Abs(b6 - b) < Threshold)
                    { tot_b += b6; count_b++; }

                    Color c7 = bmp.GetPixel(i-1, j-1);
                    int r7 = c7.R;
                    if (Math.Abs(r7 - r) < Threshold)
                    { tot_r += r7; count_r++; }
                    int g7 = c7.G;
                    if (Math.Abs(g7 - g) < Threshold)
                    { tot_g += g7; count_g++; }
                    int b7 = c7.B;
                    if (Math.Abs(b7 - b) < Threshold)
                    { tot_b += b7; count_b++; }

                    Color c8 = bmp.GetPixel(i-1, j);
                    int r8 = c8.R;
                    if (Math.Abs(r8 - r) < Threshold)
                    { tot_r += r8; count_r++; }
                    int g8 = c8.G;
                    if (Math.Abs(g8 - g) < Threshold)
                    { tot_g += g8; count_g++; }
                    int b8 = c8.B;
                    if (Math.Abs(b8 - b) < Threshold)
                    { tot_b += b8; count_b++; }
                    int rnew=r;
                    int gnew=g;
                    int bnew=b;
                    if (count_r != 0)
                    {
                       
                        rnew = Convert.ToInt32(tot_r / count_r);
                        if (rnew > 255)
                        {
                            rnew = 255;
                        }
                        if (rnew < 0)
                        {
                            rnew = 0;
                        }
                    }

                    if (count_g != 0)
                    {
                        
                        gnew = Convert.ToInt32(tot_g / count_g);
                        if (gnew > 255)
                        {
                            gnew = 255;
                        }
                        if (gnew < 0)
                        {
                            gnew = 0;
                        }
                    }

                    if (count_b != 0)
                    {
                        
                        bnew = Convert.ToInt32(tot_b / count_b);
                        if (bnew > 255)
                        {
                            bnew = 255;
                        }
                        if (bnew < 0)
                        {
                            bnew = 0;
                        }
                    }
                    bmp1.SetPixel(i, j, Color.FromArgb(rnew, gnew, bnew));
                    
                }
            }
            pictureBox10.Image = new Bitmap(bmp1);
        }

        private void button7_Click(object sender, EventArgs e)
        {           
            if (pictureBox10.Image!=null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|ALL files(*.*)|*.*";
                sfd.ShowHelp = true;
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    try
                    {
                        pictureBox10.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (_bitmaps1==null || _bitmaps1.Count==0)
            { return; }
            pictureBox11.Image = _bitmaps1[trackBar2.Value - 1];
        }
        //int Change = 0;
    }
}
