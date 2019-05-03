using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sayısalloto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] dizi = new int[6];

        private void Form1_Load(object sender, EventArgs e)
        {
            oyunBaslat();
        }
        private void oyunBaslat()
        {
            int[] sayilar = new int[6];
            

            int solTaraf = 4;
            panel1.Controls.Clear();
            // Random rnd = new Random(DateTime.Now.Millisecond);
            //int indis = rastgele.Next(1, 50);  //1 ile 49 arasında sayıları gecici diye bi degiskene atadım. 50 tane olur dizide  kaçıncıyı yazıca
            //sayi dizimize rastgele sayı atayalım.

            for (int i = 0; i < 6; i++)
            {
                TextBox txtbx = new TextBox();
                panel1.Controls.Add(txtbx);
                txtbx.Top = 30;
                txtbx.Left = solTaraf;
                txtbx.Width = 30;
                txtbx.Text = "?";
                txtbx.BackColor = Color.LightPink;
                txtbx.Tag = sayilar[i];
                solTaraf += 40;

                txtbx.Refresh();


            }
            panel1.BackColor = Color.White;
            panel1.Refresh();
            int solTaraf1 = 4;
            panel2.Controls.Clear();
            for (int i = 0; i < 6; i++)
            {
                TextBox txtbx1 = new TextBox();
                panel2.Controls.Add(txtbx1);
                txtbx1.Top = 30;
                txtbx1.Left = solTaraf1;
                txtbx1.Width = 30;
                txtbx1.Text = "_";
                txtbx1.BackColor = Color.LightPink;
                txtbx1.Tag = sayilar[i];
                solTaraf1 += 40;

                txtbx1.Refresh();
            }
            panel2.BackColor = Color.White;
            panel2.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            var sayilar = new List<int>();

            while (sayilar.Count < 6)
            {
                Random rastgele = new Random(DateTime.Now.Millisecond);
                int sayi = rastgele.Next(1, 50);
                if (!sayilar.Contains(sayi))
                {
                    sayilar.Add(sayi);

                }
            }
            int i = 0;
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    var txtbx1 = item as TextBox;
                    if (txtbx1.Text == "?")
                    {
                        Random r = new Random();
                        int sayi = r.Next(1, 50);
                        txtbx1.Text = sayilar[i].ToString();
                        i++;
                    }
                }
            }

            //diziyi yazdırabilirim burda
            int bilinen = 0;
            int index = 0;
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    var txtbx1 = item as TextBox;
                    if (int.Parse(txtbx1.Text) == dizi[index])
                    {
                        bilinen++;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            MessageBox.Show("bilinen:" + bilinen);
            int toplam = 0;
            int para = 2;
            switch (bilinen)
            {
                case 6:
                    toplam += bilinen * para;
                    toplam_para.Text = Convert.ToString(toplam) + " " + "₺";

                    break;
                case 5:
                    toplam += bilinen * para;
                    toplam_para.Text = Convert.ToString(para) + " " + "₺";
                    break;

                case 4:
                    toplam += bilinen * para;
                    toplam_para.Text = Convert.ToString(para) + " " + "₺";
                    break;
                case 3:
                    toplam += bilinen * para;
                    toplam_para.Text = Convert.ToString(para) + " " + "₺";
                    break;
                case 2:
                    toplam += bilinen * para;
                    toplam_para.Text = Convert.ToString(para) + " " + "₺";
                    break;
                case 1:
                    toplam += bilinen * para;
                    toplam_para.Text = Convert.ToString(para) + " " + "₺";
                    break;
                case 0:
                    toplam += bilinen * para;
                    toplam_para.Text = "Malesef Hiç Bir şey Kazanamadınız :( ";
                    MessageBox.Show("Oyun bitti");
                    break;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isEnd = true;
            foreach (Control item in panel2.Controls)
            {
                if (item is TextBox)

                {
                    var txtbx = item as TextBox;
                    if (item.Text == textBox1.Text)
                        isEnd = false;
                }
            }
            if (!isEnd)
            {
                MessageBox.Show("Bu değer daha önce girildi");
                return;
            }
            var deger = Convert.ToInt32(textBox1.Text);
                if (deger > 49)

                {
                    MessageBox.Show("Lütfen 1-49 arası sayi girin:");
                    return;
                }
                else if (deger <= 0)
                {
                    MessageBox.Show("negatif veya 0 deger girilemez.");
                    return;
                }

                int sayac = 0;
                foreach (var item in panel2.Controls)
                {
                    if (item is TextBox)

                    {
                        var txtbx = item as TextBox;

                        if (txtbx.Text == "_")
                        {
                            txtbx.Text = textBox1.Text;
                            dizi[sayac] = int.Parse(textBox1.Text);

                            textBox1.Clear();
                            return;
                        }
                        else //değilse sayacı arttırsın
                        {
                            sayac++;
                        }

                    }

                }




            }

            private void textBox1_keyPress(object sender, KeyPressEventArgs e)
            {

                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    button2.PerformClick();
                }
            }
        }
    }



