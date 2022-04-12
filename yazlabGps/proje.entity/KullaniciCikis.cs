using System;

namespace proje.entity
{
    public class KullaniciCikis
    {
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public DateTime cikisZamani { get; set; }
    }
}