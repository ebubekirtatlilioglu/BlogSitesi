namespace BlogSitesi.Data
{
    public class Makale
    {
        public int Id { get; set; }
        public string KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now.Date;
        public double OkunmaSuresi { get; set; }
        public List<Konu> Konular { get; set; } = new();
    }
}
