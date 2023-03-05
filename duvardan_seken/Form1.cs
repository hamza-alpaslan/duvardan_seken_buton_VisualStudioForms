namespace duvardan_seken
{
    public partial class Form1 : Form
    {
        //https://github.com/hamza-alpaslan
        // x ve y yönlerindeki hızının ayarlanabilir. düğmeye tıklandığında random_color özelliğinin devreye girip çıktığı,
        // random_color aktifse arka planın rastgele renk atanır ve bir okla, butonun gittiği yön gösteriliyor
        public Form1()
        {
            InitializeComponent();
            blue.Text = "RANDOM COLOR(X)";
        }

        bool randomcolor = false;
        int sayıx = 1; 
        int sayıy = 1; 
        bool yonsag = true;
        bool yonasagi = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Image flipImage = pictureBox1.Image;

            label1.Text = "x hızı=" + sayıx;
            label2.Text = "y hızı" + sayıy;
            if (blue.Location.X + blue.Size.Width + 13 >= this.Size.Width)// sağ duvara çarpma kontrolü
            {

                yonsag = false;

                if (sayıx > 0)//okun sadece sağdan gelip duvara çarptığında döndürülmesi için(taşmalar için)
                {
                    flipImage = pictureBox1.Image;
                    flipImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pictureBox1.Image = flipImage;
                }
                if (randomcolor == true) renk_degis();
            }
            if (blue.Location.Y + blue.Size.Height + 39 >= this.Size.Height)// alt duvara çarpma kontrolü
            {
                yonasagi = false;
                if (sayıy > 0)//okun sadece yukardan gelip duvara çarptığında döndürülmesi için(taşmalar için)
                {
                    flipImage = pictureBox1.Image;
                    flipImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    pictureBox1.Image = flipImage;

                }

                if (randomcolor == true) renk_degis();
            }
            if (blue.Location.Y <= 0)// üst duvara çarpma kontrolü
            {
                //ust ve sol duvar için taşma kontrolune gerek yok
                flipImage = pictureBox1.Image;
                flipImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                pictureBox1.Image = flipImage;
                yonasagi = true;

                if (randomcolor == true) renk_degis();
            }
            if (blue.Location.X <= 0)// sol duvara çarpma kontrolü
            {
                yonsag = true;
                flipImage = pictureBox1.Image;
                flipImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox1.Image = flipImage;

                if (randomcolor == true) renk_degis();
            }
            

            // x ve y hızının negatif-pozitiflik ayarlanması
            if (yonsag == true)
            {
                if (sayıx <= 0)
                {
                    sayıx = -sayıx;
                }
            }

            if (yonsag == false)
            {
                if (sayıx >= 0)
                {
                    sayıx = -sayıx;
                }
            }
            if (yonasagi == true)
            {
                if (sayıy < 0)
                {
                    sayıy = -sayıy;
                }
            }
            if (yonasagi == false)
            {
                if (sayıy >= 0)
                {
                    sayıy = -sayıy;
                }
            }

            blue.Location = new Point(blue.Location.X + sayıx, blue.Location.Y + sayıy);

        }
        private void renk_degis()
        {
            Random rand = new Random();
            int red = rand.Next() % 256;
            int green = rand.Next() % 256;
            int blue = rand.Next() % 256;
            BackColor = Color.FromArgb(red, green, blue);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (yonsag == false) sayıx = -trackBar1.Value;
            else sayıx = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (yonasagi == false) sayıy = -trackBar2.Value;
            else sayıy = trackBar2.Value;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            if (randomcolor == false)
            {
                blue.Text = "RANDOM COLOR(✓)";
                randomcolor = true;
            }
            else
            {
                randomcolor = false;
                blue.Text = "RANDOM COLOR(X)";
            }
        }
    }
}