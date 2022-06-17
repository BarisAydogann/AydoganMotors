using AydoganMotors.BL;

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
    public partial class Araclar : Form
    {
        public Araclar()
        {
            InitializeComponent();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            FrmArac frm = new FrmArac()
            {
                Text = "Arac Ekle",
                Arac = new Arac() { ID = Guid.NewGuid() },
            };

            tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.AracEkle(frm.Arac);

                if (b)
                {

                    DataSet ds = BLogic.AracGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;

            }
        }

        private void btnAracBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.AracGetir(toolStripTextBox2.Text);
            if (ds != null)
                dataGridView2.DataSource = ds.Tables[0];
        }

        private void btnAracDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

            FrmArac frm = new FrmArac()
            {
                Text = "Araç Güncelle",
                Güncelleme = true,
                Arac = new Arac()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Kategori = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                    Kilometre = double.Parse(row.Cells[4].Value.ToString()),
                    KasaTipi = row.Cells[5].Value.ToString(),
                    Detay = row.Cells[6].Value.ToString(),

                },
            };

            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.AracGüncelle(frm.Arac);

                if (b)
                {
                    row.Cells[1].Value = frm.Arac.Ad;
                    row.Cells[2].Value = frm.Arac.Kategori;
                    row.Cells[3].Value = frm.Arac.Fiyat;
                    row.Cells[4].Value = frm.Arac.Kilometre;
                    row.Cells[5].Value = frm.Arac.KasaTipi;
                    row.Cells[6].Value = frm.Arac.Detay;

                }

            }
        }

        private void btnAracSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili Arac silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.AracSil(ID);

                if (b)
                {

                    DataSet ds = BLogic.AracGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }

            }

        }

        private void Araclar_Load(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.AracGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }

        public Arac Arac { get; set; }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];


            Arac = new Arac()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                Kategori = row.Cells[2].Value.ToString(),
                Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                Kilometre = double.Parse(row.Cells[4].Value.ToString()),
                KasaTipi = row.Cells[5].Value.ToString(),
                Detay = row.Cells[6].Value.ToString(),


            };

            DialogResult = DialogResult.OK;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
