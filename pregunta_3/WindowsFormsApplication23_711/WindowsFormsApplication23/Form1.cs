using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int x, y;
        int mR = 0, mG = 0, mB = 0;
        private int[] texturas = new int[30];
        int puntero = 0;
        int cont = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPGE|*.jpg|Archivos GIF|*.gif" ;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

        }
        // no
        private void button2_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            c = bmp.GetPixel(10, 10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }
        //no
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width,bmp.Height);
            Color c=new Color();
            for (int i = 0; i < bmp.Width;i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i,j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R,0,0));

                }
            }
            pictureBox1.Image = bmp2;
        }
        // no
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, c.G, 0));

                }
            }
            pictureBox1.Image = bmp2;
        }
        // no
        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, c.B));

                }
            }
            pictureBox1.Image = bmp2;
        }
        //si
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Random rand = new Random();
            int max = byte.MaxValue + 1; // 256
            int r = rand.Next(max);
            int g = rand.Next(max);
            int b = rand.Next(max);
            cont++;

            if (cont <= 5)
            {
                x = e.X;
                y = e.Y;
                textBox4.Text = x.ToString();
                textBox5.Text = y.ToString();
                Color c = new Color();
                c = bmp.GetPixel(x, y);
                mR = 0; mG = 0; mB = 0;
                for (int i = x; i < x + 10; i++)
                {
                    for (int j = y; j < y + 10; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        mR = mR + c.R;
                        mG = mG + c.G;
                        mB = mB + c.B;

                    }
                }
                mR = mR / 100;
                mG = mG / 100;
                mB = mB / 100;

                texturas[puntero] = mR; puntero++;
                texturas[puntero] = mG; puntero++;
                texturas[puntero] = mB; puntero++;
                texturas[puntero] = r; puntero++;
                texturas[puntero] = g; puntero++;
                texturas[puntero] = b; puntero++;

                //Media de un segmento de px x  px
                textBox1.Text = mR.ToString();
                textBox2.Text = mG.ToString();
                textBox3.Text = mB.ToString();
                textBox6.Text = cont.ToString();
              //  textBox3.Text = mB.ToString();
            }
            else {
                MessageBox.Show("Ya no puede leer mas texturas");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //colorear fuxia  no
        private void button6_Click(object sender, EventArgs e)
        {
            Color c_leido = new Color();
            c_leido = bmp.GetPixel(x, y);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if ((c_leido.R - 10 <= c.R) && (c.R <= c_leido.R + 10)&&
                        (c_leido.R - 10 <= c.G) && (c.R <= c_leido.G + 10)&&
                        (c_leido.R - 10 <= c.B) && (c.R <= c_leido.B + 10))
                    {
                        //bmp2.SetPixel(i, j, Color.FromArgb(255,255,255));
                        bmp2.SetPixel(i, j, Color.Fuchsia);
                    }
                    else {
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R,c.G,c.B));
                    }
                }
            }
            pictureBox1.Image = bmp2;

        }

        //filto no
        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if ((c.R<255-10)&&(c.G>20)&&(c.B<255-30))
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R+10, c.G-20, c.B+30));
                    }
                   

                }
            }
            pictureBox1.Image = bmp2;
        }
        //si
        private void button8_Click(object sender, EventArgs e)
        {
       
            bool sw = false;
            

            int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width-10; i=i+10)
            
                for (int j = 0; j < bmp.Height-10; j=j+10)
                {
                    for (int i2 = i; i2 < i + 10; i2++) { 
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }
                     }
                        mRn = mRn / 100;
                        mGn = mGn / 100;
                        mBn = mBn / 100;

                    for (int z = 0; z < texturas.Length; z=z+6) {

                        if ((texturas[z] - 10 <= mRn) && (mRn <= texturas[z] + 10) &&
                        ((texturas[z + 1] - 10 <= mGn) && (mGn <= texturas[z + 1] + 10) &&
                        (texturas[z + 2] - 10 <= mBn) && (mBn <= texturas[z + 2] + 10)))
                        {
                            for (int i2 = i; i2 < i + 10; i2++)
                            {
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(texturas[z + 3], texturas[z + 4], texturas[z + 5]));
                                }
                            }
                            sw = true;
                            break;
                        }
                        else {
                            for (int i2 = i; i2 < i + 10; i2++)
                            {
                                for (int j2 = j; j2 < j + 10; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                            }
                        }


                    }
                    sw = false;
                    




                }

            pictureBox1.Image = bmp2;
        }

       
    }
}
