using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AydoganMotors
{
  public class Musteri
    {
        public Guid ID { get; set; }    
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public override string ToString()
        {
            return $"{Ad} {Soyad}";
        }

    }

    public class Arac
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public double Kilometre { get; set; }
        public string KasaTipi { get; set; }
        public string Detay { get; set; }
        public override string ToString()
        {
            return $"{Ad} {Detay}";
        }

    }

    public class Odeme
    {
        public Guid ID { get; set; }
        public Guid MusteriID { get; set; }
        public DateTime Tarih { get; set; }
        public double Tutar { get; set; }
        public string Tur { get; set; }
        public string Aciklama { get; set; }

    }

    public class Satis
    {
        public Guid ID { get; set; }
        public Guid MusteriID { get; set; }
        public Guid AracID { get; set; }
        public DateTime Tarih { get; set; }
        public double Fiyat { get; set; }

    }
}
