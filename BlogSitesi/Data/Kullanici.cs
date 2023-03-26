using Microsoft.AspNetCore.Identity;

namespace BlogSitesi.Data
{
    public class Kullanici : IdentityUser
    {
        public string KullaniciAdi { get; set; } = null!;
        public string AdSoyad { get; set; } = null!;
        public string Resim { get; set; } = null!;
        public List<Makale> Makaleler { get; set; } = new();
    }
}
