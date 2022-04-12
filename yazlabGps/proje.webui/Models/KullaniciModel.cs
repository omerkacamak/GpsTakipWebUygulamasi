using System.Collections;
using System.Collections.Generic;
using proje.entity;

namespace proje.webui.Models
{
    public class KullaniciModel
    {
        public int KullaniciId { get; set; }
        public Kullanici kullanici { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string kullaniciAdi { get; set; }
        public string TelNo { get; set; }
        public List<KullaniciArabalari> KullaniciArabalarim { get; set; }
        //public List<ArabaYollari> ArabaYollarim { get; set; }
        public  List<List<Yol>> SonOtuz { get; set; }
        public List<List<Yol>> arabalarVeYollari { get; set; }
        public IEnumerable forDate1 { get; set; }
        public IEnumerable forDate2 { get; set; }
        public IEnumerable forHour1 { get; set; }
        public IEnumerable forHour2 { get; set; }
        public List<Yol> yolum { get; set; }
        public Araba secilenAraba { get; set; }
        
        
       // public List<KullaniciArabalari> KullaniciArabalari { get; set; }
    }
}