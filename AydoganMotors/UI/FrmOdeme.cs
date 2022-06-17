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
    public partial class FrmOdeme : Form
    {
        public FrmOdeme()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Odeme Odeme { get; set; }
        public bool Güncelleme { get; set; } = false;

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (nmTutar.Value == 0)
            {
                errorProvider1.SetError(nmTutar, "Lütfen tutar giriniz!");
                nmTutar.Focus();
                return;

            }
            else
            {
                errorProvider1.SetError(nmTutar, "");
            }
            if (cbTur.SelectedItem==null)
            {
                if (cbTur.Text == "")
                {
                    errorProvider1.SetError(cbTur, "Ödeme türünü seçiniz!!");
                    cbTur.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(cbTur, "");

                }
                if (txtDetay.Text == "")
                {
                    errorProvider1.SetError(txtDetay, "Eksik veya hatalı bilgi");
                    txtDetay.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtDetay, "");
                }
                Odeme.ID = Guid.Parse(txtMusteri.Text);
                Odeme.Tur = cbTur.SelectedItem.ToString();
                Odeme.Tutar = (double)nmTutar.Value;
                Odeme.Aciklama = txtDetay.Text;
                Odeme.Tarih = dtTarih.Value;
            }

            DialogResult =DialogResult.OK;
        }

        private void FrmOdeme_Load(object sender, EventArgs e)
        {
            txtID.Text = Odeme.ID.ToString();
            if (Güncelleme)
            {
                txtMusteri.Text = Odeme.MusteriID.ToString();
                nmTutar.Value = (decimal)Odeme.Tutar;
                dtTarih.Value = Odeme.Tarih;
                cbTur.SelectedItem = Odeme.Tur;
                txtDetay.Text = Odeme.Aciklama.ToString();
            }
        }

        private void btnMusteriSec_click(object sender, EventArgs e)
        {

            Musteriler frm = new Musteriler();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtMusteri.Text = frm.Musteri.ID.ToString();
            }
        }
    }
}
