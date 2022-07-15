﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOtobus.Text)
            {
                case "Travego": KoltukDoldur(8, false);
                    break;
                case "Neoplan":
                    KoltukDoldur(10, false);
                    break;
                case "Setra": KoltukDoldur(12, true); 
                    break;

                default:
                    break;
            }
        }
        void KoltukDoldur(int sira, bool arkaBesliMi) //geriye değer döndürmesin diye void yaptık
        {
            yavaslat: 
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = ctrl as Button;
                    if (btn.Text == "Kaydet")
                    {
                        continue;
                    }
                    else
                    {
                        this.Controls.Remove(ctrl);
                        goto yavaslat;
                    }
                }
            }
            int koltukNo = 1;
            for (int i = 0; i < sira; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == sira / 2 && j>2)
                    {
                        continue;
                    }
                    if (arkaBesliMi == true)
                    {
                        if (i != sira - 1 && j == 2)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (j == 2)
                            continue;
                    }
                    Button koltuk = new Button();
                    koltuk.Height = koltuk.Width = 50;
                    koltuk.Top = 30 + (i*50); //top yukarıdan boşluk ayarlar
                    koltuk.Left = 10 + (j * 50);
                    koltuk.Text = koltukNo.ToString();
                    koltukNo++;
                    koltuk.ContextMenuStrip = contextMenuStrip1;
                    this.Controls.Add(koltuk);
                }
            }
        }

        private void tsmRezerveEt_Click(object sender, EventArgs e)
        {
            //contextMenuStrip sağ clickte gelir

            if (cmbOtobus.SelectedIndex == -1 || cmbNereden.SelectedIndex == -1 || cmbNereye.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen önce gerekli alanları doldurunuz.");
                return; // return içersinde bulunduğu metodu sonlandırır. return kullanınca else yazmadım
            }
            KayitFormu kayitFormu = new KayitFormu();
            kayitFormu.ShowDialog(); //Show ile açınca arka planda herhangi bir formu kitlemez. Show dialog ise arkada kalan formu kitler
        }
    }
}
