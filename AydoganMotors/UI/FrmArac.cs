using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AydoganMotors.UI
{
    public partial class FrmArac : Form
    {
        public FrmArac()
        {
            InitializeComponent();
        }
        public Arac Arac { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtArac)) return;
            if (!ErrorControl(cbKategori)) return;
            if (!ErrorControl(nmFiyat)) return;
            if (!ErrorControl(nmKm)) return;
            if (!ErrorControl(cbKasaTipi)) return;
            if (!ErrorControl(txtDetay)) return;

            Arac.Ad = txtArac.Text;
            Arac.Kategori = cbKategori.Text;
            Arac.Fiyat = (double)nmFiyat.Value;
            Arac.Kilometre = (double)nmKm.Value;
            Arac.KasaTipi = cbKasaTipi.Text;
            Arac.Detay = txtDetay.Text;

            DialogResult = DialogResult.OK;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            return true;
        }

        private void FrmArac_Load(object sender, EventArgs e)
        {
            txtArac.Text = Arac.ID.ToString();
            if (Güncelleme)
            {
                txtArac.Text = Arac.Ad;
                cbKategori.Text = Arac.Kategori;
                nmFiyat.Value = (decimal)Arac.Fiyat;
                nmKm.Value = (decimal)Arac.Kilometre;
                cbKasaTipi.Text = Arac.KasaTipi;
                txtDetay.Text = Arac.Detay;


            }
        }
    }
}
