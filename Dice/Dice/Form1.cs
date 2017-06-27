using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Dice
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer klik;
        Uklad kosciany;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            string sciezka = Application.StartupPath + "\\music.mp3";
            klik = new WindowsMediaPlayer();
            klik.URL = sciezka;
            klik.controls.play();
            kosciany = new Uklad();
            
        }

        private void bt_losuj_Click(object sender, EventArgs e)
        {
            ShowajKosci();
            klik.controls.play();
            Random gen = new Random();
            int kosc1 = gen.Next(1, 7);
            int kosc2 = gen.Next(1, 7);
            int kosc3 = gen.Next(1, 7);
            int kosc4 = gen.Next(1, 7);
            int kosc5 = gen.Next(1, 7);
            int ilosc = kosciany.Graj(kosc1, kosc2, kosc3, kosc4, kosc5);
            PokazKosc(kosc1, 1);
            PokazKosc(kosc2, 2);
            PokazKosc(kosc3, 3);
            PokazKosc(kosc4, 4);
            PokazKosc(kosc5, 5);
            int punkty;
            switch(ilosc)
            {
                case 0: label1.Text = "Nic"; break;
                case 1: label1.Text = "Para";break;
                case 2: label1.Text = "Dwie Pary"; break;
                case 3: label1.Text = "Trójka"; break;
                case 4: label1.Text = "Mały Strit"; break;
                case 5: label1.Text = "Duży Strit"; break;
                case 6: label1.Text = "Full"; break;
                case 7: label1.Text = "Kareta"; break;
                case 8: label1.Text = "Poker"; break;
            }
            if(lb_points.Text.Length>0)
            {
                punkty = Convert.ToInt32(lb_points.Text);
                punkty =ilosc + punkty;
                lb_points.Text = punkty.ToString();
            }
            else
            {
                punkty = ilosc;
                lb_points.Text = punkty.ToString();
            }
        }
        private void PokazKosc(int x, int y)
        {
            if (y == 1)
            {
                switch (x)
                {
                    case 1: this.pictureBox1.Visible = true; break;
                    case 2: this.pictureBox2.Visible = true; break;
                    case 3: this.pictureBox3.Visible = true; break;
                    case 4: this.pictureBox4.Visible = true; break;
                    case 5: this.pictureBox5.Visible = true; break;
                    case 6: this.pictureBox6.Visible = true; break;
                }
            }
            if (y == 2)
            {
                switch (x)
                {
                    case 1: this.pictureBox7.Visible = true; break;
                    case 2: this.pictureBox8.Visible = true; break;
                    case 3: this.pictureBox9.Visible = true; break;
                    case 4: this.pictureBox10.Visible = true; break;
                    case 5: this.pictureBox11.Visible = true; break;
                    case 6: this.pictureBox12.Visible = true; break;
                }
            }
            if (y == 3)
            {
                switch (x)
                {
                    case 1: this.pictureBox13.Visible = true; break;
                    case 2: this.pictureBox14.Visible = true; break;
                    case 3: this.pictureBox15.Visible = true; break;
                    case 4: this.pictureBox16.Visible = true; break;
                    case 5: this.pictureBox17.Visible = true; break;
                    case 6: this.pictureBox18.Visible = true; break;
                }
            }
            if (y == 4)
            {
                switch (x)
                {
                    case 1: this.pictureBox19.Visible = true; break;
                    case 2: this.pictureBox20.Visible = true; break;
                    case 3: this.pictureBox21.Visible = true; break;
                    case 4: this.pictureBox22.Visible = true; break;
                    case 5: this.pictureBox23.Visible = true; break;
                    case 6: this.pictureBox24.Visible = true; break;
                }
            }
            if (y == 5)
            {
                switch (x)
                {
                    case 1: this.pictureBox25.Visible = true; break;
                    case 2: this.pictureBox26.Visible = true; break;
                    case 3: this.pictureBox27.Visible = true; break;
                    case 4: this.pictureBox28.Visible = true; break;
                    case 5: this.pictureBox29.Visible = true; break;
                    case 6: this.pictureBox30.Visible = true; break;
                }
            }
        }

        private void ShowajKosci()
        {
            this.pictureBox1.Visible = false;
            this.pictureBox2.Visible = false;
            this.pictureBox3.Visible = false;
            this.pictureBox4.Visible = false;
            this.pictureBox5.Visible = false;
            this.pictureBox6.Visible = false;
            this.pictureBox7.Visible = false;
            this.pictureBox8.Visible = false;
            this.pictureBox9.Visible = false;
            this.pictureBox10.Visible = false;
            this.pictureBox11.Visible = false;
            this.pictureBox12.Visible = false;
            this.pictureBox13.Visible = false;
            this.pictureBox19.Visible = false;
            this.pictureBox14.Visible = false;
            this.pictureBox20.Visible = false;
            this.pictureBox15.Visible = false;
            this.pictureBox21.Visible = false;
            this.pictureBox16.Visible = false;
            this.pictureBox22.Visible = false;
            this.pictureBox17.Visible = false;
            this.pictureBox23.Visible = false;
            this.pictureBox18.Visible = false;
            this.pictureBox24.Visible = false;
            this.pictureBox25.Visible = false;
            this.pictureBox26.Visible = false;
            this.pictureBox27.Visible = false;
            this.pictureBox28.Visible = false;
            this.pictureBox29.Visible = false;
            this.pictureBox30.Visible = false;
            this.pictureBox24.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nic - pięć nie tworzących żadnego układu oczek\nPara - dwie kości o tej samej liczbie oczek\nDwie Pary - dwie pary kości, o tej samej liczbie oczek\nTrójka - trzy kości o tej samej liczbie oczek\nMały Strit - kości pokazujące wartości od 1 do 5, po kolei\nDuży Strit - kości pokazujące wartości od 2 do 6, po kolei\nFull - jedna para i trójka\nKareta - cztery kości o tej samej liczbie oczek\nPoker - pięć kości o tej samej liczbie oczek", "Zasady", MessageBoxButtons.OK);
        }
    }
}
