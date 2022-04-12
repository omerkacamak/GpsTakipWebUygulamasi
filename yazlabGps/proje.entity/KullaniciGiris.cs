using System;

namespace proje.entity
{
    public class KullaniciGiris
    {
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public DateTime girisZamani { get; set; }
    }
}