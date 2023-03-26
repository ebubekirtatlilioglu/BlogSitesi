using BlogSitesi.Data;

namespace BlogSitesi.Models
{
    public class KullaniciViewModel
    {
        public string KullaniciAdi { get; set; }
        public IFormFile Resim { get; set; } = null!;
    }
}
