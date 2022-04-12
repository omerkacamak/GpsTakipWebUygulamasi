namespace proje.entity
{
    public class KullaniciArabalari
    {
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public int ArabaId { get; set; }
        public Araba Araba { get; set; }
    }
}