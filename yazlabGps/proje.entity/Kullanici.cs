using System.Collections.Generic;

namespace proje.entity
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        
        
        public List<KullaniciArabalari> KullaniciArabalari { get; set; }
       // public List<Araba> yaz {get;set;}


    }
}